using System.Net.Http.Headers;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;

namespace TicTacToe
{
    internal class TicTacToe
    {
        static char[] oX = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char first, second, third;
        static bool oneWinner = false, p1Turn = false, p2Turn = false, rematch = false;
        static int attempts = 0, score1 = 0, score2 = 0;
        static string p1, p2, whoWon;

        static void Main(string[] args)
        {
            // tictactoe game
            // player vs bot, player vs player
            // username, scoreboard
            // randomizer who input first char (O/X)
            // clear console every input & resets the tictactoe temp ui
            // rematch, back to menu

            string[] options = { "[1] Player vs Player", "[2] Player vs Bot", "[3] Exit" };
            int opt; ;

            /*
                Please refrain from making any errors.
                This game is not completed yet.
                Only option 1 is available for now.
                And there is no DRAW feature yet.
                Thank you for reading this.
            */

            Console.WriteLine("\n|====TIC TAC TOE====|\n");

            foreach (string i in options)
            {
                Console.WriteLine(i);
            }

            Console.Write("\nSelect an Option: ");
            opt = Convert.ToInt16(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.Write("\nEnter P1-Username: ");
                    p1 = Console.ReadLine().ToUpper();

                    Console.Write("Enter P2-Username: ");
                    p2 = Console.ReadLine().ToUpper();

                    Refresh(p1, p2, score1, score2);

                    break;
                default:
                    Console.WriteLine("Incomplete Program!");
                    break;
            }
        }

        static void TicTacToeUI()
        {
            Console.WriteLine("|   -------------   |");
            Console.WriteLine("|   | " + oX[0] + " | " + oX[1] + " | " + oX[2] + " |   |");
            Console.WriteLine("|   -------------   |");
            Console.WriteLine("|   | " + oX[3] + " | " + oX[4] + " | " + oX[5] + " |   |");
            Console.WriteLine("|   -------------   |");
            Console.WriteLine("|   | " + oX[6] + " | " + oX[7] + " | " + oX[8] + " |   |");
            Console.WriteLine("|   -------------   |");
        }

        static void ScoreBoard(string p1, string p2) 
        {
            Console.WriteLine("| ------SCORE------ |");
            Console.WriteLine("| [X] " + p1 + ": " + score1 + "\t    |");
            Console.WriteLine("| [O] " + p2 + ": " + score2 + "\t    |");
        }

        static void WhosTurn()
        {
            Random r = new Random();
            int rng = r.Next(1, 11);

            if (rng > 5)
            {
                p1Turn = true;
                p2Turn = false;
            }
            else
            {
                p2Turn = true;
                p1Turn = false;
            }
        }

        static void ChoiceFrom1To9(int choice)
        {
            switch(choice)
            {
                case 1:
                    oX[0] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 2:
                    oX[1] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 3:
                    oX[2] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 4:
                    oX[3] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 5:
                    oX[4] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 6:
                    oX[5] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 7:
                    oX[6] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 8:
                    oX[7] = (p1Turn == true) ? 'X' : 'O';
                    break;
                case 9:
                    oX[8] = (p1Turn == true) ? 'X' : 'O';
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }

        static void Refresh(string p1, string p2, int score1, int score2)
        {
            Console.Clear();

            Console.WriteLine("\n|====TIC TAC TOE====|\n");

            MatchDecider();

            ScoreBoard(p1, p2);

            Console.WriteLine();

            TicTacToeUI();

            if (attempts == 0)
            { 
                WhosTurn();
            }

            if (oneWinner == false)
            {
                if (p1Turn == true)
                {
                    Console.WriteLine("\n|  PLAYER X's TURN  |");
                    Console.Write("\nChoose from [1-9]: ");
                    int choice = Convert.ToInt16(Console.ReadLine());

                    ChoiceFrom1To9(choice);

                    p1Turn = false;
                    p2Turn = true;
                }
                else if (p2Turn == true)
                {
                    Console.WriteLine("\n|  PLAYER O's TURN  |");
                    Console.Write("\nChoose from [1-9]: ");
                    int choice = Convert.ToInt16(Console.ReadLine());

                    ChoiceFrom1To9(choice);

                    p2Turn = false;
                    p1Turn = true;
                }
            }

            if (oneWinner == false)
            {
                attempts++;
                Refresh(p1, p2, score1, score2);
            }
            else
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
                        {
                            break;
                        }
                    }
                }

                if (whoWon.Equals("p1"))
                {
                    Console.WriteLine("\n|       X WON!      |");
                }
                else if (whoWon.Equals("p2"))
                {
                    Console.WriteLine("\n|       O WON!      |");
                }

                Thread.Sleep(1000);

                //ask user for rematch
                oneWinner = false;
                Rematch();
                if (rematch == true)
                {
                    Refresh(p1, p2, score1, score2);
                }
                else
                {
                    attempts = 0;
                    //go back to options 1,2,3; incomplete
                }
            }
        }

        static void MatchDecider()
        {
            int[,] win = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
            //char first, second, third;

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
                            oneWinner = true;
                        }
                    }
                }
            }
        }

        static bool Rematch()
        {
            Console.WriteLine("\nDo you want a rematch? Y/N");
            char yesNo = Convert.ToChar(Console.ReadLine());

            if (yesNo == 'Y')
            {
                Console.WriteLine("\nRESTARTING THE MATCH...");
                Thread.Sleep(3000);
                return rematch = true;
            }
            else
            {
                Console.WriteLine("\nGOING BACK TO MENU...");
                Thread.Sleep(3000);
                return rematch = false;
            }
        }
    }
}
