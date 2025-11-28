using GenijIdiotGame.Common;
using System.IO;

namespace GenijIdiotGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            var userName = Console.ReadLine();

            var user = new User(userName);
            var game = new Game(user);

            while (!game.End())
            {
                var currentQuestion = game.GetNextQuestion();

                Console.WriteLine(game.GetQuestionNumberText());

                Console.WriteLine(currentQuestion.Text);
                var userAnswer = GetNumber();

                game.AcceptAnswer(userAnswer);

                var message = game.CalculateDiagnose();

                Console.WriteLine(message);

                Console.WriteLine("Хотите посмотреть статистику прошлых игр?");
                var userChoice = Console.ReadLine();
                if (userChoice.ToLower() == "да")
                {
                    ShowUserResults();
                }
                Console.WriteLine("Хотите добавить вопрос?");
                userChoice = Console.ReadLine();
                if (userChoice.ToLower() == "да")
                {
                    AddNewQuestion();
                }
                Console.WriteLine("Хотите удалить существующий вопрос?");
                userChoice = Console.ReadLine();
                if (userChoice.ToLower() == "да")
                {
                    RemoveQuestion();
                }
            }
        }

        static void RemoveQuestion()
        {
            Console.WriteLine("Введите номер удаляемого вопроса");
            var questions = QuestionsStorage.GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i].Text}");
            }
            var removeQuestionNumber = GetNumber();
            while (removeQuestionNumber < 1 || removeQuestionNumber > questions.Count)
            {
                Console.WriteLine($"Введите число от 1 до {questions.Count}");
                removeQuestionNumber = GetNumber();
            }
            var removeQuestion = questions[removeQuestionNumber - 1];
            QuestionsStorage.Remove(removeQuestion);
        }

        static void AddNewQuestion()
        {
            Console.WriteLine("Введите текст вопроса");
            var text = Console.ReadLine();
            Console.WriteLine("Введите ответ");
            var answer = GetNumber();

            var newQuestion = new Question(text, answer);
            QuestionsStorage.Add(newQuestion);
        }

        public static void ShowUserResults()
        {
            var results = UserResultStorage.GetUserResults();
            Console.WriteLine("{0,-10} || {1,-10} || {2,-10}", "Имя", "Баллы", "Диагноз");
            foreach (var user in results)
            {
                Console.WriteLine("{0,-10} || {1,-10} || {2,-10}", user.Name, user.CountRightAnswers, user.Diagnose);
            }
        }

        public static int GetNumber()
        {
            int number;
            string userAnswer = Console.ReadLine();
            while (!InputValidator.TryParseToNumber(userAnswer, out number, out string errorMessage))
            {
                Console.WriteLine(errorMessage);
            }
            return number;
        }

        public static bool GetUserChoiceEndGame()
        {
            Console.WriteLine("Хотите повторить тест? да или нет");
            string userChoice = Console.ReadLine();
            if (userChoice.ToLower() == "нет")
                return false;
            else
                return true;
        }
    }
}
