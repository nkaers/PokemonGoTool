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
    public partial class EditRowWindow : Form
    {
        public Pokemon Pokemon { get; private set; }

        public EditRowWindow(Pokemon pokemon)
        {
            InitializeComponent();
            this.Pokemon = pokemon;

            nameInputBox.Text = pokemon.Name;
            formInputBox.Text = pokemon.Form;
            cpInputBox.Text = pokemon.CP.ToString();
            attackIVInputBox.Text = pokemon.AtkIV.ToString();
            defenseIVInputBox.Text = pokemon.DefIV.ToString();
            hpIVInputBox.Text = pokemon.StaIV.ToString();
            quickMoveInputBox.Text = pokemon.QuickMove;
            chargeMoveInputBox.Text = pokemon.ChargeMove;
            chargeMove2InputBox.Text = pokemon.ChargeMove2;
            genderDropdownList.SelectedIndex = genderDropdownList.FindStringExact(pokemon.Gender.ToString());
            weightInputBox.Text = pokemon.Weight.ToString();
            heightInputBox.Text = pokemon.Height.ToString();
            hpInputBox.Text = pokemon.HP.ToString();

            if (pokemon.MinLevel == pokemon.MaxLevel) 
            {
                levelInputBox.Text = pokemon.MaxLevel.ToString();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ParseUserInputs())
            {
                return;
            }

            string name = nameInputBox.Text;
            string form = formInputBox.Text;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), genderDropdownList.SelectedItem.ToString());
            int? cp = string.IsNullOrEmpty(cpInputBox.Text) ? (int?)null : int.Parse(cpInputBox.Text);
            int? hp = string.IsNullOrEmpty(hpInputBox.Text) ? (int?)null : int.Parse(hpInputBox.Text);
            int? atkIV = string.IsNullOrEmpty(attackIVInputBox.Text) ? (int?)null : int.Parse(attackIVInputBox.Text);
            int? defIV = string.IsNullOrEmpty(defenseIVInputBox.Text) ? (int?)null : int.Parse(defenseIVInputBox.Text);
            int? staIV = string.IsNullOrEmpty(hpIVInputBox.Text) ? (int?)null : int.Parse(hpIVInputBox.Text);
            float? minLevel = string.IsNullOrEmpty(levelInputBox.Text) ? (float?)null : float.Parse(levelInputBox.Text);
            float? maxLevel = string.IsNullOrEmpty(levelInputBox.Text) ? (float?)null : float.Parse(levelInputBox.Text);
            string quickMove = quickMoveInputBox.Text;
            string chargeMove = chargeMoveInputBox.Text;
            string chargeMove2 = chargeMove2InputBox.Text;
            float? weight = string.IsNullOrEmpty(weightInputBox.Text) ? (float?)null : float.Parse(weightInputBox.Text);
            float? height = string.IsNullOrEmpty(heightInputBox.Text) ? (float?)null : float.Parse(heightInputBox.Text);

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
        /// Closes the current window to cancel the edit row operation.
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
        /// Reads the content of all input boxes and checks if all mandatory information was given to create a Pokemon and if the input is valid.
        /// </summary>
        /// <returns>True if the input is valid and enough information was provided, false otherwise.</returns>
        private bool ParseUserInputs()
        {
            return true;
        }
    }
}
