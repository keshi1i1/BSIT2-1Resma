using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_History;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace TTT_DataLogic
{
    public class TTT_DBDataService : TTT_IDataService
    {
        static string connectionString = "Data Source =DESKTOP-FOAVQMH\\SQLEXPRESS; Initial Catalog = TicTacToe; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public TTT_DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<TTT_ScoreHistory> GetPvPScoreHistory()
        {
            string selectStatement = "SELECT Player1, Score1, Player2, Score2 FROM PlayerVsPlayerSH";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var nameScores = new List<TTT_ScoreHistory>();

            while (reader.Read())
            {
                TTT_ScoreHistory scoreHistory = new TTT_ScoreHistory()
                {
                    Usernames = new string[] { reader["Player1"].ToString(), reader["Player2"].ToString() },
                    Scores = new int[] { Convert.ToInt32(reader["Score1"]), Convert.ToInt32(reader["Score2"]) }
                };

                nameScores.Add(scoreHistory);
            }

            sqlConnection.Close();
            return nameScores;
        }

        public List<TTT_ScoreHistory> GetPvEScoreHistory()
        {
            sqlConnection.Open();

            string selectStatement = "SELECT Username, Score1, Bot_Difficulty, Score2 FROM PlayerVsBotSH";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            SqlDataReader reader = selectCommand.ExecuteReader();

            var nameScores = new List<TTT_ScoreHistory>();

            while (reader.Read())
            {
                TTT_ScoreHistory scoreHistory = new TTT_ScoreHistory()
                {
                    Usernames = new string[] { reader["Username"].ToString(), reader["Bot_Difficulty"].ToString() },
                    Scores = new int[] { Convert.ToInt32(reader["Score1"]), Convert.ToInt32(reader["Score2"]) }
                };

                nameScores.Add(scoreHistory);
            }

            sqlConnection.Close();
            return nameScores;
        }

        public void AddPvPScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            sqlConnection.Open();

            string insertStatement = "INSERT INTO PlayerVsPlayerSH VALUES(@player1, @score1, @player2, @score2)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@player1", scoreHistory.Usernames[0]);
            insertCommand.Parameters.AddWithValue("@score1", scoreHistory.Scores[0]);
            insertCommand.Parameters.AddWithValue("@player2", scoreHistory.Usernames[1]);
            insertCommand.Parameters.AddWithValue("@score2", scoreHistory.Scores[1]);

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void AddPvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            sqlConnection.Open();

            string insertStatement = "INSERT INTO PlayerVsBotSH VALUES(@username, @score1, @botDifficulty, @score2)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@username", scoreHistory.Usernames[0]);
            insertCommand.Parameters.AddWithValue("@score1", scoreHistory.Scores[0]);
            insertCommand.Parameters.AddWithValue("@botDifficulty", scoreHistory.Usernames[1]);
            insertCommand.Parameters.AddWithValue("@score2", scoreHistory.Scores[1]);

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdatePvEScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            sqlConnection.Open();

            string updateStatement = "UPDATE PlayerVsBotSH SET Score1 = @score1, Score2 = @score2 WHERE Username = @username";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@username", scoreHistory.Usernames[0]);
            updateCommand.Parameters.AddWithValue("@score1", scoreHistory.Scores[0]);
            updateCommand.Parameters.AddWithValue("@score2", scoreHistory.Scores[1]);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateDifficulty(TTT_ScoreHistory scoreHistory)
        {
            sqlConnection.Open();

            string updateStatement = "UPDATE PlayerVsBotSH SET Bot_Difficulty = @botDifficulty, Score1 = @score1, Score2 = @score2 WHERE Username = @username";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@username", scoreHistory.Usernames[0]);
            updateCommand.Parameters.AddWithValue("@score1", scoreHistory.Scores[0]);
            updateCommand.Parameters.AddWithValue("@botDifficulty", scoreHistory.Usernames[1]);
            updateCommand.Parameters.AddWithValue("@score2", scoreHistory.Scores[1]);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateUsername(TTT_ScoreHistory scoreHistory, string newUsername)
        {
            sqlConnection.Open();

            string updateStatement = "UPDATE PlayerVsBotSH SET Username = @newUsername WHERE Username = @oldUsername";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@oldUsername", scoreHistory.Usernames[0]);
            updateCommand.Parameters.AddWithValue("@newUsername", newUsername);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void RemoveParticularPvP(TTT_ScoreHistory scoreHistory)
        {
            sqlConnection.Open();

            string deleteStatement = "DELETE FROM PlayerVsPlayerSH WHERE Player1 = @player1 AND Score1 = @score1 AND Player2 = @player2 AND Score2 = @score2";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@player1", scoreHistory.Usernames[0]);
            deleteCommand.Parameters.AddWithValue("@score1", scoreHistory.Scores[0]);
            deleteCommand.Parameters.AddWithValue("@player2", scoreHistory.Usernames[1]);
            deleteCommand.Parameters.AddWithValue("@score2", scoreHistory.Scores[1]);

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void RemoveParticularPvE(TTT_ScoreHistory scoreHistory)
        {
            sqlConnection.Open();

            string deleteStatement = "DELETE FROM PlayerVsBotSH WHERE Username = @username AND Score1 = @score1 AND Bot_Difficulty = @botDifficulty AND Score2 = @score2";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@username", scoreHistory.Usernames[0]);
            deleteCommand.Parameters.AddWithValue("@score1", scoreHistory.Scores[0]);
            deleteCommand.Parameters.AddWithValue("@botDifficulty", scoreHistory.Usernames[1]);
            deleteCommand.Parameters.AddWithValue("@score2", scoreHistory.Scores[1]);

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void ClearPvPScoreHistory()
        {
            sqlConnection.Open();

            string truncateStatement = "TRUNCATE TABLE PlayerVsPlayerSH";

            SqlCommand truncateCommand = new SqlCommand(truncateStatement, sqlConnection);

            truncateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void ClearPvEScoreHistory()
        {
            sqlConnection.Open();

            string truncateStatement = "TRUNCATE TABLE PlayerVsBotSH";

            SqlCommand truncateCommand = new SqlCommand(truncateStatement, sqlConnection);

            truncateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
