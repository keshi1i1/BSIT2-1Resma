using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_History;

namespace TTT_DataLogic
{
    public interface TTT_IDataService
    {
        public List<TTT_ScoreHistory> GetScoreHistory();
        public void AddScoreHistory(TTT_ScoreHistory scoreHistory);
        public void ClearScoreHistory();
    }
}
