using TTT_BusinessDataLogic;

namespace TicTacToe
{
    internal class TicTacToe
    {
        static string[] options = { "[1] Player vs Player", "[2] Player vs Bot", "[3] Exit" };
        static string p1 = "", p2 = "";

        static char[] oX = TTT_Process.oX;

        static bool oneWinner = false, rematch = false;

        static void Main(string[] args)
        {
            /* 
                tictactoe game
                player vs bot, player vs player
                username, scoreboard
                randomizer who input first char (O/X)
                clear console every input & resets the tictactoe temp ui
                rematch, back to menu
            */

            /*
                Please refrain from making any errors.
                This game is not completed yet.
                Only option 1 is available for now.
                And there is no DRAW feature yet.
                Thank you for reading this.
            */

            int options = 0;

            DisplayOptions();
            options = GetUserInput();
            UseUserInput(options);
        }

        static void DisplayOptions()
        {
            Console.WriteLine("|====TIC TAC TOE====|\n");

            foreach (string i in options)
            {
                Console.WriteLine(i);
            }
        }

        static int GetUserInput()
        {
            Console.Write("\nSelect an Option: ");
            int options = Convert.ToInt16(Console.ReadLine());

            return options;
        }

        static void UseUserInput(int options)
        {

            switch (options)
            {
                case 1:
                    Console.Write("\nEnter P1-Username: ");
                    p1 = Console.ReadLine().ToUpper();

                    Console.Write("Enter P2-Username: ");
                    p2 = Console.ReadLine().ToUpper();

                    RefreshUI(p1, p2);
                    break;
                case 2:
                    Console.WriteLine("\nIncomplete Program!");
                    Thread.Sleep(2000);
                    break;
                case 3:
                    Console.WriteLine("\nEXITING THE PROGRAM...");
                    Thread.Sleep(2000);
                    return;
                default:
                    Console.WriteLine("\nInvalid Choice!");
                    Thread.Sleep(2000);
                    break;
            }
            Console.Clear();

            DisplayOptions();
            options = GetUserInput();
            UseUserInput(options);
        }

        static void TicTacToeUI()
        {
            Console.WriteLine();

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
            Console.WriteLine("|====TIC TAC TOE====|\n");

            Console.WriteLine("| ------SCORE------ |");
            Console.WriteLine("| [X] " + p1 + ": " + TTT_Process.score1 + "\t    |");
            Console.WriteLine("| [O] " + p2 + ": " + TTT_Process.score2 + "\t    |");
        }


        static void RefreshUI(string p1, string p2)
        {
            Console.Clear();

            oneWinner = TTT_Process.MatchDecider();
            ScoreBoard(p1, p2);
            TicTacToeUI();

            if (!oneWinner)
            {
                WhosTurn();
                RefreshUI(p1, p2);
            }
            else
            {
                TTT_Process.ResetArray();
                Winner();

                //ask user for rematch
                oneWinner = false;
                rematch = Rematch();

                if (rematch)
                    RefreshUI(p1, p2);
                else
                {
                    TTT_Process.score1 = 0;
                    TTT_Process.score2 = 0;
                }
            }
        }

        static void WhosTurn()
        {
            if (TTT_Process.p1turn)
            {
                Console.WriteLine("\n|  PLAYER X's TURN  |");
                Console.Write("\nChoose from [1-9]: ");
                int choice = Convert.ToInt16(Console.ReadLine());

                if (TTT_Process.ChoiceFrom1To9(choice))
                    TTT_Process.p1turn = false;
                else
                    InvalidChoice();
            }
            else
            {
                Console.WriteLine("\n|  PLAYER O's TURN  |");
                Console.Write("\nChoose from [1-9]: ");
                int choice = Convert.ToInt16(Console.ReadLine());

                if (TTT_Process.ChoiceFrom1To9(choice))
                    TTT_Process.p1turn = true;
                else
                    InvalidChoice();
            }
        }

        static void Winner()
        {
            if (TTT_Process.whoWon == "p1")
                Console.WriteLine("\n|       X WON!      |");

            else if (TTT_Process.whoWon == "p2")
                Console.WriteLine("\n|       O WON!      |");

            Thread.Sleep(1000);
        }

        static void InvalidChoice()
        {
            Console.WriteLine("\nInvalid! Please choose from 1 to 9.");
            Thread.Sleep(2000);
        }

        static bool Rematch()
        {
            Console.WriteLine("\nDo you want a rematch? Y/N");
            char yesNo = Convert.ToChar(Console.ReadLine());

            if (yesNo == 'Y')
            {
                Console.WriteLine("\nRESTARTING THE MATCH...");
                Thread.Sleep(2000);
                return true;
            }
            else
            {
                Console.WriteLine("\nGOING BACK TO MENU...");
                Thread.Sleep(2000);
                return false;
            }
        }
    }
}
