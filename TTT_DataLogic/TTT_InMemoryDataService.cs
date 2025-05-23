using TTT_History;
using static System.Formats.Asn1.AsnWriter;

namespace TTT_DataLogic
{
    public class TTT_InMemoryDataService : TTT_IDataService
    {
        public static List<TTT_ScoreHistory> nameScores = new List<TTT_ScoreHistory>();

        public TTT_InMemoryDataService()
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

        public List<TTT_ScoreHistory> GetScoreHistory()
        {
            return nameScores;
        }

        public void AddScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            nameScores.Add(new TTT_ScoreHistory
            {
                Usernames = new string[] { scoreHistory.Usernames[0], scoreHistory.Usernames[1] },
                Scores = new int[] { scoreHistory.Scores[0], scoreHistory.Scores[1] }
            });
        }

        public void ClearScoreHistory()
        {
            GetScoreHistory().Clear();
        }
    }
}
