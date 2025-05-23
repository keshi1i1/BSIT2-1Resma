using TTT_History;
using static System.Formats.Asn1.AsnWriter;

namespace TTT_DataLogic
{
    public class TTT_TextFileDataService : TTT_IDataService
    {
        string filePath = "PvPScoreHistory.txt";

        List<TTT_ScoreHistory> nameScores = new List<TTT_ScoreHistory>();
        
        public TTT_TextFileDataService()
        {
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                var names = parts[0].Split('-');

                var scores = parts[1].Split('-');
                int score1 = Convert.ToInt32(scores[0]);
                int score2 = Convert.ToInt32(scores[1]);

                nameScores.Add(new TTT_ScoreHistory
                {
                    Usernames = new string[] { names[0], names[1] },
                    Scores = new int[] { score1, score2 }
                });
            }
        }

        public List<TTT_ScoreHistory> GetScoreHistory()
        {
            return nameScores;
        }

        public void AddScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            var newLine = $"{scoreHistory.Usernames[0]}-{scoreHistory.Usernames[1]}|{scoreHistory.Scores[0]}-{scoreHistory.Scores[1]}\n";

            File.AppendAllText(filePath, newLine);
        }

        public void ClearScoreHistory()
        {
            File.WriteAllText(filePath, "");
        }
    }
}
