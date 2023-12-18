using System.Data;
using System.Formats.Tar;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace PokemonGoTool
{
    public partial class MainWindow : Form
    {

        private DataTable? dt;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open a file dialog and let the user choose an input file. This file will be used as a data source for the DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFile_Click(object sender, EventArgs e)
        {
            // Check if dt is null
            if (this.dt != null) 
            {
                // Prompt the user with a message box
                DialogResult result = MessageBox.Show("There is already a file opened. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) 
                {
                    return;
                }
            }

            openFileDialog.ShowDialog();
            try
            {
                DataHandler handler = new DataHandler();
                dt = handler.CreateDataTable(openFileDialog.FileName);
                filePath.Text = openFileDialog.FileName;
                if (dt.Rows.Count > 0)
                {
                    UpdateDataGridView(dt);
                }
            }
            catch 
            {
                MessageBox.Show("The file could not be opened", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        /// <summary>
        /// A method which saves all values which are displayed in the DataGridView to an existing or new csv file. If an existing csv file is chosen it is overwritten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToCSVBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            String separator = ",";
            StringBuilder output = new StringBuilder();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                // get all of the column names and add them to the output
                string[] headings = (from DataGridViewColumn column in pokemonData.Columns select column.HeaderText).ToArray();
                output.AppendLine(string.Join(separator, headings));

                // get all of the entries of every row and adding them to the output
                foreach (DataGridViewRow row in pokemonData.Rows)
                {
                    string[] rowEntries = (from DataGridViewCell cell in row.Cells select cell.Value.ToString().Replace(',', '.')).ToArray();
                    output.AppendLine(string.Join(separator, rowEntries));
                }

                try
                {
                    // save to file and if the file already exists overwrite it
                    File.WriteAllText(path, output.ToString());
                }
                catch (Exception ex) // TODO create error messages for specific cases instead of this
                {
                    ex.ToString();
                }
            }
        }

        /// <summary>
        /// Opens a new window with inputs so that the user can add a new entry to the DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRowBtn_Click(object sender, EventArgs e)
        {
            if (this.dt == null)
            {
                DialogResult result = MessageBox.Show("There is no file opened. A new table will be created. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    AddRowWindow addRowWindow = new AddRowWindow(this, dt);
                    addRowWindow.ShowDialog();
                }
            }
            else
            {
                AddRowWindow addRowWindow = new AddRowWindow(this, dt);
                addRowWindow.ShowDialog();
            }
        
        }

        public void UpdateDataGridView(DataTable dt)
        {
            if (dt != null) 
            {
                this.dt = dt;
                pokemonData.DataSource = dt;
            }
        }
    }
}