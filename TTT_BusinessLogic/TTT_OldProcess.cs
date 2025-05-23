using TTT_DataLogic;
using TTT_History;

namespace TTT_BusinessLogic
{
    public class TTT_OldProcess
    {
        TTT_OldInMemoryDataService oldInMemoryDataService = new TTT_OldInMemoryDataService();

        //public static Dictionary<string[], int[]> nameScores = new Dictionary<string[], int[]>();

        public static string whoWon = "";

        public static char[] oX = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char first, second, third;

        public static bool p1turn = RNGTurn();

        public static int score1 = 0, score2 = 0;

        public static bool RNGTurn()
        {
            Random r = new Random();
            int rng = r.Next(1, 11);

            if (rng > 5)
            {
                //Player X's turn
                return true;
            }
            else
            {
                //Player O's turn
                return false;
            }
        }
        public static bool ChoiceFrom1To9(int choice)
        {
            if (XOChecker(choice))
                return false;

            //To alternate what to change (X or O)
            switch (choice)
            {
                case 1:
                    oX[0] = (p1turn) ? 'X' : 'O';
                    break;
                case 2:
                    oX[1] = (p1turn) ? 'X' : 'O';
                    break;
                case 3:
                    oX[2] = (p1turn) ? 'X' : 'O';
                    break;
                case 4:
                    oX[3] = (p1turn) ? 'X' : 'O';
                    break;
                case 5:
                    oX[4] = (p1turn) ? 'X' : 'O';
                    break;
                case 6:
                    oX[5] = (p1turn) ? 'X' : 'O';
                    break;
                case 7:
                    oX[6] = (p1turn) ? 'X' : 'O';
                    break;
                case 8:
                    oX[7] = (p1turn) ? 'X' : 'O';
                    break;
                case 9:
                    oX[8] = (p1turn) ? 'X' : 'O';
                    break;
                default:
                    return false;
            }
            return true;
        }

        public static bool MatchDecider()
        {
            //win patterms
            int[,] win = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        first = oX[win[i, j]];
                    }
                    else if (j == 1)
                    {
                        second = oX[win[i, j]];
                    }
                    else
                    {
                        third = oX[win[i, j]];
                        if (first == second && second == third)
                        {
                            if (first == 'X')
                            {
                                score1++;
                                whoWon = "p1";
                            }
                            else
                            {
                                score2++;
                                whoWon = "p2";
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool MatchIsDraw()
        {
            for (int i = 0; i < 9; i++)
            {
                for (char j = '1'; j <= '9'; j++)
                {
                    if (oX[i] == j)
                        return false;
                }
            }
            return true;
        }

        public static void ResetArray()
        {
            //reset oX array
            for (char i = '1'; i <= '9'; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (oX[j] != i)
                    {
                        if (oX[j] == 'X' || oX[j] == 'O')
                        {
                            oX[j] = i;
                            break;
                        }
                    }
                    else
                        break;
                }
            }
        }

        public static bool XOChecker(int choice)
        {
            if (oX[choice - 1] == 'X' || oX[choice - 1] == 'O')
                return true;
            else
                return false;
        }

        public void AddScoreHistory(string p1, string p2, int score1, int score2)
        {
            oldInMemoryDataService.AddScoreHistory(p1, p2, score1, score2);
        }

        public void ClearHistory()
        {
            oldInMemoryDataService.ClearScoreHistory();
        }
    }
}
