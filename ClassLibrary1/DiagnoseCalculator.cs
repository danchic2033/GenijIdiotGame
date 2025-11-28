namespace GenijIdiotGame.Common
{
    public class DiagnoseCalculator
    {
        public static string GetUserDiagnose(double percent)
        {
            var diagnosis = GetDiagnosis();
            return diagnosis[(int)percent / 20];
        }
        public static double Calculate(int countRightAnswers, int countQuestion)
        {
            return (double)countRightAnswers / countQuestion * 100;
        }
        public static string[] GetDiagnosis()
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
    }
}
