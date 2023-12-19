namespace PokemonGoTool
{
    partial class EditRowWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            levelInputBox = new TextBox();
            hpInputBox = new TextBox();
            saveBtn = new Button();
            cancelBtn = new Button();
            genderDropdownList = new ComboBox();
            additionalLabel = new Label();
            formInputBox = new TextBox();
            cpInputBox = new TextBox();
            attackIVInputBox = new TextBox();
            defenseIVInputBox = new TextBox();
            hpIVInputBox = new TextBox();
            quickMoveInputBox = new TextBox();
            chargeMoveInputBox = new TextBox();
            chargeMove2InputBox = new TextBox();
            weightInputBox = new TextBox();
            heightInputBox = new TextBox();
            nameInputBox = new TextBox();
            mandatoryLabel = new Label();
            SuspendLayout();
            // 
            // levelInputBox
            // 
            levelInputBox.Location = new Point(140, 130);
            levelInputBox.Name = "levelInputBox";
            levelInputBox.PlaceholderText = "Level";
            levelInputBox.Size = new Size(100, 23);
            levelInputBox.TabIndex = 36;
            // 
            // hpInputBox
            // 
            hpInputBox.Location = new Point(20, 130);
            hpInputBox.Name = "hpInputBox";
            hpInputBox.PlaceholderText = "HP";
            hpInputBox.Size = new Size(100, 23);
            hpInputBox.TabIndex = 35;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(400, 200);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 34;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(300, 200);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 33;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // genderDropdownList
            // 
            genderDropdownList.DropDownStyle = ComboBoxStyle.DropDownList;
            genderDropdownList.FormattingEnabled = true;
            genderDropdownList.Items.AddRange(new object[] { "Male", "Female", "Genderless" });
            genderDropdownList.Location = new Point(380, 95);
            genderDropdownList.Name = "genderDropdownList";
            genderDropdownList.Size = new Size(100, 23);
            genderDropdownList.TabIndex = 32;
            // 
            // additionalLabel
            // 
            additionalLabel.AutoSize = true;
            additionalLabel.Location = new Point(20, 75);
            additionalLabel.Name = "additionalLabel";
            additionalLabel.Size = new Size(128, 15);
            additionalLabel.TabIndex = 31;
            additionalLabel.Text = "Additional Information";
            // 
            // formInputBox
            // 
            formInputBox.Location = new Point(140, 40);
            formInputBox.Name = "formInputBox";
            formInputBox.PlaceholderText = "Form";
            formInputBox.Size = new Size(100, 23);
            formInputBox.TabIndex = 30;
            // 
            // cpInputBox
            // 
            cpInputBox.Location = new Point(260, 40);
            cpInputBox.Name = "cpInputBox";
            cpInputBox.PlaceholderText = "CP";
            cpInputBox.Size = new Size(100, 23);
            cpInputBox.TabIndex = 29;
            // 
            // attackIVInputBox
            // 
            attackIVInputBox.Location = new Point(380, 40);
            attackIVInputBox.Name = "attackIVInputBox";
            attackIVInputBox.PlaceholderText = "Attack IV";
            attackIVInputBox.Size = new Size(100, 23);
            attackIVInputBox.TabIndex = 28;
            // 
            // defenseIVInputBox
            // 
            defenseIVInputBox.Location = new Point(500, 40);
            defenseIVInputBox.Name = "defenseIVInputBox";
            defenseIVInputBox.PlaceholderText = "Defense IV";
            defenseIVInputBox.Size = new Size(100, 23);
            defenseIVInputBox.TabIndex = 27;
            // 
            // hpIVInputBox
            // 
            hpIVInputBox.Location = new Point(620, 40);
            hpIVInputBox.Name = "hpIVInputBox";
            hpIVInputBox.PlaceholderText = "HP IV";
            hpIVInputBox.Size = new Size(100, 23);
            hpIVInputBox.TabIndex = 26;
            // 
            // quickMoveInputBox
            // 
            quickMoveInputBox.Location = new Point(20, 95);
            quickMoveInputBox.Name = "quickMoveInputBox";
            quickMoveInputBox.PlaceholderText = "Quick Move";
            quickMoveInputBox.Size = new Size(100, 23);
            quickMoveInputBox.TabIndex = 25;
            // 
            // chargeMoveInputBox
            // 
            chargeMoveInputBox.Location = new Point(140, 95);
            chargeMoveInputBox.Name = "chargeMoveInputBox";
            chargeMoveInputBox.PlaceholderText = "Charge Move";
            chargeMoveInputBox.Size = new Size(100, 23);
            chargeMoveInputBox.TabIndex = 24;
            // 
            // chargeMove2InputBox
            // 
            chargeMove2InputBox.Location = new Point(260, 95);
            chargeMove2InputBox.Name = "chargeMove2InputBox";
            chargeMove2InputBox.PlaceholderText = "Charge Move 2";
            chargeMove2InputBox.Size = new Size(100, 23);
            chargeMove2InputBox.TabIndex = 23;
            // 
            // weightInputBox
            // 
            weightInputBox.Location = new Point(500, 95);
            weightInputBox.Name = "weightInputBox";
            weightInputBox.PlaceholderText = "Weight";
            weightInputBox.Size = new Size(100, 23);
            weightInputBox.TabIndex = 22;
            // 
            // heightInputBox
            // 
            heightInputBox.Location = new Point(620, 95);
            heightInputBox.Name = "heightInputBox";
            heightInputBox.PlaceholderText = "Height";
            heightInputBox.Size = new Size(100, 23);
            heightInputBox.TabIndex = 21;
            // 
            // nameInputBox
            // 
            nameInputBox.Location = new Point(20, 40);
            nameInputBox.Name = "nameInputBox";
            nameInputBox.PlaceholderText = "Name";
            nameInputBox.Size = new Size(100, 23);
            nameInputBox.TabIndex = 20;
            // 
            // mandatoryLabel
            // 
            mandatoryLabel.AutoSize = true;
            mandatoryLabel.Location = new Point(20, 20);
            mandatoryLabel.Name = "mandatoryLabel";
            mandatoryLabel.Size = new Size(96, 15);
            mandatoryLabel.TabIndex = 19;
            mandatoryLabel.Text = "Mandatory input";
            // 
            // EditRowWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 261);
            Controls.Add(levelInputBox);
            Controls.Add(hpInputBox);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            Controls.Add(genderDropdownList);
            Controls.Add(additionalLabel);
            Controls.Add(formInputBox);
            Controls.Add(cpInputBox);
            Controls.Add(attackIVInputBox);
            Controls.Add(defenseIVInputBox);
            Controls.Add(hpIVInputBox);
            Controls.Add(quickMoveInputBox);
            Controls.Add(chargeMoveInputBox);
            Controls.Add(chargeMove2InputBox);
            Controls.Add(weightInputBox);
            Controls.Add(heightInputBox);
            Controls.Add(nameInputBox);
            Controls.Add(mandatoryLabel);
            Name = "EditRowWindow";
            Text = "Edit an entry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox levelInputBox;
        private TextBox hpInputBox;
        private Button saveBtn;
        private Button cancelBtn;
        private ComboBox genderDropdownList;
        private Label additionalLabel;
        private TextBox formInputBox;
        private TextBox cpInputBox;
        private TextBox attackIVInputBox;
        private TextBox defenseIVInputBox;
        private TextBox hpIVInputBox;
        private TextBox quickMoveInputBox;
        private TextBox chargeMoveInputBox;
        private TextBox chargeMove2InputBox;
        private TextBox weightInputBox;
        private TextBox heightInputBox;
        private TextBox nameInputBox;
        private Label mandatoryLabel;
    }
}