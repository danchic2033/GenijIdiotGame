using System.Text;

namespace GenijIdiotGame
{
    public class FileProvider
    {
        public static void Append(string fileName, string value)
        {
            var streamWriter = new StreamWriter(fileName, true, Encoding.UTF8);
            Console.WriteLine(value);
            streamWriter.Close();
        }

        public static string GetValue(string fileName)
        {
            var streamReader = new StreamReader(fileName, Encoding.UTF8);
            var value = streamReader.ReadToEnd();
            streamReader.Close();
            return value;
        }

        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        public static void Clear(string fileName)
        {
            File.WriteAllText(fileName, string.Empty);
        }
    }
}
