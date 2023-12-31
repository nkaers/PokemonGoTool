﻿namespace PokemonGoTool
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            filePath = new TextBox();
            openFileBtn = new Button();
            openFileDialog = new OpenFileDialog();
            pokemonData = new DataGridView();
            addRowBtn = new Button();
            deleteSelectedRowsBtn = new Button();
            saveToCSVBtn = new Button();
            editRowBtn = new Button();
            saveFileDialog = new SaveFileDialog();
            debugText = new Label();
            createTableBtn = new Button();
            dataTableModeDropDownList = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pokemonData).BeginInit();
            SuspendLayout();
            // 
            // filePath
            // 
            filePath.Location = new Point(10, 10);
            filePath.Name = "filePath";
            filePath.PlaceholderText = "File Path to the data table source";
            filePath.Size = new Size(1400, 23);
            filePath.TabIndex = 0;
            // 
            // openFileBtn
            // 
            openFileBtn.Location = new Point(1420, 10);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(150, 25);
            openFileBtn.TabIndex = 1;
            openFileBtn.Text = "Open .csv file";
            openFileBtn.UseVisualStyleBackColor = true;
            openFileBtn.Click += openFile_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "dataFromCSV";
            // 
            // pokemonData
            // 
            pokemonData.AllowUserToAddRows = false;
            pokemonData.AllowUserToDeleteRows = false;
            pokemonData.AllowUserToOrderColumns = true;
            pokemonData.AllowUserToResizeRows = false;
            pokemonData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pokemonData.EditMode = DataGridViewEditMode.EditProgrammatically;
            pokemonData.Location = new Point(10, 40);
            pokemonData.Name = "pokemonData";
            pokemonData.ReadOnly = true;
            pokemonData.RowTemplate.Height = 25;
            pokemonData.Size = new Size(1400, 800);
            pokemonData.TabIndex = 2;
            pokemonData.VirtualMode = true;
            // 
            // addRowBtn
            // 
            addRowBtn.Location = new Point(1420, 70);
            addRowBtn.Name = "addRowBtn";
            addRowBtn.Size = new Size(150, 25);
            addRowBtn.TabIndex = 3;
            addRowBtn.Text = "Add a row";
            addRowBtn.UseVisualStyleBackColor = true;
            addRowBtn.Click += addRowBtn_Click;
            // 
            // deleteSelectedRowsBtn
            // 
            deleteSelectedRowsBtn.Location = new Point(1420, 130);
            deleteSelectedRowsBtn.Name = "deleteSelectedRowsBtn";
            deleteSelectedRowsBtn.Size = new Size(150, 25);
            deleteSelectedRowsBtn.TabIndex = 4;
            deleteSelectedRowsBtn.Text = "Delete selected rows";
            deleteSelectedRowsBtn.UseVisualStyleBackColor = true;
            deleteSelectedRowsBtn.Click += deleteSelectedRowsBtn_Click;
            // 
            // saveToCSVBtn
            // 
            saveToCSVBtn.Location = new Point(1420, 160);
            saveToCSVBtn.Name = "saveToCSVBtn";
            saveToCSVBtn.Size = new Size(150, 25);
            saveToCSVBtn.TabIndex = 5;
            saveToCSVBtn.Text = "Save to CSV";
            saveToCSVBtn.UseVisualStyleBackColor = true;
            saveToCSVBtn.Click += saveToCSVBtn_Click;
            // 
            // editRowBtn
            // 
            editRowBtn.Location = new Point(1420, 100);
            editRowBtn.Name = "editRowBtn";
            editRowBtn.Size = new Size(150, 25);
            editRowBtn.TabIndex = 6;
            editRowBtn.Text = "Edit row";
            editRowBtn.UseVisualStyleBackColor = true;
            editRowBtn.Click += editRowBtn_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.FileName = "pokemon";
            saveFileDialog.Filter = "\"CSV file (*.csv)|*.csv\"";
            // 
            // debugText
            // 
            debugText.AutoSize = true;
            debugText.Location = new Point(1420, 500);
            debugText.Name = "debugText";
            debugText.Size = new Size(66, 15);
            debugText.TabIndex = 7;
            debugText.Text = "Debug Text";
            // 
            // createTableBtn
            // 
            createTableBtn.Location = new Point(1420, 40);
            createTableBtn.Name = "createTableBtn";
            createTableBtn.Size = new Size(150, 25);
            createTableBtn.TabIndex = 8;
            createTableBtn.Text = "Create a new table";
            createTableBtn.UseVisualStyleBackColor = true;
            createTableBtn.Click += createTableBtn_Click;
            // 
            // dataTableModeDropDownList
            // 
            dataTableModeDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
            dataTableModeDropDownList.FormattingEnabled = true;
            dataTableModeDropDownList.Items.AddRange(new object[] { "Beginner", "Advanced", "Expert" });
            dataTableModeDropDownList.Location = new Point(1420, 190);
            dataTableModeDropDownList.Name = "dataTableModeDropDownList";
            dataTableModeDropDownList.Size = new Size(150, 23);
            dataTableModeDropDownList.TabIndex = 33;
            dataTableModeDropDownList.SelectedIndexChanged += dataTableModeDropDownList_SelectedIndexChanged;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(dataTableModeDropDownList);
            Controls.Add(createTableBtn);
            Controls.Add(debugText);
            Controls.Add(editRowBtn);
            Controls.Add(saveToCSVBtn);
            Controls.Add(deleteSelectedRowsBtn);
            Controls.Add(addRowBtn);
            Controls.Add(pokemonData);
            Controls.Add(openFileBtn);
            Controls.Add(filePath);
            Name = "MainWindow";
            Text = "Pokemon Go Storage Manager";
            ((System.ComponentModel.ISupportInitialize)pokemonData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox filePath;
        private Button openFileBtn;
        private OpenFileDialog openFileDialog;
        private DataGridView pokemonData;
        private Button addRowBtn;
        private Button deleteSelectedRowsBtn;
        private Button saveToCSVBtn;
        private Button editRowBtn;
        private SaveFileDialog saveFileDialog;
        private Label debugText;
        private Button createTableBtn;
        private ComboBox dataTableModeDropDownList;
    }
}