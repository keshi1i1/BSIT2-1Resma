using TTT_History;

namespace TTT_DataLogic
{
    public class TTT_OldInMemoryDataService
    {
        public static List<TTT_ScoreHistory> nameScores = new List<TTT_ScoreHistory>();

        public TTT_OldInMemoryDataService()
        {
            CreateDummyNamesAndScores();
        }

        public void CreateDummyNamesAndScores()
        {
            TTT_ScoreHistory nameScore1 = new TTT_ScoreHistory();
            nameScore1.Usernames = new string[] { "JES", "VON" };
            nameScore1.Scores = new int[] { 10, 2 };

            nameScores.Add(nameScore1);

            TTT_ScoreHistory nameScore2 = new TTT_ScoreHistory
            {
                Usernames = new string[] { "TER", "RES" },
                Scores = new int[] { 5, 5 }
            };

            nameScores.Add(nameScore2);

            nameScores.Add(new TTT_ScoreHistory
            {
                Usernames = new string[] { "KESH", "DUKE" },
                Scores = new int[] { 3, 6 }
            });
        }

        public void AddScoreHistory(string p1, string p2, int score1, int score2)
        {
            nameScores.Add(new TTT_ScoreHistory
            {
                Usernames = new string[] { p1, p2 },
                Scores = new int[] { score1, score2 }
            });
        }

        public void ClearScoreHistory()
        {
            nameScores.Clear();
        }
    }
}
