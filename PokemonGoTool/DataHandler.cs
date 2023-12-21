using System;
using System.Data;
using System.Globalization;

namespace PokemonGoTool
{
    public class DataHandler
    {
        private string[] StringHeaders { get; }
        private string[] IntHeaders { get; }
        private string[] FloatHeaders { get; }
        private string[] StateHeaders { get; }

        public DataHandler()
        {
            // create lists of the most common headers and their corresponding type
            // TODO list of headers which are common but not implemented yet: Scan Date, Catch Date, Marked for PvP use
            // TODO list of headers which are common and implemented but can be improved: Lucky, Favorite
            StringHeaders = new string[] {
                "Name",
                "Form",
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

            IntHeaders = new string[] {
                "Index",
                "Pokemon",
                "CP",
                "HP",
                "Atk IV",
                "Def IV",
                "Sta IV",
                "Lucky",
                "Favorite",
                "Dust",
                "Rank # (G)",
                "Dust Cost (G)",
                "Candy Cost (G)",
                "Rank # (U)",
                "Dust Cost (U)",
                "Candy Cost (U)",
                "Rank # (L)",
                "Dust Cost (L)",
                "Candy Cost (L)",
                };

            FloatHeaders = new string[] {
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

            StateHeaders = new string[] {
                "Shadow/Purified",
                "Sha/Pur (G)",
                "Sha/Pur (U)",
                "Sha/Pur (L)"
            };
        }


        /// <summary>
        /// This method extracts the data from the file given by the parameter and creates a DataTable which is then returned.
        /// </summary>
        /// <param name="filePath">A string which is a path pointing to the data source.</param>
        /// <returns>A DataTable with the content of the provided source file.</returns>
        public DataTable CreateDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                // first line to create header
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');

                foreach (string headerWord in headerLabels)
                {
                    if (StringHeaders.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(string)));
                    }
                    else if (IntHeaders.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(int)));
                    }
                    else if (FloatHeaders.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(float)));
                    }
                    else if (headerWord.Equals("Gender"))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(Gender)));
                    }
                    else if (StateHeaders.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(State)));
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
                            if (headerWord.Equals("Weight"))
                            {
                                dataWords[columnIndex] = dataWords[columnIndex].Replace("kg", " ");
                            }
                            // delete the m from height to allow parsing to float
                            if (headerWord.Equals("Height"))
                            {
                                dataWords[columnIndex] = dataWords[columnIndex].Replace('m', ' ');
                            }
                            // delete the % from multiple headers to allow parsing to float
                            if (dataWords[columnIndex].Contains('%') && !headerWord.Equals("Name"))
                            {
                                dataWords[columnIndex] = dataWords[columnIndex].Replace('%', ' ');
                            }


                            // checks to catch columns which need special treatment like parsing the value
                            if (StringHeaders.Contains(headerWord))
                            {
                                dr[headerWord] = dataWords[columnIndex++];
                            }
                            else if (IntHeaders.Contains(headerWord))
                            {
                                dr[headerWord] = Int32.Parse(dataWords[columnIndex++], CultureInfo.InvariantCulture.NumberFormat);
                            }
                            else if (FloatHeaders.Contains(headerWord))
                            {
                                dr[headerWord] = float.Parse(dataWords[columnIndex++], CultureInfo.InvariantCulture.NumberFormat);
                            }
                            else if (headerWord.Equals("Gender"))
                            {
                                if (dataWords[columnIndex].Equals("\u2642"))
                                {
                                    dr[headerWord] = Gender.Male;
                                    columnIndex++;
                                }
                                else if (dataWords[columnIndex].Equals("\u2640"))
                                {
                                    dr[headerWord] = Gender.Female;
                                    columnIndex++;
                                }
                                else
                                {
                                    dr[headerWord] = Gender.Genderless;
                                    columnIndex++;
                                }
                            }
                            else if (StateHeaders.Contains(headerWord))
                            {
                                dr[headerWord] = (State)Enum.Parse(typeof(State), dataWords[columnIndex++]);
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
            return dt;
        }

        /// <summary>
        /// Initialzes a DataTable with the standard Pokegenie export file headers.
        /// </summary>
        /// <returns>An empty DataTable with the column names and types specified.</returns>
        public DataTable CreatePokegenieHeader()
        {
            DataTable dt = new DataTable();

            // first line to create header
            string firstLine = "Index,Name,Form,Pokemon,Gender,CP,HP,Atk IV,Def IV,Sta IV,IV Avg,Level Min,Level Max,Quick Move,Charge Move,Charge Move 2,Scan Date,Catch Date,Weight,Height,Lucky,Shadow/Purified,Favorite,Dust,Rank % (G),Rank # (G),Stat Product (G),Dust Cost (G),Candy Cost (G),Name (G),Form (G),Sha/Pur (G),Rank % (U),Rank # (U),Stat Product (U),Dust Cost (U),Candy Cost (U),Name (U),Form (U),Sha/Pur (U),Rank % (L),Rank # (L),Stat Product (L),Dust Cost (L),Candy Cost (L),Name (L),Form (L),Sha/Pur (L),Marked for PvP use";
            string[] headerLabels = firstLine.Split(',');

            foreach (string headerWord in headerLabels)
            {
                if (StringHeaders.Contains(headerWord))
                {
                    dt.Columns.Add(new DataColumn(headerWord, typeof(string)));
                }
                else if (IntHeaders.Contains(headerWord))
                {
                    dt.Columns.Add(new DataColumn(headerWord, typeof(int)));
                }
                else if (FloatHeaders.Contains(headerWord))
                {
                    dt.Columns.Add(new DataColumn(headerWord, typeof(float)));
                }
                else
                {
                    dt.Columns.Add(new DataColumn(headerWord, typeof(string)));
                }
            }
            return dt;
        }
    }

}
