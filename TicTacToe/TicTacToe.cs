using System.Diagnostics;
using TTT_BusinessLogic;
using TTT_History;

namespace TicTacToe
{
    internal class TicTacToe
    {
        /*
            objectives:
            - draw feature
            - player vs bot
            - difficulty (easy, medium, hard)
            - more error handling (repetitive number from 1-9, invalid choices, etc.)
        */

        static TTT_Process process = new TTT_Process();

        static string[] options = { "[1] Player vs Player", "[2] Player vs Bot", "[3] Score History", "[4] Exit" };
        static string[] shOptins = { "[1] PvP Score History", "[2] PvE Score History", "[3] Go Back" };
        static string[] playerVsBot = { "[1] New Game", "[2] Continue", "[3] Go Back" };
        static string[] difficulties = { "[1] Easy", "[2] Medium", "[3] Hard", "[4] Go Back" };
        static string[] loggedIn = { "[1] Continue Match", $"[2] Change Difficulty {chosenDifficulty}", "[3] Change Username", "[4] Go Back" };
        static string[] removeScores = { "[1] Remove History", $"[2] Clear History", "[3] Go Back" };

        static string p1 = "", p2 = "";
        static string chosenDifficulty = "";

        static char[] oX = TTT_Process.oX;

        static bool oneWinner = false, rematch = false, draw = false, continueMatch = false;

        static List<TTT_ScoreHistory> GetScoreHistory;
        static Action ClearScoreHistory;

        public static void Main(string[] args)
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
                Thank you for reading this.
            */

            int option = 0;

            DisplayMenuOptions();
            option = GetUserInput();
            MenuOptions(option);
        }

        public static void DisplayMenuOptions()
        {
            DisplayTicTacToe();

            foreach (string i in options)
            {
                Console.WriteLine(i);
            }
        }

        public static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Console.Write("\nEnter P1-Username: ");
                    p1 = Console.ReadLine().ToUpper();

                    Console.Write("Enter P2-Username: ");
                    p2 = Console.ReadLine().ToUpper();

