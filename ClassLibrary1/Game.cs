using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijIdiotGame.Common
{
    public class Game
    {
        User user;
        List<Question> questions;
        Question currentQuestion;
        int countQuestions;
        int questionNumber = 0;

        public Game(User user)
        {
            this.user = user;
            questions = QuestionsStorage.GetAll();
            countQuestions = questions.Count;
        }

        public Question GetNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questionNumber++;
            return currentQuestion;
        }
        public string GetQuestionNumberText()
        {
            return $"Вопрос №{questionNumber}";
        }

        public void AcceptAnswer(int userAnswer)
        {
            var rightAnswer = currentQuestion.Answer;

            if (userAnswer == rightAnswer)
                user.AcceptRightAnswers();
            questions.Remove(currentQuestion);
        }

        public bool End()
        {
            return questions.Count == 0;
        }

        public string CalculateDiagnose()
        {
            var percentRightAnswers = DiagnoseCalculator.Calculate(user.CountRightAnswers, countQuestions);
            var userDiagnose = DiagnoseCalculator.GetUserDiagnose(percentRightAnswers);
            user.Diagnose = userDiagnose;
            UserResultStorage.Save(user);
            return $"{user.Name}, ваш диагноз {user.Diagnose}";
        }
    }
}
