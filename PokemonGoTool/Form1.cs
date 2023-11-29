using System.Data;
using System.Formats.Tar;
using System.Globalization;
using System.Windows.Forms;

namespace PokemonGoTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            filePath.Text = openFileDialog.FileName;
            BindData(filePath.Text);
        }

        private void BindData(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                // first line to create header
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');

                // create lists of the most common headers and their corresponding type
                // TODO list of headers which are common but not implemented yet: Scan Date, Catch Date, Marked for PvP use
                // TODO list of headers which are common and implemented but can be improved: Lucky, Shadow/Purified, Favorite, Sha/Pur (G), Sha/Pur (U), Sha/Pur (L)
                string[] stringHeaders = {
                    "Name",
                    "Form",
                    "Gender",
                    "Quick Move",
                    "Charge Move",
                    "Charge Move 2",
                    "Name (G)",
                    "Form (G)",
                    "Name (U)",
                    "Form (U)",
                    "Name (L)",
                    "Form (L)"
                };
                string[] intHeaders = {
                    "Index",
                    "Pokemon",
                    "CP",
                    "HP",
                    "Atk IV",
                    "Def IV",
                    "Sta IV",
                    "Lucky",
                    "Shadow/Purified",
                    "Favorite",
                    "Dust",
                    "Rank # (G)",
                    "Dust Cost (G)",
                    "Candy Cost (G)",
                    "Sha/Pur (G)",
                    "Rank # (U)",
                    "Dust Cost (U)",
                    "Candy Cost (U)",
                    "Sha/Pur (U)",
                    "Rank # (L)",
                    "Dust Cost (L)",
                    "Candy Cost (L)",
                    "Sha/Pur (L)"
                };
                string[] floatHeaders = {
                    "IV Avg",
                    "Level Min",
                    "Level Max",
                    "Weight",
                    "Height",
                    "Rank % (G)",
                    "Stat Product (G)",
                    "Rank % (U)",
                    "Stat Product (U)",
                    "Rank % (L)",
                    "Stat Product (L)"
                };

                foreach (string headerWord in headerLabels)
                {
                    if (stringHeaders.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(string)));
                    }
                    else if (intHeaders.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(int)));
                    }
                    else if (floatHeaders.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(float)));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(string)));
                    }
                }
                //For Data
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        if (!String.IsNullOrEmpty(dataWords[columnIndex]))
                        {
                            // delete the kg from weight to allow parsing to float
                            if (dataWords[columnIndex].Contains("kg")) 
                            {
                                dataWords[columnIndex] = dataWords[columnIndex].Replace("kg", " ");
                            }
                            // delete the m from height to allow parsing to float
                            // catching normal form so it does not become nor al
                            if (dataWords[columnIndex].Contains('m') && !dataWords[columnIndex].Equals("Normal"))
                            {
                                dataWords[columnIndex] = dataWords[columnIndex].Replace('m', ' ');
                            }
                            // delete the % from multiple headers to allow parsing to float
                            if (dataWords[columnIndex].Contains('%'))
                            {
                                dataWords[columnIndex] = dataWords[columnIndex].Replace('%', ' ');
                            }


                            // checks to catch columns which need special treatment like parsing the value
                            if (stringHeaders.Contains(headerWord))
                            {
                                dr[headerWord] = dataWords[columnIndex++];
                            }
                            else if (intHeaders.Contains(headerWord))
                            {
                                dr[headerWord] = Int32.Parse(dataWords[columnIndex++], CultureInfo.InvariantCulture.NumberFormat);
                            }
                            else if (floatHeaders.Contains(headerWord))
                            {
                                dr[headerWord] = float.Parse(dataWords[columnIndex++], CultureInfo.InvariantCulture.NumberFormat);
                            }
                            else
                            {
                                dr[headerWord] = dataWords[columnIndex++];
                            }
                        } 
                        else
                        {
                            // catches empty data cells and leaves them empty so no ArgumentException will be thrown
                            columnIndex++;
                        }
                        
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                pokemonData.DataSource = dt;
            }

        }
    }
}