                    RefreshUI(p1, p2);
                    break;
                case 2:
                    PlayerVsBotOptions();
                    break;
                case 3:
                    ScoreHistoryOptions();
                    break;
                case 4:
                    Console.WriteLine("\nEXITING THE PROGRAM...");
                    Thread.Sleep(2000);
                    return;
                default:
                    Console.WriteLine("\nInvalid Choice!");
                    Thread.Sleep(2000);
                    break;
            }

            DisplayMenuOptions();
            option = GetUserInput();
            MenuOptions(option);
        }

        public static int GetUserInput()
        {
            Console.Write("\nSelect an Option: ");
            int option = Convert.ToInt16(Console.ReadLine());

            return option;
        }

        public static void DisplayTicTacToe()
        {
            Console.Clear();
            Console.WriteLine("|=====TIC TAC TOE=====|\n");
        }

        public static void ScoreBoard(string p1, string p2)
        {
            DisplayTicTacToe();

            Console.WriteLine("| -------SCORE------- |");
            Console.WriteLine("| [X] " + p1 + ": " + process.score1 + "\t      |");
            Console.WriteLine("| [O] " + p2 + ": " + process.score2 + "\t      |");
        }

        public static void ScoreHistoryOptions()
        {
            DisplayTicTacToe();

            foreach (string i in shOptins)
            {
                Console.WriteLine(i);
            }

            Console.Write("\nChoose from [1-3]: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    p2 = "";
                    ScoreHistory();
                    break;
                case 2:
                    p2 = "BOT";
                    ScoreHistory();
                    break;
                case 3:
                    Console.WriteLine("\nGOING BACK TO MENU...");
                    Thread.Sleep(2000);

                    break;
                default:
                    InvalidChoice();
                    ScoreHistoryOptions();
                    break;
            }
        }

        public static void ScoreHistory()
        {
            DisplayTicTacToe();

            string title = "";
            if (Player2IsBot())
            {
                title = "| --PLAYERs HISTORY-- |\n";
                GetScoreHistory = process.GetPvEScoreHistory();
                ClearScoreHistory = process.ClearPvEScoreHistory;
            }
            else
            {
                title = "| -PVP SCORE HISTORY- |\n";
                GetScoreHistory = process.GetPvPScoreHistory();
                ClearScoreHistory = process.ClearPvPScoreHistory;
            }
            Console.WriteLine(title);

            for (int i = 0; i < GetScoreHistory.Count; i++)
            {
                string[] oldNames = GetScoreHistory[i].Usernames;
                int[] oldScores = GetScoreHistory[i].Scores;
                Console.WriteLine($"#{i + 1} {oldNames[0]}: {oldScores[0]}  VS  {oldNames[1]}: {oldScores[1]}");
            }

            if (GetScoreHistory.Count == 0)
                Console.WriteLine("|         N/A         |");
            Console.WriteLine("\n|=====================|\n");

            foreach (var option in removeScores)
            {
                Console.WriteLine(option);
            }
            Console.Write("\nChoose from [1-3]: ");
            int actions = Convert.ToInt16(Console.ReadLine());

            switch (actions)
            {
                case 1:
                    int choice = 0;
                    if (GetScoreHistory.Count != 0)
                    {
                        do
                        {
                            DisplayTicTacToe();

                            Console.WriteLine(title);

                            for (int i = 0; i < GetScoreHistory.Count; i++)
                            {
                                string[] oldNames = GetScoreHistory[i].Usernames;
                                int[] oldScores = GetScoreHistory[i].Scores;
                                Console.WriteLine($"#{i + 1} {oldNames[0]}: {oldScores[0]}  VS  {oldNames[1]}: {oldScores[1]}");
                            }
                            Console.WriteLine("\n|=====================|\n");

                            Console.Write($"Remove from [1-{GetScoreHistory.Count}]: ");
                            choice = Convert.ToInt16(Console.ReadLine());

                            if (choice < 1 || choice > GetScoreHistory.Count)
                                InvalidChoice();
                        } while (choice < 1 || choice > GetScoreHistory.Count);

                        if (Player2IsBot())
                            process.RemoveParticularPvE(choice);
                        else
                            process.RemoveParticularPvP(choice);

                        Console.WriteLine($"\nREMOVING SCORE HISTORY #{choice}...");
                    }
                    else
                        Console.WriteLine("\nInvalid! There is currently no score history!");
                    Thread.Sleep(2000);
                    ScoreHistory();
                    break;
                case 2:
                    if (GetScoreHistory.Count != 0)
                    {
                        ClearScoreHistory();
                        Console.WriteLine("\nCLEARING HISTORY...");
                    }
                    else
                        Console.WriteLine("\nInvalid! There is currently no score history!");
                    Thread.Sleep(2000);
                    ScoreHistory();
                    break;
                case 3:
                    Console.WriteLine("\nGOING BACK...");
                    Thread.Sleep(2000);
                    ScoreHistoryOptions();
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!");
                    Thread.Sleep(2000);
                    ScoreHistory();
                    break;
            }
        }

        public static void TicTacToeUI()
        {
            Console.WriteLine();

            Console.WriteLine("|    -------------    |");
            Console.WriteLine($"|    | {oX[0]} | {oX[1]} | {oX[2]} |    |");
            Console.WriteLine("|    -------------    |");
            Console.WriteLine($"|    | {oX[3]} | {oX[4]} | {oX[5]} |    |");
            Console.WriteLine("|    -------------    |");
            Console.WriteLine($"|    | {oX[6]} | {oX[7]} | {oX[8]} |    |");
            Console.WriteLine("|    -------------    |");
        }

        public static void RefreshUI(string p1, string p2)
        {
            Console.Clear();

            oneWinner = process.MatchDecider();
            draw = process.MatchIsDraw();
            ScoreBoard(p1, p2);
            TicTacToeUI();

            if (!oneWinner && !draw)
            {
                WhosTurn();
                RefreshUI(p1, p2);
            }
            else
            {
                if (!draw || oneWinner)
                    ShowWinner();
                else
                    ShowDraw(draw);

                process.ResetArray();

                //ask user for rematch
                oneWinner = false;
                draw = false;
                rematch = Rematch();

                if (rematch)
                    RefreshUI(p1, p2);
                else
                {
                    if(Player2IsBot())
                    {
                        if(continueMatch)
                        {
                            process.UpdatePvEScoreHistory(p1, process.score1, process.score2);
                            continueMatch = false;
                            UsersDataHistory(p1);
                        }
                        else
                            process.AddPvEScoreHistory(p1, chosenDifficulty, process.score1, process.score2);
                    }
                    else
                        process.AddPvPScoreHistory(p1, p2, process.score1, process.score2);

                    process.score1 = 0;
                    process.score2 = 0;
                    return;
                }
            }
        }

        public static void WhosTurn()
        {
            if (process.p1turn)
            {
                Console.WriteLine("\n|   PLAYER X's TURN   |");
                Console.Write("\nChoose from [1-9]: ");
                int choice = Convert.ToInt16(Console.ReadLine());

                if (process.ChoiceFrom1To9(choice))
                    process.p1turn = false;
                else
                    InvalidChoice();
            }
            else
            {
                if (Player2IsBot())
                {
                    int choice = 0;
                    if (chosenDifficulty == "EASY")
                    {
                        Console.WriteLine("\n|   EASY-BOT's TURN   |");
                        BotIsThinking();
                        choice = process.EasyBotAI(oX);
                    }
                    else if (chosenDifficulty == "MEDIUM")
                    {
                        Console.WriteLine("\n|  MEDIUM-BOT's TURN  |");
                        BotIsThinking();
                        choice = process.MediumBotAI(oX);
                    }
                    else if (chosenDifficulty == "HARD")
                    {
                        Console.WriteLine("\n|   HARD-BOT's TURN   |");
                        BotIsThinking();
                        choice = process.HardBotAI(oX);
                    }

                    if (process.ChoiceFrom1To9(choice)) { }
                        process.p1turn = true;
                }
                else
                {
                    Console.WriteLine("\n|   PLAYER O's TURN   |");
                    Console.Write("\nChoose from [1-9]: ");
                    int choice = Convert.ToInt16(Console.ReadLine());

                    if (process.ChoiceFrom1To9(choice))
                        process.p1turn = true;
                    else
                        InvalidChoice();
                }
            }
        }

        public static bool Rematch()
        {
            Console.WriteLine("\nDo you want a rematch? Yes/No\n");
            string yesNo = Console.ReadLine();

            if (yesNo.Equals("Yes", StringComparison.OrdinalIgnoreCase) || yesNo.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nRESTARTING THE MATCH...");
                Thread.Sleep(2000);
                return true;
            }
            else
            {
                if (continueMatch)
                    Console.WriteLine("\nGOING BACK...");
                else
                    Console.WriteLine("\nGOING BACK TO MENU...");
                Thread.Sleep(2000);
                return false;
            }
        }

        public static void ShowDraw(bool draw)
        {
            if (draw)
            {
                Console.WriteLine("\n|     MATCH DRAW!     |");
            }
            Thread.Sleep(1000);
        }

        public static void ShowWinner()
        {
            if (process.whoWon == "p1")
                Console.WriteLine("\n|        X WON!       |");

            else if (process.whoWon == "p2")
            {
                if (Player2IsBot())
                {
                    if (chosenDifficulty == "EASY")
                        Console.WriteLine("\n|    EASY-BOT WON!    |");

                    else if (chosenDifficulty == "MEDIUM")
                        Console.WriteLine("\n|   MEDIUM-BOT WON!   |");
                    
                    else if (chosenDifficulty == "HARD")
                        Console.WriteLine("\n|    HARD-BOT WON!    |");
                }
                else
                    Console.WriteLine("\n|        O WON!       |");
            }
            Thread.Sleep(1000);
        }

        public static void InvalidChoice()
        {
            Console.WriteLine("\nInvalid! Please choose from numbers shown.");
            Thread.Sleep(2000);
        }

        public static void PlayerVsBotOptions()
        {
            DisplayTicTacToe();

            foreach (string i in playerVsBot)
            {
                Console.WriteLine(i);
            }

            Console.Write("\nChoose from [1-3]: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BotDifficulty();
                    break;
                case 2:
                    if(process.GetPvEScoreHistory().Count != 0)
                    {
                        p1 = InputUsername().ToUpper();

                        if (!process.ValidateUsername(p1))
                        {
                            Console.WriteLine("\nInvalid! Cannot find username!");
                            Thread.Sleep(2000);
                            PlayerVsBotOptions();
                            break;
                        }
                        Console.WriteLine("\nSuccessful! Correct username found!");
                        Thread.Sleep(2000);
                        UsersDataHistory(p1);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid! There is currently no users!");
                        Thread.Sleep(2000);
                        PlayerVsBotOptions();
                    }
                    break;
                case 3:
                    Console.WriteLine("\nGOING BACK TO MENU...");
                    Thread.Sleep(2000);
                    break;
                default:
                    InvalidChoice();
                    PlayerVsBotOptions();
                    break;
            }
        }

        public static string InputUsername()
        {
            Console.Write("\nEnter your username: ");
            string name = Console.ReadLine();

            return name;
        }

        public static bool Player2IsBot()
        {
            if (p2 == "BOT")
                return true;

            return false;
        }

        public static void BotDifficulty()
        {
            DisplayTicTacToe();

            foreach (string i in difficulties)
            {
                Console.WriteLine(i);
            }

            Console.Write("\nChoose from [1-4]: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //easy difficulty
                    chosenDifficulty = "EASY";
                    EnemyBot(1);
                    break;
                case 2:
                    //medium difficulty
                    chosenDifficulty = "MEDIUM";
                    EnemyBot(2);
                    break;
                case 3:
                    //hard difficulty
                    chosenDifficulty = "HARD";
                    EnemyBot(3);
                    break;
                case 4:
                    //go back
                    Console.WriteLine("\nGOING BACK...");
                    Thread.Sleep(2000);
                    PlayerVsBotOptions();

                    break;
                default:
                    InvalidChoice();
                    BotDifficulty();
                    break;
            }
        }

        public static void UsersDataHistory(string username)
        {
            DisplayTicTacToe();

            foreach (string i in loggedIn)
            {
                Console.WriteLine(i);
            }

            Console.Write("\nChoose from [1-4]: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ContinueMatch(username);
                    break;
                case 2:
                    ChangeDifficulty(username);
                    Thread.Sleep(2000);
                    UsersDataHistory(username);
                    break;
                case 3:
                    ChangeUsername(username);
                    break;
                case 4:
                    Console.WriteLine("\nGOING BACK TO MENU...");
                    Thread.Sleep(2000);
                    break;
                default:
                    InvalidChoice();
                    UsersDataHistory(username);
                    break;
            }
        }

        public static void BotIsThinking()
        {
            Console.WriteLine($"\nBOT ({chosenDifficulty}) IS THINKING...");
            Thread.Sleep(2000);
        }

        public static void EnemyBot(int choice)
        {
            p1 = InputUsername().ToUpper();
            p2 = "BOT";

            while (process.ValidateUsername(p1))
            {
                Console.WriteLine("\nThe username is already taken!");
                Thread.Sleep(2000);

                DisplayTicTacToe();

                foreach (string i in difficulties)
                {
                    Console.WriteLine(i);
                }

                Console.Write($"\nChoose from [1-4]: {choice}\n");

                p1 = InputUsername().ToUpper();
            }

            DisplayTicTacToe();

            RefreshUI(p1, p2);
        }

        public static void ContinueMatch(string username)
        {
            p1 = username.ToUpper();
            p2 = "BOT";

            string[] data = process.GetPlayerScoreHistory(username);

            chosenDifficulty = data[0];
            process.score1 = Convert.ToInt32(data[1]);
            process.score2 = Convert.ToInt32(data[2]);

            continueMatch = true;

            DisplayTicTacToe();

            RefreshUI(p1, p2);
        }

        public static void ChangeDifficulty(string username)
        {
            Console.WriteLine("\nChanging difficulty resets the scores to 0.");
            Console.WriteLine("\nAre you sure want to change difficulty? Yes/No\n");
            string yesNo = Console.ReadLine();

            if (yesNo.Equals("Yes", StringComparison.OrdinalIgnoreCase) || yesNo.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                string[,] diff = { { "Medium", "Hard", "Cancel" }, { "Easy", "Hard", "Cancel" }, { "Easy", "Medium", "Cancel" } };

                int index = 0;

                DisplayTicTacToe();

                if (process.GetPlayerScoreHistory(username)[0] == "EASY")
                {
                    Console.WriteLine("CURRENT DIFFICULTY: EASY\n");

                    for (int i = 0; i < 3; i++)
                        Console.WriteLine($"[{i + 1}] {diff[0, i]}");

                    index = 0;
                } 
                else if (process.GetPlayerScoreHistory(username)[0] == "MEDIUM")
                {
                    Console.WriteLine("CURRENT DIFFICULTY: MEDIUM\n");

                    for (int i = 0; i < 3; i++)
                        Console.WriteLine($"[{i + 1}] {diff[1, i]}");

                    index = 1;
                }
                else if (process.GetPlayerScoreHistory(username)[0] == "HARD")
                {
                    Console.WriteLine("CURRENT DIFFICULTY: HARD\n");

                    for (int i = 0; i < 3; i++)
                        Console.WriteLine($"[{i + 1}] {diff[2, i]}");

                    index = 2;
                }
                Console.Write("\nChoose from [1-3]: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.WriteLine($"\nCHANGING DIFFICULTY TO {diff[index, 0].ToUpper()}...");
                        process.UpdateDifficulty(username, diff[index, 0].ToUpper());
                        break;
                    case 2:
                        Console.WriteLine($"\nCHANGING DIFFICULTY TO {diff[index, 1].ToUpper()}...");
                        process.UpdateDifficulty(username, diff[index, 1].ToUpper());
                        break;
                    case 3:
                        Console.WriteLine("\nCANCELLING...");
                        break;
                    default:
                        InvalidChoice();
                        ChangeDifficulty(username);
                        break;
                }
            }
            else
                Console.WriteLine("\nCANCELLING...");
        }

        public static void ChangeUsername(string username)
        {
            DisplayTicTacToe();

            Console.WriteLine($"CURRENT USERNAME: {username}");

            Console.Write("\nEnter new username: ");
            string newUser = Console.ReadLine().ToUpper();

            while (process.ValidateUsername(newUser))
            {
                if(username ==  newUser)
                    Console.WriteLine("\nYou cannot change to your current username!");
                else
                    Console.WriteLine("\nThe username is already taken!");
                Thread.Sleep(2000);

                DisplayTicTacToe();

                Console.WriteLine($"CURRENT USERNAME: {username}");

                Console.Write("\nEnter new username: ");
                newUser = Console.ReadLine().ToUpper();
            }

            Console.WriteLine($"\nCHANGING USERNAME TO {newUser}...");
            process.UpdateUsername(username, newUser);
            Thread.Sleep(2000);

            UsersDataHistory(newUser);
        }
    }
}
