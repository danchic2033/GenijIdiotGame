namespace GenijIdiotGameWinFormsApp
{
    partial class QuestionsForm
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
            questionsDataGridView = new DataGridView();
            questionsColimt = new DataGridViewTextBoxColumn();
            answersColumn = new DataGridViewTextBoxColumn();
            newQuestionLabel = new Label();
            newQuestionTextBox = new TextBox();
            newAnswerTextBox = new TextBox();
            addQuestionButton = new Button();
            closeQuestionForm = new Button();
            newQuestionTextLabel = new Label();
            answerTextLabel = new Label();
            removeQuestionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)questionsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // questionsDataGridView
            // 
            questionsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            questionsDataGridView.Columns.AddRange(new DataGridViewColumn[] { questionsColimt, answersColumn });
            questionsDataGridView.Location = new Point(12, 12);
            questionsDataGridView.Name = "questionsDataGridView";
            questionsDataGridView.Size = new Size(776, 342);
            questionsDataGridView.TabIndex = 0;
            // 
            // questionsColimt
            // 
            questionsColimt.HeaderText = "Вопросы";
            questionsColimt.Name = "questionsColimt";
            // 
            // answersColumn
            // 
            answersColumn.HeaderText = "Ответы";
            answersColumn.Name = "answersColumn";
            // 
            // newQuestionLabel
            // 
            newQuestionLabel.AutoSize = true;
            newQuestionLabel.Location = new Point(22, 367);
            newQuestionLabel.Name = "newQuestionLabel";
            newQuestionLabel.Size = new Size(238, 15);
            newQuestionLabel.TabIndex = 1;
            newQuestionLabel.Text = "Для добавления вопроса заполните поля:";
            // 
            // newQuestionTextBox
            // 
            newQuestionTextBox.Location = new Point(99, 401);
            newQuestionTextBox.Name = "newQuestionTextBox";
            newQuestionTextBox.Size = new Size(323, 23);
            newQuestionTextBox.TabIndex = 2;
            // 
            // newAnswerTextBox
            // 
            newAnswerTextBox.Location = new Point(472, 402);
            newAnswerTextBox.Name = "newAnswerTextBox";
            newAnswerTextBox.Size = new Size(100, 23);
            newAnswerTextBox.TabIndex = 3;
            // 
            // addQuestionButton
            // 
            addQuestionButton.Location = new Point(589, 404);
            addQuestionButton.Name = "addQuestionButton";
            addQuestionButton.Size = new Size(75, 23);
            addQuestionButton.TabIndex = 4;
            addQuestionButton.Text = "Добавить";
            addQuestionButton.UseVisualStyleBackColor = true;
            addQuestionButton.Click += addQuestionButton_Click;
            // 
            // closeQuestionForm
            // 
            closeQuestionForm.Location = new Point(692, 404);
            closeQuestionForm.Name = "closeQuestionForm";
            closeQuestionForm.Size = new Size(75, 23);
            closeQuestionForm.TabIndex = 5;
            closeQuestionForm.Text = "Закрыть";
            closeQuestionForm.UseVisualStyleBackColor = true;
            closeQuestionForm.Click += closeQuestionForm_Click;
            // 
            // newQuestionTextLabel
            // 
            newQuestionTextLabel.AutoSize = true;
            newQuestionTextLabel.Location = new Point(12, 404);
            newQuestionTextLabel.Name = "newQuestionTextLabel";
            newQuestionTextLabel.Size = new Size(81, 15);
            newQuestionTextLabel.TabIndex = 6;
            newQuestionTextLabel.Text = "Введите текст";
            // 
            // answerTextLabel
            // 
            answerTextLabel.AutoSize = true;
            answerTextLabel.Location = new Point(428, 405);
            answerTextLabel.Name = "answerTextLabel";
            answerTextLabel.Size = new Size(38, 15);
            answerTextLabel.TabIndex = 7;
            answerTextLabel.Text = "Ответ";
            // 
            // removeQuestionButton
            // 
            removeQuestionButton.Location = new Point(692, 367);
            removeQuestionButton.Name = "removeQuestionButton";
            removeQuestionButton.Size = new Size(75, 23);
            removeQuestionButton.TabIndex = 8;
            removeQuestionButton.Text = "Удалить";
            removeQuestionButton.UseVisualStyleBackColor = true;
            removeQuestionButton.Click += removeQuestionButton_Click;
            // 
            // QuestionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(removeQuestionButton);
            Controls.Add(answerTextLabel);
            Controls.Add(newQuestionTextLabel);
            Controls.Add(closeQuestionForm);
            Controls.Add(addQuestionButton);
            Controls.Add(newAnswerTextBox);
            Controls.Add(newQuestionTextBox);
            Controls.Add(newQuestionLabel);
            Controls.Add(questionsDataGridView);
            Name = "QuestionsForm";
            Text = "QuestionsForm";
            Load += QuestionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)questionsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView questionsDataGridView;
        private DataGridViewTextBoxColumn questionsColimt;
        private DataGridViewTextBoxColumn answersColumn;
        private Label newQuestionLabel;
        private TextBox newQuestionTextBox;
        private TextBox newAnswerTextBox;
        private Button addQuestionButton;
        private Button closeQuestionForm;
        private Label newQuestionTextLabel;
        private Label answerTextLabel;
        private Button removeQuestionButton;
    }
}