using TTT_History;

namespace TTT_DataLogic
{
    public class TTT_DataService
    {
        TTT_IDataService dataService;

        public TTT_DataService()
        {
            //dataService = new TTT_TextFileDataService();
            //dataService = new TTT_InMemoryDataService();
            //dataService = new TTT_JsonFileDataService();
            dataService = new TTT_DBDataService();
        }
        public List<TTT_ScoreHistory> GetScoreHistory()
        {
            return dataService.GetScoreHistory();
        }

        public void AddScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            dataService.AddScoreHistory(scoreHistory);
        }

        public void ClearScoreHistory()
        {
            dataService.ClearScoreHistory();
        }

    }
}
