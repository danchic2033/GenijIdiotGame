
namespace GenijIdiotGame.Common
{
    public class QuestionsStorage
    {
        public static List<Question> GetAll()
        {
            var questions = new List<Question>();
            if (FileProvider.Exists("Questions.txt"))
            {
                var value = FileProvider.GetValue("Questions.txt");
                var lines = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var values = line.Split('#');
                    var text = lines[0];
                    var answer = Convert.ToInt32(lines[1]);

                    var question = new Question(text, answer);

                    questions.Add(question);
                }
            }
            else
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса, сколько нужно минут на 3 укола?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось гореть?", 2));
                SaveQuestions(questions);
            }
            return questions;
        }

        public static void SaveQuestions(List<Question> questions)
        {
            foreach (var question in questions)
            {
                Add(question);
            }
        }

        public static void Add(Question newQuestion)
        {
            string value = $"{newQuestion.Text}#{newQuestion.Answer}";
            FileProvider.Append("Questions.txt", value);
        }

        public static void Remove(Question removeQuestion)
        {
            var questions = GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == removeQuestion.Text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }
            FileProvider.Clear("Questions.txt");
            SaveQuestions(questions);
        }
    }
}
