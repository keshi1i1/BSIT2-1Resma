using TTT_History;
using static System.Formats.Asn1.AsnWriter;

namespace TTT_DataLogic
{
    public class TTT_InMemoryDataService : TTT_IDataService
    {
        public List<TTT_ScoreHistory> pvpNameScores = new List<TTT_ScoreHistory>();

        public List<TTT_ScoreHistory> pveNameScores = new List<TTT_ScoreHistory>();

        public TTT_InMemoryDataService()
        {
            CreateDummyNamesAndScores();
        }

        public void CreateDummyNamesAndScores()
        {
            TTT_ScoreHistory nameScore1 = new TTT_ScoreHistory();
            nameScore1.Usernames = new string[] { "JES", "VON" };
            nameScore1.Scores = new int[] { 10, 2 };

            pvpNameScores.Add(nameScore1);

            TTT_ScoreHistory nameScore2 = new TTT_ScoreHistory
            {
                Usernames = new string[] { "TER", "RES" },
                Scores = new int[] { 5, 5 }
            };

            pvpNameScores.Add(nameScore2);

            pveNameScores.Add(new TTT_ScoreHistory
            {
                Usernames = new string[] { "KESH", "HARD" },
                Scores = new int[] { 0, 6 }
            });
        }

        public List<TTT_ScoreHistory> GetPvPScoreHistory()
        {
            return pvpNameScores;
        }

        public List<TTT_ScoreHistory> GetPvEScoreHistory()
        {
            return pveNameScores;
        }

        public void AddPvPScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            pvpNameScores.Add(new TTT_ScoreHistory
            {
                Usernames = new string[] { scoreHistory.Usernames[0], scoreHistory.Usernames[1] },
                Scores = new int[] { scoreHistory.Scores[0], scoreHistory.Scores[1] }
            });
        }

        public void AddPvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            pveNameScores.Add(new TTT_ScoreHistory
            {
                Usernames = new string[] { scoreHistory.Usernames[0], scoreHistory.Usernames[1] },
                Scores = new int[] { scoreHistory.Scores[0], scoreHistory.Scores[1] }
            });
        }

        public void UpdatePvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            foreach (var nameScores in GetPvEScoreHistory())
            {
                if (nameScores.Usernames[0] == scoreHistory.Usernames[0])
                {
                    nameScores.Scores[0] = scoreHistory.Scores[0];
                    nameScores.Scores[1] = scoreHistory.Scores[1];
                }
            }
        }

        public void UpdateDifficulty(TTT_ScoreHistory scoreHistory)
        {
            foreach (var nameScores in GetPvEScoreHistory())
            {
                if (nameScores.Usernames[0] == scoreHistory.Usernames[0])
                {
                    nameScores.Usernames[1] = scoreHistory.Usernames[1];
                    nameScores.Scores[0] = scoreHistory.Scores[0];
                    nameScores.Scores[1] = scoreHistory.Scores[1];
                }
            }
        }

        public void UpdateUsername(TTT_ScoreHistory scoreHistory, string newUsername)
        {
            foreach (var nameScores in GetPvEScoreHistory())
            {
                if (nameScores.Usernames[0] == scoreHistory.Usernames[0])
                {
                    nameScores.Usernames[0] = newUsername;
                }
            }
        }

        public void RemoveParticularPvP(TTT_ScoreHistory scoreHistory)
        {
            pvpNameScores.Remove(scoreHistory);
        }

        public void RemoveParticularPvE(TTT_ScoreHistory scoreHistory)
        {
            pveNameScores.Remove(scoreHistory);
        }

        public void ClearPvPScoreHistory()
        {
            GetPvPScoreHistory().Clear();
        }

        public void ClearPvEScoreHistory()
        {
            GetPvEScoreHistory().Clear();
        }
    }
}
