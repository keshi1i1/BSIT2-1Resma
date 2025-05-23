using TTT_History;
using System.Text.Json;

namespace TTT_DataLogic
{
    public class TTT_JsonFileDataService : TTT_IDataService
    {
        string filePath = "PvPScoreHistory.json";
        List<TTT_ScoreHistory> nameScores = new List<TTT_ScoreHistory>();

        public TTT_JsonFileDataService()
        {
            ReadJsonDataFromFile();
        }

        private void ReadJsonDataFromFile()
        {
            string jsonText = File.ReadAllText(filePath);

            nameScores = JsonSerializer.Deserialize<List<TTT_ScoreHistory>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(nameScores, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(filePath, jsonString);
        }

        public List<TTT_ScoreHistory> GetScoreHistory()
        {
            return nameScores;
        }

        public void AddScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            nameScores.Add(scoreHistory);
            WriteJsonDataToFile();
        }

        public void ClearScoreHistory()
        {
            File.WriteAllText(filePath, "[\n]");
        }
    }
}
