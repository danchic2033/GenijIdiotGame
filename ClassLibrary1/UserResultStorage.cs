using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace GenijIdiotGame.Common
{
    public class UserResultStorage
    {
        public static void Save(User user)
        {
            var userResults = GetAll();
            userResults.Add(user);
            Save(userResults);
        }

        public static List<User> GetAll()
        {
            if (!FileProvider.Exists("TestStats.json"))
            {
                return new List<User>();
            }
            var value = FileProvider.GetValue("TestStats.json");
            var userResults = JsonConvert.DeserializeObject<List<User>>(value);
            return userResults;
        }

        static void Save(List<User> usersResults)
        {
            var jsonData = JsonConvert.SerializeObject(usersResults, Formatting.Indented);
            FileProvider.Replace("TestStats.json", jsonData);
        }

    }
}
