namespace PokemonGoTool
{
    partial class AddRowWindow
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
            mandatoryLabel = new Label();
            nameInputBox = new TextBox();
            heightInputBox = new TextBox();
            weightInputBox = new TextBox();
            chargeMove2InputBox = new TextBox();
            chargeMoveInputBox = new TextBox();
            quickMoveInputBox = new TextBox();
            hpIVInputBox = new TextBox();
            defenseIVInputBox = new TextBox();
            attackIVInputBox = new TextBox();
            cpInputBox = new TextBox();
            formInputBox = new TextBox();
            label1 = new Label();
            genderDropdownList = new ComboBox();
            cancelBtn = new Button();
            addBtn = new Button();
            hpInputBox = new TextBox();
            levelInputBox = new TextBox();
            SuspendLayout();
            // 
            // mandatoryLabel
            // 
            mandatoryLabel.AutoSize = true;
            mandatoryLabel.Location = new Point(20, 20);
            mandatoryLabel.Name = "mandatoryLabel";
            mandatoryLabel.Size = new Size(96, 15);
            mandatoryLabel.TabIndex = 0;
            mandatoryLabel.Text = "Mandatory input";
            // 
            // nameInputBox
            // 
            nameInputBox.Location = new Point(20, 40);
            nameInputBox.Name = "nameInputBox";
            nameInputBox.PlaceholderText = "Name";
            nameInputBox.Size = new Size(100, 23);
            nameInputBox.TabIndex = 1;
            // 
            // heightInputBox
            // 
            heightInputBox.Location = new Point(620, 95);
            heightInputBox.Name = "heightInputBox";
            heightInputBox.PlaceholderText = "Height";
            heightInputBox.Size = new Size(100, 23);
            heightInputBox.TabIndex = 2;
            // 
            // weightInputBox
            // 
            weightInputBox.Location = new Point(500, 95);
            weightInputBox.Name = "weightInputBox";
            weightInputBox.PlaceholderText = "Weight";
            weightInputBox.Size = new Size(100, 23);
            weightInputBox.TabIndex = 3;
            // 
            // chargeMove2InputBox
            // 
            chargeMove2InputBox.Location = new Point(260, 95);
            chargeMove2InputBox.Name = "chargeMove2InputBox";
            chargeMove2InputBox.PlaceholderText = "Charge Move 2";
            chargeMove2InputBox.Size = new Size(100, 23);
            chargeMove2InputBox.TabIndex = 4;
            // 
            // chargeMoveInputBox
            // 
            chargeMoveInputBox.Location = new Point(140, 95);
            chargeMoveInputBox.Name = "chargeMoveInputBox";
            chargeMoveInputBox.PlaceholderText = "Charge Move";
            chargeMoveInputBox.Size = new Size(100, 23);
            chargeMoveInputBox.TabIndex = 6;
            // 
            // quickMoveInputBox
            // 
            quickMoveInputBox.Location = new Point(20, 95);
            quickMoveInputBox.Name = "quickMoveInputBox";
            quickMoveInputBox.PlaceholderText = "Quick Move";
            quickMoveInputBox.Size = new Size(100, 23);
            quickMoveInputBox.TabIndex = 7;
            // 
            // hpIVInputBox
            // 
            hpIVInputBox.Location = new Point(620, 40);
            hpIVInputBox.Name = "hpIVInputBox";
            hpIVInputBox.PlaceholderText = "HP IV";
            hpIVInputBox.Size = new Size(100, 23);
            hpIVInputBox.TabIndex = 8;
            // 
            // defenseIVInputBox
            // 
            defenseIVInputBox.Location = new Point(500, 40);
            defenseIVInputBox.Name = "defenseIVInputBox";
            defenseIVInputBox.PlaceholderText = "Defense IV";
            defenseIVInputBox.Size = new Size(100, 23);
            defenseIVInputBox.TabIndex = 9;
            // 
            // attackIVInputBox
            // 
            attackIVInputBox.Location = new Point(380, 40);
            attackIVInputBox.Name = "attackIVInputBox";
            attackIVInputBox.PlaceholderText = "Attack IV";
            attackIVInputBox.Size = new Size(100, 23);
            attackIVInputBox.TabIndex = 10;
            // 
            // cpInputBox
            // 
            cpInputBox.Location = new Point(260, 40);
            cpInputBox.Name = "cpInputBox";
            cpInputBox.PlaceholderText = "CP";
            cpInputBox.Size = new Size(100, 23);
            cpInputBox.TabIndex = 11;
            // 
            // formInputBox
            // 
            formInputBox.Location = new Point(140, 40);
            formInputBox.Name = "formInputBox";
            formInputBox.PlaceholderText = "Form";
            formInputBox.Size = new Size(100, 23);
            formInputBox.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 75);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 13;
            label1.Text = "Additional Information";
            // 
            // genderDropdownList
            // 
            genderDropdownList.DropDownStyle = ComboBoxStyle.DropDownList;
            genderDropdownList.FormattingEnabled = true;
            genderDropdownList.Items.AddRange(new object[] { "Male", "Female", "Genderless" });
            genderDropdownList.Location = new Point(380, 95);
            genderDropdownList.Name = "genderDropdownList";
            genderDropdownList.Size = new Size(100, 23);
            genderDropdownList.TabIndex = 14;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(300, 200);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 15;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(400, 200);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 16;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // hpInputBox
            // 
            hpInputBox.Location = new Point(20, 130);
            hpInputBox.Name = "hpInputBox";
            hpInputBox.PlaceholderText = "HP";
            hpInputBox.Size = new Size(100, 23);
            hpInputBox.TabIndex = 17;
            // 
            // levelInputBox
            // 
            levelInputBox.Location = new Point(140, 130);
            levelInputBox.Name = "levelInputBox";
            levelInputBox.PlaceholderText = "Level";
            levelInputBox.Size = new Size(100, 23);
            levelInputBox.TabIndex = 18;
            // 
            // AddRowWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 261);
            Controls.Add(levelInputBox);
            Controls.Add(hpInputBox);
            Controls.Add(addBtn);
            Controls.Add(cancelBtn);
            Controls.Add(genderDropdownList);
            Controls.Add(label1);
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
            Name = "AddRowWindow";
            Text = "Add an entry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label mandatoryLabel;
        private TextBox nameInputBox;
        private TextBox heightInputBox;
        private TextBox weightInputBox;
        private TextBox chargeMove2InputBox;
        private TextBox chargeMoveInputBox;
        private TextBox quickMoveInputBox;
        private TextBox hpIVInputBox;
        private TextBox defenseIVInputBox;
        private TextBox attackIVInputBox;
        private TextBox cpInputBox;
        private TextBox formInputBox;
        private Label label1;
        private ComboBox genderDropdownList;
        private ComboBox comboBox1;
        private Button cancelBtn;
        private Button addBtn;
        private TextBox hpInputBox;
        private TextBox levelInputBox;
    }
}