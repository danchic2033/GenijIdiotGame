namespace GenijIdiotGameWinFormsApp
{
    partial class ResultsForm
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
            resultsDataGridView = new DataGridView();
            userNameColumn = new DataGridViewTextBoxColumn();
            countRightAnswersColumn = new DataGridViewTextBoxColumn();
            diagnoseColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Columns.AddRange(new DataGridViewColumn[] { userNameColumn, countRightAnswersColumn, diagnoseColumn });
            resultsDataGridView.Location = new Point(29, 33);
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.Size = new Size(338, 246);
            resultsDataGridView.TabIndex = 0;
            // 
            // userNameColumn
            // 
            userNameColumn.HeaderText = "Имя";
            userNameColumn.Name = "userNameColumn";
            // 
            // countRightAnswersColumn
            // 
            countRightAnswersColumn.HeaderText = "Баллы";
            countRightAnswersColumn.Name = "countRightAnswersColumn";
            // 
            // diagnoseColumn
            // 
            diagnoseColumn.HeaderText = "Диагноз";
            diagnoseColumn.Name = "diagnoseColumn";
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resultsDataGridView);
            Name = "ResultsForm";
            Text = "ResultsForm";
            Load += ResultsForm_Load;
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView resultsDataGridView;
        private DataGridViewTextBoxColumn userNameColumn;
        private DataGridViewTextBoxColumn countRightAnswersColumn;
        private DataGridViewTextBoxColumn diagnoseColumn;
    }
}