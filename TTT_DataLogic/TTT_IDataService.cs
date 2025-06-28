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
        public List<TTT_ScoreHistory> GetPvPScoreHistory();
        public List<TTT_ScoreHistory> GetPvEScoreHistory();
        public void AddPvPScoreHistory(TTT_ScoreHistory scoreHistory);
        public void AddPvEScoreHistory(TTT_ScoreHistory scoreHistory);
        public void UpdatePvEScoreHistory(TTT_ScoreHistory scoreHistory);
        public void UpdateDifficulty(TTT_ScoreHistory scoreHistory);
        public void UpdateUsername(TTT_ScoreHistory scoreHistory, string newUsername);
        public void RemoveParticularPvP(TTT_ScoreHistory scoreHistory);
        public void RemoveParticularPvE(TTT_ScoreHistory scoreHistory);
        public void ClearPvPScoreHistory();
        public void ClearPvEScoreHistory();
    }
}
