using System.Text;

namespace GenijIdiotGame
{
    public class UserResultStorage
    {
        public static void Save(User user)
        {
            string value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            FileProvider.Append("TestStats.txt", value);
        }

        public static List<User> GetUserResults()
        {
            var value = FileProvider.GetValue("TestStats.txt");
            var lines = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var results = new List<User>();
            foreach (var line in lines)
            {
                var values = line.Split('#');
                var userName = lines[0];
                var countRightAnswers = Convert.ToInt32(lines[1]);
                var diagnose = lines[2];

                var user = new User(userName);
                user.CountRightAnswers = countRightAnswers;
                user.Diagnose = diagnose;

                results.Add(user);
            }
            return results;
        }

    }
}
