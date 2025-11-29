using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenijIdiotGame.Common;

namespace GenijIdiotGameWinFormsApp
{
    public partial class QuestionsForm : Form
    {
        public QuestionsForm()
        {
            InitializeComponent();
        }

        private void QuestionsForm_Load(object sender, EventArgs e)
        {
            questionsDataGridView.Rows.Clear();
            var question = QuestionsStorage.GetAll();
            for (int i = 0; i < question.Count; i++)
            {
                questionsDataGridView.Rows.Add(question[i].Text, question[i].Answer);
            }
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            var parsed = InputValidator.TryParseToNumber(newAnswerTextBox.Text, out int userAnswer, out string errorMessage);
            if (parsed)
            {
                var newQuestion = new Question(newQuestionTextBox.Text, int.Parse(newAnswerTextBox.Text));
                var questions = QuestionsStorage.GetAll();
                questions.Add(newQuestion);
                QuestionsStorage.Save(questions);
                QuestionsForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void closeQuestionForm_Click(object sender, EventArgs e)
        {
            var mainForm = new mainForm();
            mainForm.ShowDialog();
        }

        private void removeQuestionButton_Click(object sender, EventArgs e)
        {
            var questions = QuestionsStorage.GetAll();

            foreach (DataGridViewRow selectedRow in questionsDataGridView.SelectedRows)
            {
                string questionText = selectedRow.Cells[0].Value.ToString();
                string answerText = selectedRow.Cells[1].Value.ToString();

                var questionToRemove = questions.FirstOrDefault(q => q.Text == questionText && q.Answer.ToString() == answerText);
                if (questionToRemove != null)
                {
                    questions.Remove(questionToRemove);
                }
            }

            QuestionsStorage.Save(questions);

            QuestionsForm_Load(sender, e);
        }
    }
}
