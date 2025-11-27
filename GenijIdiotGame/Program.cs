using System.IO;
using System.Text;

namespace GenijIdiotGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            var userName = Console.ReadLine();

            var questions = GetQuestions();
            var answers = GetAnswers();
            var countQuestion = questions.Count;
            var endGame = true;

            var countRightAnswer = 0;
            while (endGame)
            {
                Random random = new Random();

                for (int i = 0; i < countQuestion; i++)
                {
                    Console.WriteLine($"Вопрос №{i + 1}");

                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex]);
                    var userAnswer = CheckUserAnswer();

                    var rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                        countRightAnswer++;
                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }

                var percentRightAnswers = CalculateDiagnose(countRightAnswer, countQuestion);
                var userDiagnose = GetUserDiagnose(percentRightAnswers);

                Console.WriteLine($"{userName}, ваш диагноз: {userDiagnose}");
                SaveTestStats(userName, countRightAnswer, userDiagnose);
                ShowTestStats();
                endGame = GetUserChoiceEndGame();
            }
        }

        public static void SaveTestStats(string userName, int countRightAnswers, string userDiagnose)
        {
            string path = "TestStats.txt";
            string value = $"{userName}#{countRightAnswers}#{userDiagnose}";
            AppendToFile(path, value);
        }

        static void AppendToFile(string fileName, string value)
        {
            StreamWriter streamWriter = new StreamWriter(fileName, true, Encoding.UTF8);
            Console.WriteLine(value);
            streamWriter.Close();
        }

        public static void ShowTestStats()
        {
            string path = "TestStats.txt";
            Console.WriteLine("Хотите посмотреть статистику прошлых игр?");
            string userChoice = Console.ReadLine();
            if (userChoice.ToLower() == "нет")
                return;
            using (StreamReader streamReader = new StreamReader(path))
            {
                Console.WriteLine("{0,-10} || {1,-10} || {2,-10}", "Имя", "Баллы", "Диагноз");
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] lines = line.Split('#');
                    string userName = lines[0];
                    string countRightAnswers = lines[1];
                    string diagnose = lines[2];

                    Console.WriteLine("{0,-10} || {1,-10} || {2,-10}", userName, countRightAnswers, diagnose);
                }
            }
        }

        private static int CheckUserAnswer()
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

        private static List<int> GetAnswers()
        {
            List<int> answers = new List<int>();
            answers.Add(6);
            answers.Add(9);
            answers.Add(25);
            answers.Add(60);
            answers.Add(2);
            return answers;
        }

        public static List<string> GetQuestions()
        {
            List<string> questions = new List<string>();
            questions.Add("Сколько будет два плюс два умноженное на два?");
            questions.Add("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?");
            questions.Add("На двух руках 10 пальцев. Сколько пальцев на 5 руках?");
            questions.Add("Укол делают каждые полчаса, сколько нужно минут на 3 укола?");
            questions.Add("Пять свечей горело, две потухли. Сколько свечей осталось гореть?");
            return questions;
        }
    }
}
