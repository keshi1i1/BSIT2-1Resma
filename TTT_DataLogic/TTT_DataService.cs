using TTT_History;

namespace TTT_DataLogic
{
    public class TTT_DataService
    {
        TTT_IDataService dataService;

        public TTT_DataService()
        {
            //dataService = new TTT_InMemoryDataService();
            //dataService = new TTT_TextFileDataService();
            //dataService = new TTT_JsonFileDataService();
            dataService = new TTT_DBDataService();
        }
        public List<TTT_ScoreHistory> GetPvPScoreHistory()
        {
            return dataService.GetPvPScoreHistory();
        }
        public List<TTT_ScoreHistory> GetPvEScoreHistory()
        {
            return dataService.GetPvEScoreHistory();
        }

        public void AddPvPScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            dataService.AddPvPScoreHistory(scoreHistory);
        }

        public void AddPvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            dataService.AddPvEScoreHistory(scoreHistory);
        }

        public void UpdatePvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            dataService.UpdatePvEScoreHistory(scoreHistory);
        }

        public void UpdateDifficulty(TTT_ScoreHistory scoreHistory)
        {
            dataService.UpdateDifficulty(scoreHistory);
        }

        public void UpdateUsername(TTT_ScoreHistory scoreHistory, string newUsername)
        {
            dataService.UpdateUsername(scoreHistory, newUsername);
        }

        public void RemoveParticularPvP(TTT_ScoreHistory scoreHistory)
        {
            dataService.RemoveParticularPvP(scoreHistory);
        }

        public void RemoveParticularPvE(TTT_ScoreHistory scoreHistory)
        {
            dataService.RemoveParticularPvE(scoreHistory);
        }

        public void ClearPvPScoreHistory()
        {
            dataService.ClearPvPScoreHistory();
        }

        public void ClearPvEScoreHistory()
        {
            dataService.ClearPvEScoreHistory();
        }
    }
}
