using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Forms
{
    public class TTT_ProcessForForms
    {
        public string whoWon = "";

        public static char[] oX = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private char first, second, third;

        public bool p1turn = RNGTurn(), noMorePriority = false;

        public int score1 = 0, score2 = 0, xCount = 0, oCount = 0;

        //win patterms
        private int[,] win = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

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

        public bool ChoiceFrom1To9(int choice)
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

        public bool MatchDecider()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        first = oX[win[i, j]];
                    else if (j == 1)
                        second = oX[win[i, j]];
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

        public bool MatchIsDraw()
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

        public void ResetArray()
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

        public bool XOChecker(int choice)
        {
            return (oX[choice - 1] == 'X' || oX[choice - 1] == 'O');
        }

        public int EasyBotAI(char[] botChoices)
        {
            Random rng = new Random();
            int choice;

            do
            {
                choice = rng.Next(1, 10);

                foreach (char c in botChoices)
                {
                    if (c == choice + 48)
                        return choice;
                }
            } while (true);
        }

        public int MediumBotAI(char[] botChoices)
        {
            int choice;

            do
            {
                choice = ThirdCircleFinder();

                foreach (char c in botChoices)
                {
                    if (c == choice + 48)
                        return choice;
                }
            } while (true);
        }

        public int ThirdCircleFinder()
        {
            Random rng = new Random();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        first = oX[win[i, j]];
                    else if (j == 1)
                        second = oX[win[i, j]];
                    else
                    {
                        third = oX[win[i, j]];

                        if (first != 'X' && second == 'O' && second == third)
                            return first - 48;

                        else if (second != 'X' && third == 'O' && third == first)
                            return second - 48;

                        else if (third != 'X' && first == 'O' && first == second)
                            return third - 48;
                    }
                }
            }
            return XBlocker();
        }

        public int HardBotAI(char[] botChoices)
        {
            int choice;

            do
            {
                if (botChoices[4] == '5')
                    return 5;
                else
                {
                    XOCounter(botChoices);

                    if (xCount < 2)
                        choice = PriorityNumberFinder(botChoices);
                    else
                    {
                        if (!PossibleWin())
                            choice = PriorityNumberFinder(botChoices);
                        else
                            choice = ThirdCircleFinder();
                    }
                }

                foreach (char c in botChoices)
                {
                    if (c == choice + 48)
                        return choice;
                }
            } while (true);
        }

        public int PriorityNumberFinder(char[] botChoices)
        {
            Random rng = new Random();

            int index;

            char[] priority1 = { '1', '3', '7', '9' }, priority2 = { '2', '4', '6', '8' };

            foreach (char c in botChoices)
            {
                if (botChoices[0] == botChoices[2] || botChoices[2] == botChoices[6] || botChoices[6] == botChoices[8] || botChoices[8] == botChoices[0])
                {
                    index = rng.Next(0, priority2.Length);

                    if (c == priority2[index])
                    {
                        return priority2[index] - 48;
                    }
                }
                else
                {
                    index = rng.Next(0, priority1.Length);

                    if (c == priority1[index])
                    {
                        return priority1[index] - 48;
                    }
                }
            }
            return rng.Next(1, 10);
        }

        public int XBlocker()
        {
            Random rng = new Random();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        first = oX[win[i, j]];
                    else if (j == 1)
                        second = oX[win[i, j]];
                    else
                    {
                        third = oX[win[i, j]];

                        if (first != 'O' && second == 'X' && second == third)
                            return first - 48;

                        else if (second != 'O' && third == 'X' && third == first)
                            return second - 48;

                        else if (third != 'O' && first == 'X' && first == second)
                            return third - 48;
                    }
                }
            }
            return rng.Next(1, 10);
        }

        public void XOCounter(char[] oX)
        {
            int xCounter = 0, oCounter = 0;

            foreach (char c in oX)
            {
                if (c == 'X')
                    xCounter++;

                else if (c == 'O')
                    oCounter++;
            }
            xCount = xCounter;
            oCount = oCounter;
        }

        public bool PossibleWin()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        first = oX[win[i, j]];
                    else if (j == 1)
                        second = oX[win[i, j]];
                    else
                    {
                        third = oX[win[i, j]];

                        if (first != 'O' && first != 'X' && second == third)
                            return true;

                        else if (second != 'O' && second != 'X' && third == first)
                            return true;

                        else if (third != 'O' && third != 'X' && first == second)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
