using System.Data;
using System.Formats.Tar;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace PokemonGoTool
{
    public enum DataTableVisibilityMode
    {
        Beginner,
        Advanced,
        Expert
    }

    public partial class MainWindow : Form
    {

        private DataTable? dt;

        public MainWindow()
        {
            InitializeComponent();
            dataTableModeDropDownList.SelectedIndex = 0;
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
                    DataHandler handler = new DataHandler();
                    dt = handler.CreatePokegenieHeader();
                    UpdateDataGridView(dt);
                }
                else return;
            }

            // Create and show the AddForm
            using (AddRowWindow addForm = new AddRowWindow())
            {
                // Show the form as a dialog
                DialogResult result = addForm.ShowDialog();

                // Check if the user clicked OK in the AddForm
                // TODO good idea but totally wrong at the moment
                // TODO outsource the creation of a pokemon in the table to the DataHandler so it can be used in Edit as well
                if (result == DialogResult.OK)
                {
                    DataRow dr = dt.NewRow();
                    int columnIndex = 1;
                    foreach (var property in addForm.Pokemon)
                    {
                        dr[columnIndex++] = property is null ? System.DBNull.Value : property;
                    }
                    dt.Rows.Add(dr);
                }
            }
        }

        /// <summary>
        /// This method updates the DataGridView and adjusts the output to the DataTableVisibilityMode setting which can be chosen by the user to remove some of the columns.
        /// </summary>
        /// <param name="dt">The data table to be displayed in the DataGridView.</param>
        public void UpdateDataGridView(DataTable dt)
        {
            if (dt != null)
            {
                this.dt = dt;
                pokemonData.DataSource = dt;

                DataTableVisibilityMode mode = (DataTableVisibilityMode)Enum.Parse(typeof(DataTableVisibilityMode), dataTableModeDropDownList.SelectedItem.ToString());
                switch (mode)
                {
                    // only show the minimum information needed to distinguish the Pokemon
                    case DataTableVisibilityMode.Beginner:
                        {
                            pokemonData.Columns["Index"].Visible = false;
                            pokemonData.Columns["Name"].Visible = true;
                            pokemonData.Columns["Form"].Visible = true;
                            pokemonData.Columns["Pokemon"].Visible = true;
                            pokemonData.Columns["Gender"].Visible = true;
                            pokemonData.Columns["CP"].Visible = true;
                            pokemonData.Columns["HP"].Visible = false;

                            pokemonData.Columns["Atk IV"].Visible = false;
                            pokemonData.Columns["Def IV"].Visible = false;
                            pokemonData.Columns["Sta IV"].Visible = false;
                            pokemonData.Columns["IV Avg"].Visible = true;

                            pokemonData.Columns["Level Min"].Visible = false;
                            pokemonData.Columns["Level Max"].Visible = false;

                            pokemonData.Columns["Quick Move"].Visible = false;
                            pokemonData.Columns["Charge Move"].Visible = false;
                            pokemonData.Columns["Charge Move 2"].Visible = false;

                            pokemonData.Columns["Scan Date"].Visible = false;
                            pokemonData.Columns["Catch Date"].Visible = false;

                            pokemonData.Columns["Weight"].Visible = false;
                            pokemonData.Columns["Height"].Visible = false;

                            pokemonData.Columns["Lucky"].Visible = false;
                            pokemonData.Columns["Shadow/Purified"].Visible = false;
                            pokemonData.Columns["Favorite"].Visible = false;
                            pokemonData.Columns["Dust"].Visible = false;

                            pokemonData.Columns["Rank % (G)"].Visible = true;
                            pokemonData.Columns["Rank # (G)"].Visible = false;
                            pokemonData.Columns["Stat Product (G)"].Visible = false;
                            pokemonData.Columns["Dust Cost (G)"].Visible = false;
                            pokemonData.Columns["Candy Cost (G)"].Visible = false;
                            pokemonData.Columns["Name (G)"].Visible = true;
                            pokemonData.Columns["Form (G)"].Visible = false;
                            pokemonData.Columns["Sha/Pur (G)"].Visible = false;

                            pokemonData.Columns["Rank % (U)"].Visible = true;
                            pokemonData.Columns["Rank # (U)"].Visible = false;
                            pokemonData.Columns["Stat Product (U)"].Visible = false;
                            pokemonData.Columns["Dust Cost (U)"].Visible = false;
                            pokemonData.Columns["Candy Cost (U)"].Visible = false;
                            pokemonData.Columns["Name (U)"].Visible = true;
                            pokemonData.Columns["Form (U)"].Visible = false;
                            pokemonData.Columns["Sha/Pur (U)"].Visible = false;

                            pokemonData.Columns["Rank % (L)"].Visible = true;
                            pokemonData.Columns["Rank # (L)"].Visible = false;
                            pokemonData.Columns["Stat Product (L)"].Visible = false;
                            pokemonData.Columns["Dust Cost (L)"].Visible = false;
                            pokemonData.Columns["Candy Cost (L)"].Visible = false;
                            pokemonData.Columns["Name (L)"].Visible = true;
                            pokemonData.Columns["Form (L)"].Visible = false;
                            pokemonData.Columns["Sha/Pur (L)"].Visible = false;

                            pokemonData.Columns["Marked for PvP use"].Visible = false;

                            break;
                        }
                    // show more information but hide unnecessary information
                    case DataTableVisibilityMode.Advanced:
                        {
                            pokemonData.Columns["Index"].Visible = false;
                            pokemonData.Columns["Name"].Visible = true;
                            pokemonData.Columns["Form"].Visible = true;
                            pokemonData.Columns["Pokemon"].Visible = true;
                            pokemonData.Columns["Gender"].Visible = true;
                            pokemonData.Columns["CP"].Visible = true;
                            pokemonData.Columns["HP"].Visible = true;

                            pokemonData.Columns["Atk IV"].Visible = true;
                            pokemonData.Columns["Def IV"].Visible = true;
                            pokemonData.Columns["Sta IV"].Visible = true;
                            pokemonData.Columns["IV Avg"].Visible = true;

                            pokemonData.Columns["Level Min"].Visible = false;
                            pokemonData.Columns["Level Max"].Visible = false;

                            pokemonData.Columns["Quick Move"].Visible = false;
                            pokemonData.Columns["Charge Move"].Visible = false;
                            pokemonData.Columns["Charge Move 2"].Visible = false;

                            pokemonData.Columns["Scan Date"].Visible = false;
                            pokemonData.Columns["Catch Date"].Visible = false;

                            pokemonData.Columns["Weight"].Visible = false;
                            pokemonData.Columns["Height"].Visible = false;

                            pokemonData.Columns["Lucky"].Visible = false;
                            pokemonData.Columns["Shadow/Purified"].Visible = true;
                            pokemonData.Columns["Favorite"].Visible = false;
                            pokemonData.Columns["Dust"].Visible = false;

                            pokemonData.Columns["Rank % (G)"].Visible = true;
                            pokemonData.Columns["Rank # (G)"].Visible = false;
                            pokemonData.Columns["Stat Product (G)"].Visible = false;
                            pokemonData.Columns["Dust Cost (G)"].Visible = false;
                            pokemonData.Columns["Candy Cost (G)"].Visible = false;
                            pokemonData.Columns["Name (G)"].Visible = true;
                            pokemonData.Columns["Form (G)"].Visible = false;
                            pokemonData.Columns["Sha/Pur (G)"].Visible = false;

                            pokemonData.Columns["Rank % (U)"].Visible = true;
                            pokemonData.Columns["Rank # (U)"].Visible = false;
                            pokemonData.Columns["Stat Product (U)"].Visible = false;
                            pokemonData.Columns["Dust Cost (U)"].Visible = false;
                            pokemonData.Columns["Candy Cost (U)"].Visible = false;
                            pokemonData.Columns["Name (U)"].Visible = true;
                            pokemonData.Columns["Form (U)"].Visible = false;
                            pokemonData.Columns["Sha/Pur (U)"].Visible = false;

                            pokemonData.Columns["Rank % (L)"].Visible = true;
                            pokemonData.Columns["Rank # (L)"].Visible = false;
                            pokemonData.Columns["Stat Product (L)"].Visible = false;
                            pokemonData.Columns["Dust Cost (L)"].Visible = false;
                            pokemonData.Columns["Candy Cost (L)"].Visible = false;
                            pokemonData.Columns["Name (L)"].Visible = true;
                            pokemonData.Columns["Form (L)"].Visible = false;
                            pokemonData.Columns["Sha/Pur (L)"].Visible = false;

                            pokemonData.Columns["Marked for PvP use"].Visible = false;

                            break;
                        }
                    // make every entry visible in expert mode
                    case DataTableVisibilityMode.Expert:
                        {
                            foreach (DataGridViewColumn column in pokemonData.Columns)
                            {
                                column.Visible = true;
                            }
                            break;
                        }
                    default: break;
                }
            }
        }

        /// <summary>
        /// Initialize an empty table which has the columns already defined. At the moment the standard Pokegenie properties are used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTableBtn_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                DialogResult result = MessageBox.Show("There is already a table open. A new table will be created and this one will be deleted. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            DataHandler handler = new DataHandler();
            dt = handler.CreatePokegenieHeader();
            UpdateDataGridView(dt);
        }

        private void editRowBtn_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (pokemonData.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = pokemonData.SelectedRows[0];

                // Extract data from the selected row
                string name = selectedRow.Cells["Name"].Value.ToString();
                string form = selectedRow.Cells["Form"].Value?.ToString();
                int pokemonId = (int)selectedRow.Cells["Pokemon"].Value;
                Gender gender = selectedRow.Cells["Gender"].Value == System.DBNull.Value ? Gender.Genderless : (Gender)selectedRow.Cells["Gender"].Value;
                int? cp = selectedRow.Cells["CP"].Value as int?;
                int? hp = selectedRow.Cells["HP"].Value as int?;
                int? atkIV = selectedRow.Cells["Atk IV"].Value as int?;
                int? defIV = selectedRow.Cells["Def IV"].Value as int?;
                int? staIV = selectedRow.Cells["Sta IV"].Value as int?;
                float? levelMin = selectedRow.Cells["Level Min"].Value as float?;
                float? levelMax = selectedRow.Cells["Level Max"].Value as float?;
                string? quickMove = selectedRow.Cells["Quick Move"].Value?.ToString();
                string? chargeMove = selectedRow.Cells["Charge Move"].Value?.ToString();
                string? chargeMove2 = selectedRow.Cells["Charge Move 2"].Value?.ToString();
                string? scanDate = selectedRow.Cells["Scan Date"].Value?.ToString();
                string? catchDate = selectedRow.Cells["Catch Date"].Value?.ToString();
                float? weight = selectedRow.Cells["Weight"].Value as float?;
                float? height = selectedRow.Cells["Height"].Value as float?;
                int? lucky = selectedRow.Cells["Lucky"].Value as int?;
                State shadowPurifiedState = (State)Enum.Parse(typeof(State), selectedRow.Cells["Shadow/Purified"].Value.ToString());


                Pokemon pokemon = new Pokemon(
                    name,
                    shadowPurifiedState,
                    pokemonId,
                    form,
                    gender,
                    cp,
                    hp,
                    atkIV,
                    defIV,
                    staIV,
                    levelMin,
                    levelMax,
                    quickMove,
                    chargeMove,
                    chargeMove2,
                    scanDate,
                    catchDate,
                    weight,
                    height,
                    lucky);


                // Create and show the EditForm
                using (EditRowWindow editForm = new EditRowWindow(pokemon))
                {
                    // Show the form as a dialog
                    DialogResult result = editForm.ShowDialog();

                    // Check if the user clicked OK in the EditForm
                    if (result == DialogResult.OK)
                    {
                        // Update the selected row with the edited values
                        selectedRow.Cells["Name"].Value = editForm.Pokemon.Name;
                        selectedRow.Cells["Form"].Value = editForm.Pokemon.Form;
                        selectedRow.Cells["CP"].Value = editForm.Pokemon.CP;
                        selectedRow.Cells["Atk IV"].Value = editForm.Pokemon.AtkIV;
                        selectedRow.Cells["Def IV"].Value = editForm.Pokemon.DefIV;
                        selectedRow.Cells["Sta IV"].Value = editForm.Pokemon.StaIV;
                        selectedRow.Cells["Quick Move"].Value = editForm.Pokemon.QuickMove;
                        selectedRow.Cells["Charge Move"].Value = editForm.Pokemon.ChargeMove;
                        selectedRow.Cells["Charge Move 2"].Value = editForm.Pokemon.ChargeMove2;
                        selectedRow.Cells["Gender"].Value = editForm.Pokemon.Gender;

                        selectedRow.Cells["Weight"].Value = editForm.Pokemon.Weight is null ? System.DBNull.Value : editForm.Pokemon.Weight;
                        selectedRow.Cells["Height"].Value = editForm.Pokemon.Height is null ? System.DBNull.Value : editForm.Pokemon.Height;
                        selectedRow.Cells["HP"].Value = editForm.Pokemon.HP is null ? System.DBNull.Value : editForm.Pokemon.HP;
                        selectedRow.Cells["Level Min"].Value = editForm.Pokemon.MinLevel is null ? System.DBNull.Value : editForm.Pokemon.MinLevel;
                        selectedRow.Cells["Level Max"].Value = editForm.Pokemon.MaxLevel is null ? System.DBNull.Value : editForm.Pokemon.MaxLevel;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        /// <summary>
        /// Calls the UpdateDataGridView method every time the user selects a new item in the setting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTableModeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView(dt);
        }

        /// <summary>
        /// Deletes all of the selected rows from the current data table. In order to avoid accidental deletion a confirmation prompt will be displayed first.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSelectedRowsBtn_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (pokemonData.SelectedRows.Count > 0)
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected entries?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    // Loop through all selected rows and remove each one
                    foreach (DataGridViewRow selectedRow in pokemonData.SelectedRows)
                    {
                        pokemonData.Rows.Remove(selectedRow);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one row to delete.");
            }
        }
    }
}