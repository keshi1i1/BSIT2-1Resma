using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TTT_BusinessLogic;
using TTT_DataLogic;
using TTT_History;

namespace TTT_WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TTT_ScoreHistoryController : ControllerBase
    {
        TTT_Process process = new TTT_Process();

        [HttpGet("getPvPScoreHistory")]
        public IEnumerable<TTT_ScoreHistory> GetPvPScoreHistory()
        {
            var nameScores = process.GetPvPScoreHistory();

            return nameScores;
        }

        [HttpGet("getPvEScoreHistory")]
        public IEnumerable<TTT_ScoreHistory> GetPvEScoreHistory()
        {
            var nameScores = process.GetPvEScoreHistory();

            return nameScores;
        }

        [HttpPost("addPvPNameScores")]
        public bool AddPvPScoreHistory(TTT_ScoreHistory nameScores)
        {
            process.AddPvPScoreHistory(nameScores.Usernames[0], nameScores.Usernames[1], nameScores.Scores[0], nameScores.Scores[1]);

            return true;
        }

        [HttpPost("addPvENameScores")]
        public bool AddPvEScoreHistory(TTT_ScoreHistory nameScores)
        {
            process.AddPvEScoreHistory(nameScores.Usernames[0], nameScores.Usernames[1], nameScores.Scores[0], nameScores.Scores[1]);

            return true;
        }

        [HttpPatch("updatePvENameScores")]
        public bool UpdatePvEScoreHistory(TTT_ScoreHistory nameScores)
        {
            process.UpdatePvEScoreHistory(nameScores.Usernames[0], nameScores.Scores[0], nameScores.Scores[1]);

            return true;
        }

        [HttpPatch("updateDifficulty")]
        public bool UpdateDifficulty(TTT_ScoreHistory nameScores)
        {
            process.UpdateDifficulty(nameScores.Usernames[0], nameScores.Usernames[1]);

            return true;
        }

        [HttpPatch("updateUsername")]
        public bool UpdateUsername(TTT_ScoreHistory nameScores)
        {
            process.UpdateUsername(nameScores.Usernames[0], nameScores.Usernames[1]);

            return true;
        }

        [HttpDelete("removeParticularPvP")]
        public bool RemoveParticularPvP(int choiceToRemove)
        {
            process.RemoveParticularPvP(choiceToRemove);

            return true;
        }

        [HttpDelete("removeParticularPvE")]
        public bool RemoveParticularPvE(int choiceToRemove)
        {
            process.RemoveParticularPvE(choiceToRemove);

            return true;
        }

        [HttpDelete("clearPvPScoreHistory")]
        public bool ClearPvPScoreHistory()
        {
            process.ClearPvPScoreHistory();

            return true;
        }

        [HttpDelete("clearPvEScoreHistory")]
        public bool ClearPvEScoreHistory()
        {
            process.ClearPvEScoreHistory();

            return true;
        }
    }
}
