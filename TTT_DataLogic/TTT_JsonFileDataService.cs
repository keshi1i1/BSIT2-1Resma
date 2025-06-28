using TTT_History;
using System.Text.Json;

namespace TTT_DataLogic
{
    public class TTT_JsonFileDataService : TTT_IDataService
    {
        static string pvpFilePath = "PvPScoreHistory.json";

        static string pveFilePath = "PvEScoreHistory.json";

        List<TTT_ScoreHistory> pvpNameScores = new List<TTT_ScoreHistory>();

        List<TTT_ScoreHistory> pveNameScores = new List<TTT_ScoreHistory>();

        public TTT_JsonFileDataService()
        {
            ReadJsonFromPvPFile();
            ReadJsonFromPvEFile();
        }

        private void ReadJsonFromPvPFile()
        {
            string jsonText = File.ReadAllText(pvpFilePath);

            pvpNameScores = JsonSerializer.Deserialize<List<TTT_ScoreHistory>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private void ReadJsonFromPvEFile()
        {
            string jsonText = File.ReadAllText(pveFilePath);

            pveNameScores = JsonSerializer.Deserialize<List<TTT_ScoreHistory>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private void UpdateJsonPvPFile()
        {
            string jsonString = JsonSerializer.Serialize(pvpNameScores, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(pvpFilePath, jsonString);
        }

        private void UpdateJsonPvEFile()
        {
            string jsonString = JsonSerializer.Serialize(pveNameScores, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(pveFilePath, jsonString);
        }

        private int GetUsernameIndex(TTT_ScoreHistory scoreHistory)
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
            pvpNameScores.Add(scoreHistory);

            UpdateJsonPvPFile();
        }

        public void AddPvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            pveNameScores.Add(scoreHistory);

            UpdateJsonPvEFile();
        }

        public void UpdatePvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            int index = GetUsernameIndex(scoreHistory);

            pveNameScores[index].Scores[0] = scoreHistory.Scores[0];
            pveNameScores[index].Scores[1] = scoreHistory.Scores[1];

            UpdateJsonPvEFile();
        }

        public void UpdateDifficulty(TTT_ScoreHistory scoreHistory)
        {
            int index = GetUsernameIndex(scoreHistory);

            pveNameScores[index].Usernames[1] = scoreHistory.Usernames[1];
            pveNameScores[index].Scores[0] = scoreHistory.Scores[0];
            pveNameScores[index].Scores[1] = scoreHistory.Scores[1];

            UpdateJsonPvEFile();
        }

        public void UpdateUsername(TTT_ScoreHistory scoreHistory, string newUsername)
        {
            int index = GetUsernameIndex(scoreHistory);

            pveNameScores[index].Usernames[0] = newUsername;

            UpdateJsonPvEFile();
        }

        public void RemoveParticularPvP(TTT_ScoreHistory scoreHistory)
        {
            pvpNameScores.Remove(scoreHistory);

            UpdateJsonPvPFile();
        }

        public void RemoveParticularPvE(TTT_ScoreHistory scoreHistory)
        {
            pveNameScores.Remove(scoreHistory);

            UpdateJsonPvEFile();
        }

        public void ClearPvPScoreHistory()
        {
            File.WriteAllText(pvpFilePath, "[\n]");
        }

        public void ClearPvEScoreHistory()
        {
            File.WriteAllText(pveFilePath, "[\n]");
        }
    }
}
