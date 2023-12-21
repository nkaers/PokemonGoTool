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
        public Pokemon Pokemon { get; private set; }

        public AddRowWindow()
        {
            InitializeComponent();
            Pokemon = new Pokemon("Placeholder", State.Normal, 0);
        }

        /// <summary>
        /// Closes the current window to cancel the add row operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Close the form with Cancel result
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Reads the input provided by the user in the text fields and, if enough and correct information was provided, adds it to the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!ParseUserInputs())
            {
                return;
            }

            string name = nameInputBox.Text;
            string form = formInputBox.Text;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), genderDropdownList.SelectedItem.ToString());
            int? cp = string.IsNullOrEmpty(cpInputBox.Text) ? null : int.Parse(cpInputBox.Text);
            int? hp = string.IsNullOrEmpty(hpInputBox.Text) ? null : int.Parse(hpInputBox.Text);
            int? atkIV = string.IsNullOrEmpty(attackIVInputBox.Text) ? null : int.Parse(attackIVInputBox.Text);
            int? defIV = string.IsNullOrEmpty(defenseIVInputBox.Text) ? null : int.Parse(defenseIVInputBox.Text);
            int? staIV = string.IsNullOrEmpty(hpIVInputBox.Text) ? null : int.Parse(hpIVInputBox.Text);
            float? minLevel = string.IsNullOrEmpty(levelInputBox.Text) ? null : float.Parse(levelInputBox.Text);
            float? maxLevel = string.IsNullOrEmpty(levelInputBox.Text) ? null : float.Parse(levelInputBox.Text);
            string quickMove = quickMoveInputBox.Text;
            string chargeMove = chargeMoveInputBox.Text;
            string chargeMove2 = chargeMove2InputBox.Text;
            float? weight = string.IsNullOrEmpty(weightInputBox.Text) ? null : float.Parse(weightInputBox.Text);
            float? height = string.IsNullOrEmpty(heightInputBox.Text) ? null : float.Parse(heightInputBox.Text);

            // Create an instance of Pokemon
            Pokemon pokemon = new Pokemon(
                name,
                Pokemon.State,
                Pokemon.PokemonId,
                form,
                gender,
                cp,
                hp,
                atkIV,
                defIV,
                staIV,
                minLevel,
                maxLevel,
                quickMove,
                chargeMove,
                chargeMove2,
                Pokemon.ScanDate,
                Pokemon.CatchDate,
                weight,
                height,
                Pokemon.Lucky
            );

            Pokemon = pokemon;

            // Close the form with OK result
            DialogResult = DialogResult.OK;
            Close();
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
