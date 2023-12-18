using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGoTool
{
    public partial class AddRowWindow : Form
    {
        private DataTable? dt;
        private MainWindow mainWindow;

        public AddRowWindow(MainWindow mainWindow, DataTable dt)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.dt = dt;
        }

        /// <summary>
        /// Closes the current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reads the input provided by the user in the text fields and, if enough and correct information was provided, adds it to the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();
            if (this.dt == null)
            {
                dt = handler.CreatePokegenieHeader();
            }
            mainWindow.UpdateDataGridView(dt);
        }

        /// <summary>
        /// Reads the content of all input boxes and checks if all mandatory information was given to create a Pokemon and if the input is valid.
        /// </summary>
        /// <returns>True if the input is valid and enough information was provided, false otherwise.</returns>
        private bool ParseUserInputs()
        {
            return true;
        }

        
    }
}
