using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_History;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;

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

        public List<TTT_ScoreHistory> GetScoreHistory()
        {
            string selectStatement = "SELECT Username1, Username2, Score1, Score2 FROM ScoreHistory";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var nameScores = new List<TTT_ScoreHistory>();

            while (reader.Read())
            {
                TTT_ScoreHistory scoreHistory = new TTT_ScoreHistory()
                {
                    Usernames = new string[] { reader["Username1"].ToString(), reader["Username2"].ToString() },
                    Scores = new int[] { Convert.ToInt32(reader["Score1"]), Convert.ToInt32(reader["Score2"]) }
                };

                nameScores.Add(scoreHistory);
            }

            sqlConnection.Close();
            return nameScores;
        }

        public void AddScoreHistory(TTT_ScoreHistory scoreHistory)
        {
            sqlConnection.Open();

            string insertStatement = "INSERT INTO ScoreHistory VALUES(@username1, @username2, @score1, @score2)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@username1", scoreHistory.Usernames[0]);
            insertCommand.Parameters.AddWithValue("@username2", scoreHistory.Usernames[1]);
            insertCommand.Parameters.AddWithValue("@score1", scoreHistory.Scores[0]);
            insertCommand.Parameters.AddWithValue("@score2", scoreHistory.Scores[1]);

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void ClearScoreHistory()
        {
            sqlConnection.Open();

            string truncateStatement = "TRUNCATE TABLE ScoreHistory";

            SqlCommand truncateCommand = new SqlCommand(truncateStatement, sqlConnection);

            truncateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
