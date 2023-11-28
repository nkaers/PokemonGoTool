namespace PokemonGoTool
{
    partial class Form1
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
            openFile = new Button();
            openFileDialog = new OpenFileDialog();
            pokemonData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pokemonData).BeginInit();
            SuspendLayout();
            // 
            // filePath
            // 
            filePath.Location = new Point(10, 10);
            filePath.Name = "filePath";
            filePath.Size = new Size(800, 23);
            filePath.TabIndex = 0;
            // 
            // openFile
            // 
            openFile.Location = new Point(820, 10);
            openFile.Name = "openFile";
            openFile.Size = new Size(120, 25);
            openFile.TabIndex = 1;
            openFile.Text = "Open .csv file";
            openFile.UseVisualStyleBackColor = true;
            openFile.Click += openFile_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "dataFromCSV";
            // 
            // pokemonData
            // 
            pokemonData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pokemonData.Location = new Point(10, 40);
            pokemonData.Name = "pokemonData";
            pokemonData.RowTemplate.Height = 25;
            pokemonData.Size = new Size(930, 600);
            pokemonData.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(pokemonData);
            Controls.Add(openFile);
            Controls.Add(filePath);
            Name = "Form1";
            Text = "Pokemon Go Storage Manager";
            ((System.ComponentModel.ISupportInitialize)pokemonData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox filePath;
        private Button openFile;
        private OpenFileDialog openFileDialog;
        private DataGridView pokemonData;
    }
}