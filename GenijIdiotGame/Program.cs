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
            var questions = QuestionsStorage.GetAll();
            var countQuestion = questions.Count;
            var endGame = true;

            while (endGame)
            {
                Random random = new Random();

                for (int i = 0; i < countQuestion; i++)
                {
                    Console.WriteLine($"Вопрос №{i + 1}");

                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex].Text);
                    var userAnswer = GetNumber();

                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                        user.AcceptRightAnswers();
                    questions.RemoveAt(randomQuestionIndex);
                }

                var percentRightAnswers = CalculateDiagnose(user.CountRightAnswers, countQuestion);
                var userDiagnose = GetUserDiagnose(percentRightAnswers);
                user.Diagnose = userDiagnose;

                Console.WriteLine($"{userName}, ваш диагноз: {userDiagnose}");

                UserResultStorage.Save(user);

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

                endGame = GetUserChoiceEndGame();
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

        private static int GetNumber()
        {
            string userAnswer = Console.ReadLine();
            while (true)
            {
                try
                {
                    int answer = int.Parse(userAnswer);
                    return answer;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Введите число");
                    userAnswer = Console.ReadLine();
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Число очень большое. Введите число в диапазоне от -2 147 483 648 до 2 147 483 647");
                    userAnswer = Console.ReadLine();
                }
            }
        }

        static bool GetUserChoiceEndGame()
        {
            Console.WriteLine("Хотите повторить тест? да или нет");
            string userChoice = Console.ReadLine();
            if (userChoice.ToLower() == "нет")
                return false;
            else
                return true;
        }
        private static string[] GetDiagnosis()
        {
            string[] diagnosis = new string[6];
            diagnosis[0] = "Идиот";
            diagnosis[1] = "Кретин";
            diagnosis[2] = "Дурак";
            diagnosis[3] = "Нормальный";
            diagnosis[4] = "Талант";
            diagnosis[5] = "Гений";
            return diagnosis;
        }
        static string GetUserDiagnose(double percent)
        {
            var diagnosis = GetDiagnosis();
            return diagnosis[(int)percent / 20];
        }
        static double CalculateDiagnose(int countRightAnswers, int countQuestion)
        {
            return ((double)countRightAnswers / countQuestion) * 100;
        }
    }
}
