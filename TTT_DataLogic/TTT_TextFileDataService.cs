using System;
using TTT_History;
using static System.Formats.Asn1.AsnWriter;

namespace TTT_DataLogic
{
    public class TTT_TextFileDataService : TTT_IDataService
    {
        string pvpFilePath = "PvPScoreHistory.txt";

        string pveFilePath = "PvEScoreHistory.txt";

        List<TTT_ScoreHistory> pvpNameScores = new List<TTT_ScoreHistory>();

        List<TTT_ScoreHistory> pveNameScores = new List<TTT_ScoreHistory>();

        public TTT_TextFileDataService()
        {
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            var pvpLines = File.ReadAllLines(pvpFilePath);

            var pveLines = File.ReadAllLines(pveFilePath);

            foreach (var line in pvpLines)
            {
                var parts = line.Split('|');

                var names = parts[0].Split('-');

                var scores = parts[1].Split('-');
                int score1 = Convert.ToInt32(scores[0]);
                int score2 = Convert.ToInt32(scores[1]);

                pvpNameScores.Add(new TTT_ScoreHistory
                {
                    Usernames = new string[] { names[0], names[1] },
                    Scores = new int[] { score1, score2 }
                });
            }

            foreach (var line in pveLines)
            {
                var parts = line.Split('|');

                var names = parts[0].Split('-');

                var scores = parts[1].Split('-');
                int score1 = Convert.ToInt32(scores[0]);
                int score2 = Convert.ToInt32(scores[1]);

                pveNameScores.Add(new TTT_ScoreHistory
                {
                    Usernames = new string[] { names[0], names[1] },
                    Scores = new int[] { score1, score2 }
                });
            }
        }
        public void UpdateTextFiles()
        {
            var lines = new string[pvpNameScores.Count];

            for (int i = 0; i < pvpNameScores.Count; i++)
            {
                lines[i] = $"{pvpNameScores[i].Usernames[0]}-{pvpNameScores[i].Usernames[1]}|{pvpNameScores[i].Scores[0]}-{pvpNameScores[i].Scores[1]}\n";
            }
            File.WriteAllLines(pvpFilePath, lines);

            lines = new string[pveNameScores.Count];

            for (int i = 0; i < pveNameScores.Count; i++)
            {
                lines[i] = $"{pveNameScores[i].Usernames[0]}-{pveNameScores[i].Usernames[1]}|{pveNameScores[i].Scores[0]}-{pveNameScores[i].Scores[1]}\n";
            }
            File.WriteAllLines(pveFilePath, lines);
        }

        public int GetUsernameIndex(TTT_ScoreHistory scoreHistory)
        {
            for (int i = 0; i < GetPvEScoreHistory().Count; i++)
            {
                if (pveNameScores[i].Usernames[0] == scoreHistory.Usernames[0])
                {
                    return i;
                }
            }
            return -1;
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
            var newLine = $"{scoreHistory.Usernames[0]}-{scoreHistory.Usernames[1]}|{scoreHistory.Scores[0]}-{scoreHistory.Scores[1]}\n";

            File.AppendAllText(pvpFilePath, newLine);
        }

        public void AddPvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            var newLine = $"{scoreHistory.Usernames[0]}-{scoreHistory.Usernames[1]}|{scoreHistory.Scores[0]}-{scoreHistory.Scores[1]}\n";

            File.AppendAllText(pveFilePath, newLine);
        }

        public void UpdatePvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            int index = GetUsernameIndex(scoreHistory);

            pveNameScores[index].Scores[0] = scoreHistory.Scores[0];
            pveNameScores[index].Scores[1] = scoreHistory.Scores[1];

            UpdateTextFiles();
        }

        public void UpdateDifficulty(TTT_ScoreHistory scoreHistory)
        {
            int index = GetUsernameIndex(scoreHistory);

            pveNameScores[index].Usernames[1] = scoreHistory.Usernames[1];
            pveNameScores[index].Scores[0] = scoreHistory.Scores[0];
            pveNameScores[index].Scores[1] = scoreHistory.Scores[1];

            UpdateTextFiles();
        }

        public void UpdateUsername(TTT_ScoreHistory scoreHistory, string newUsername)
        {
            int index = GetUsernameIndex(scoreHistory);

            pveNameScores[index].Usernames[0] = newUsername;

            UpdateTextFiles();
        }

        public void RemoveParticularPvP(TTT_ScoreHistory scoreHistory)
        {
            pvpNameScores.Remove(scoreHistory);

            UpdateTextFiles();
        }

        public void RemoveParticularPvE(TTT_ScoreHistory scoreHistory)
        {
            pveNameScores.Remove(scoreHistory);

            UpdateTextFiles();
        }

        public void ClearPvPScoreHistory()
        {
            File.WriteAllText(pvpFilePath, "");
        }

        public void ClearPvEScoreHistory()
        {
            File.WriteAllText(pveFilePath, "");
        }
    }
}
