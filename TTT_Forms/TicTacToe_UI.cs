using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTT_BusinessLogic;
using TTT_History;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TTT_Forms
{
    public partial class TicTacToe_UI : Form
    {
        TTT_Process process = new TTT_Process();

        PictureBox[] buttons;
        Label[] labels;

        Image camouflage = Image.FromFile("icons\\invisible.png");
        Image X = Image.FromFile("icons\\x_icon.png");
        Image O = Image.FromFile("icons\\o_icon.png");

        Image first = null, second = null, third = null;

        static bool p1turn = RNGTurn(), continueMatch = false;

        string name = "", player1 = "", player2 = "";

        public string chosenDifficulty = "";

        public int score1 = 0, score2 = 0;

        public TicTacToe_UI(string p1, string p2, bool continueGame)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            player1 = p1.ToUpper();

            if (!continueGame)
            {
                if (p2 == "EASY" || p2 == "MEDIUM" || p2 == "HARD")
                {
                    chosenDifficulty = p2;
                    player2 = "BOT";
                }
                else
                    player2 = p2.ToUpper();
            }
            else
            {
                player2 = "BOT";

                string[] data = process.GetPlayerScoreHistory(player1);

                chosenDifficulty = data[0];
                score1 = Convert.ToInt32(data[1]);
                score2 = Convert.ToInt32(data[2]);

                continueMatch = continueGame;
            }

            lbl_player1.Text = player1;
            lbl_player2.Text = player2;

            lbl_score1.Text = score1.ToString();
            lbl_score2.Text = score2.ToString();

            Components();

            AllPictureButtons();

            WhosTurn();

            if(Player2IsBot())
            {
                foreach (var btn in buttons)
                {
                    btn.Click += ButtonClick;
                }
                if (!p1turn)
                {
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 2000;
                    timer.Tick += (s, e) =>
                    {
                        timer.Stop();
                        EasyBotAI();
                    };
                    timer.Start();
                }
            }
            else
            {
                foreach (var btn in buttons)
                {
                    btn.Click += ButtonClick;
                }
            }
        }

        public static bool RNGTurn()
        {
            Random r = new Random();
            int rng = r.Next(1, 11);

            if (rng > 5)
                //Player X's turn
                return true;
            else
                //Player O's turn
                return false;
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked.Image != camouflage)
                return;

            clicked.Image = (p1turn) ? X : O;

            p1turn = !p1turn;
            WhosTurn();
            CheckForWinner();

            if (Player2IsBot())
            {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    if(chosenDifficulty == "EASY")
                        EasyBotAI();
                    else if(chosenDifficulty == "MEDIUM")
                        MediumBotAI();
                    else if (chosenDifficulty == "HARD")
                        HardBotAI();
                };
                timer.Start();
            }
        }

        public void CheckForWinner()
        {
            Image[,] oX = new Image[3, 3];

            for (int i = 0; i < 9; i++)
                oX[i / 3, i % 3] = buttons[i].Image;

            for (int i = 0; i < 3; i++)
            {
                if (oX[i, 0] != camouflage && oX[i, 0] == oX[i, 1] && oX[i, 1] == oX[i, 2])
                {
                    EndGame(oX[i, 0]);
                    return;
                }
                else if (oX[0, i] != camouflage && oX[0, i] == oX[1, i] && oX[1, i] == oX[2, i])
                {
                    EndGame(oX[0, i]);
                    return;
                }
            }

            if (oX[0, 0] != camouflage && oX[0, 0] == oX[1, 1] && oX[1, 1] == oX[2, 2])
            {
                EndGame(oX[0, 0]);
                return;
            }
            else if (oX[0, 2] != camouflage && oX[0, 2] == oX[1, 1] && oX[1, 1] == oX[2, 0])
            {
                EndGame(oX[0, 2]);
                return;
            }

            CheckForDraw();
        }

        public void CheckForDraw()
        {
            if (buttons.All(b => b.Image != camouflage))
            {
                DialogResult result = DialogResult.No;

                lbl_turn.Text = "MATCH DRAW!";
                CustomMessageBox.Show(this, "MATCH DRAW!", "DRAW", "OK");
                result = CustomMessageBox.Show(this, "DO YOU WANT A REMATCH?", "CONFIRMATION", "YES/NO");

                YesNoResult(result);
            }
        }

        public void EndGame(Image winner)
        {
            DialogResult result = DialogResult.No;

            if (winner == X)
            {
                score1 = Convert.ToInt32(lbl_score1.Text);
                score1++;
                lbl_score1.Text = score1.ToString();
                lbl_turn.Text = $"[X] {lbl_player1.Text} WON!";
                CustomMessageBox.Show(this, $"[X] {lbl_player1.Text} WON!", "WINNER", "OK");
                result = CustomMessageBox.Show(this, "DO YOU WANT A REMATCH?", "CONFIRMATION", "YES/NO");
            }
            else if (winner == O)
            {
                score2 = Convert.ToInt32(lbl_score2.Text);
                score2++;
                lbl_score2.Text = score2.ToString();
                if (Player2IsBot())
                {
                    lbl_turn.Text = $"[O] {chosenDifficulty}-BOT WON!";
                    CustomMessageBox.Show(this, $"[O] {chosenDifficulty}-BOT WON!", "WINNER", "OK");
                }
                else
                {
                    lbl_turn.Text = $"[O] {lbl_player2.Text} WON!";
                    CustomMessageBox.Show(this, $"[O] {lbl_player2.Text} WON!", "WINNER", "OK");
                }
                result = CustomMessageBox.Show(this, "DO YOU WANT A REMATCH?", "CONFIRMATION", "YES/NO");
            }
            YesNoResult(result);
        }

        public void YesNoResult(DialogResult result)
        {
            if (result == DialogResult.Yes)
            {
                CustomMessageBox.Show(this, "RESTARTING THE MATCH...", "LOADING", "LOADING");
                ResetBoard();
            }
            else
            {
                CustomMessageBox.Show(this, "RETURNING TO HOME...", "LOADING", "LOADING");
                Menu menu = new Menu();

                if (Player2IsBot())
                {
                    if (continueMatch)
                    {
                        process.UpdatePvEScoreHistory(lbl_player1.Text, score1, score2);
                        continueMatch = false;
                        Continue cont = new Continue(lbl_player1.Text);
                        cont.Location = this.Location;
                        cont.Show();
                        this.Hide();
                    }
                    else
                    {
                        process.AddPvEScoreHistory(lbl_player1.Text, chosenDifficulty, score1, score2);
                        menu.Location = this.Location;
                        menu.Show();
                        this.Hide();
                    }
                }
                else
                {
                    process.AddPvPScoreHistory(lbl_player1.Text, lbl_player2.Text, score1, score2);
                    menu.Location = this.Location;
                    menu.Show();
                    this.Hide();
                }

                score1 = 0;
                score2 = 0;
            }
        }

        public void ResetBoard()
        {
            foreach (var btn in buttons)
                btn.Image = camouflage;

            WhosTurn();
        }

        public void WhosTurn()
        {
            if (p1turn)
                name = $"{lbl_player1.Text}";
            else
                if (Player2IsBot())
                    name = $"{chosenDifficulty}-BOT";
                else
                    name = $"{lbl_player2.Text}";

            if (p1turn)
                lbl_turn.Text = $"[X] {name}'s TURN!";
            else
                if (Player2IsBot())
                    lbl_turn.Text = $"[O] {chosenDifficulty}-BOT'S TURN!";
                else
                    lbl_turn.Text = $"[O] {name}'s TURN!";
        }

        public void EasyBotAI()
        {
            Random rng = new Random();
            int choice;

            AllPictureButtons();

            for (int i = 0; i < 100; i++)
            {
                choice = rng.Next(0, 9);

                if (buttons[choice].Image == camouflage && !p1turn)
                {
                    buttons[choice].Image = O;

                    p1turn = true;
                    WhosTurn();
                    CheckForWinner();
                    return;
                }
            }
        }

        public void MediumBotAI()
        {
            int[] position;
            int choice;

            AllPictureButtons();

            for (int i = 0; i < 100; i++)
            {
                position = ThirdCircleFinder();
                choice = position[0] * 3 + position[1];

                if (buttons[choice].Image == camouflage && !p1turn)
                {
                    buttons[choice].Image = O;

                    p1turn = true;
                    WhosTurn();
                    CheckForWinner();
                    return;
                }
            }
        }

        public void HardBotAI()
        {
            int[] position;
            int choice = 0;

            AllPictureButtons();

            for (int i = 0; i < 100; i++)
            {
                if (buttons[4].Image == camouflage)
                {
                    buttons[4].Image = O;

                    p1turn = true;
                    WhosTurn();
                    CheckForWinner();
                    return;
                }
                else
                {
                    if (!PossibleWin())
                    {
                        position = PriorityNumberFinder();
                        choice = position[0] * 3 + position[1];
                    }
                    else
                    {
                        position = ThirdCircleFinder();
                        choice = position[0] * 3 + position[1];
                    }

                    if (buttons[choice].Image == camouflage && !p1turn)
                    {
                        buttons[choice].Image = O;

                        p1turn = true;
                        WhosTurn();
                        CheckForWinner();
                        return;
                    }
                }
            }
        }

        public int[] ThirdCircleFinder()
        {
            Image[,] oX = new Image[3, 3];

            for (int i = 0; i < 9; i++)
                oX[i / 3, i % 3] = buttons[i].Image;

            int[] position = new int[2];

            for (int i = 0; i < 3; i++)
            {
                if (oX[i, 0] != X && oX[i, 1] == O && oX[i, 1] == oX[i, 2])
                {
                    position = [ i, 0 ];
                    return position;
                }
                else if (oX[i, 1] != X && oX[i, 2] == O && oX[i, 2] == oX[i, 0])
                {
                    position = [i, 1];
                    return position;
                }
                else if (oX[i, 2] != X && oX[i, 0] == O && oX[i, 0] == oX[i, 1])
                {
                    position = [i, 2];
                    return position;
                }
                else if (oX[0, i] != X && oX[1, i] == O && oX[1, i] == oX[2, i])
                {
                    position = [0, i];
                    return position;
                }
                else if (oX[1, i] != X && oX[2, i] == O && oX[2, i] == oX[0, i])
                {
                    position = [1, i];
                    return position;
                }
                else if (oX[2, i] != X && oX[0, i] == O && oX[0, i] == oX[1, i])
                {
                    position = [2, i];
                    return position;
                }
            }

            if (oX[0, 0] != X && oX[1, 1] == O && oX[1, 1] == oX[2, 2])
            {
                position = [0, 0];
                return position;
            }
            else if (oX[1, 1] != X && oX[2, 2] == O && oX[2, 2] == oX[0, 0])
            {
                position = [1, 1];
                return position;
            }
            else if (oX[2, 2] != X && oX[0, 0] == O && oX[0, 0] == oX[1, 1])
            {
                position = [2, 2];
                return position;
            }
            else if (oX[0, 2] != X && oX[1, 1] == O && oX[1, 1] == oX[2, 0])
            {
                position = [0, 2];
                return position;
            }
            else if (oX[1, 1] != X && oX[2, 0] == O && oX[2, 0] == oX[0, 2])
            {
                position = [1, 1];
                return position;
            }
            else if (oX[2, 0] != X && oX[0, 2] == O && oX[0, 2] == oX[1, 1])
            {
                position = [2, 0];
                return position;
            }
            return XBlocker();
        }

        public int[] XBlocker()
        {
            Random rng = new Random();
            Image[,] oX = new Image[3, 3];

            for (int i = 0; i < 9; i++)
                oX[i / 3, i % 3] = buttons[i].Image;

            int[] position = new int[2];

            for (int i = 0; i < 3; i++)
            {
                if (oX[i, 0] != O && oX[i, 1] == X && oX[i, 1] == oX[i, 2])
                {
                    position = [i, 0];
                    return position;
                }
                else if (oX[i, 1] != O && oX[i, 2] == X && oX[i, 2] == oX[i, 0])
                {
                    position = [i, 1];
                    return position;
                }
                else if (oX[i, 2] != O && oX[i, 0] == X && oX[i, 0] == oX[i, 1])
                {
                    position = [i, 2];
                    return position;
                }
                else if (oX[0, i] != O && oX[1, i] == X && oX[1, i] == oX[2, i])
                {
                    position = [0, i];
                    return position;
                }
                else if (oX[1, i] != O && oX[2, i] == X && oX[2, i] == oX[0, i])
                {
                    position = [1, i];
                    return position;
                }
                else if (oX[2, i] != O && oX[0, i] == X && oX[0, i] == oX[1, i])
                {
                    position = [2, i];
                    return position;
                }
            }

            if (oX[0, 0] != O && oX[1, 1] == X && oX[1, 1] == oX[2, 2])
            {
                position = [0, 0];
                return position;
            }
            else if (oX[1, 1] != O && oX[2, 2] == X && oX[2, 2] == oX[0, 0])
            {
                position = [1, 1];
                return position;
            }
            else if (oX[2, 2] != O && oX[0, 0] == X && oX[0, 0] == oX[1, 1])
            {
                position = [2, 2];
                return position;
            }
            else if (oX[0, 2] != O && oX[1, 1] == X && oX[1, 1] == oX[2, 0])
            {
                position = [0, 2];
                return position;
            }
            else if (oX[1, 1] != O && oX[2, 0] == X && oX[2, 0] == oX[0, 2])
            {
                position = [1, 1];
                return position;
            }
            else if (oX[2, 0] != O && oX[0, 2] == X && oX[0, 2] == oX[1, 1])
            {
                position = [2, 0];
                return position;
            }

            int[] random = { rng.Next(0, 3), rng.Next(0, 3) };
            return random;
        }

        public bool PossibleWin()
        {
            Random rng = new Random();
            Image[,] oX = new Image[3, 3];

            for (int i = 0; i < 9; i++)
                oX[i / 3, i % 3] = buttons[i].Image;

            int[] position = new int[2];

            for (int i = 0; i < 3; i++)
            {
                if (oX[i, 0] != O && oX[i, 0] != X && oX[i, 1] == oX[i, 2])
                    return true;

                else if (oX[i, 1] != O && oX[i, 1] != X && oX[i, 2] == oX[i, 0])
                    return true;
                
                else if (oX[i, 2] != O && oX[i, 2] != X && oX[i, 0] == oX[i, 1])
                    return true;
                
                else if (oX[0, i] != O && oX[0, i] != X && oX[1, i] == oX[2, i])
                    return true;
                
                else if (oX[1, i] != O && oX[1, i] != X && oX[2, i] == oX[0, i])
                    return true;
                
                else if (oX[2, i] != O && oX[2, i] != X && oX[0, i] == oX[1, i])
                    return true;
            }

            if (oX[0, 0] != O && oX[0, 0] != X && oX[1, 1] == oX[2, 2])
                return true;
            
            else if (oX[1, 1] != O && oX[1, 1] != X && oX[2, 2] == oX[0, 0])
                return true;
            
            else if (oX[2, 2] != O && oX[2, 2] != X && oX[0, 0] == oX[1, 1])
                return true;
            
            else if (oX[0, 2] != O && oX[0, 2] != X && oX[1, 1] == oX[2, 0])
                return true;
            
            else if (oX[1, 1] != O && oX[1, 1] != X && oX[2, 0] == oX[0, 2])
                return true;
            
            else if (oX[2, 0] != O && oX[2, 0] != X && oX[0, 2] == oX[1, 1])
                return true;

            return false;
        }

        public int[] PriorityNumberFinder()
        {
            Random rng = new Random();

            Image[,] oX = new Image[3, 3];
            for (int i = 0; i < 9; i++)
                oX[i / 3, i % 3] = buttons[i].Image;

            Image[] priority1 = { oX[0, 0], oX[0, 2], oX[2, 0], oX[2, 2] }, priority2 = { oX[0, 1], oX[1, 0], oX[1, 2], oX[2, 1] };

            int[] position = new int[2];
            int index = 0;

            foreach (var image in oX)
            {
                if (oX[0, 0] == oX[0, 2] || oX[0, 2] == oX[2, 0] || oX[2, 0] == oX[2, 2] || oX[2, 2] == oX[0, 0])
                {
                    index = rng.Next(0, priority2.Length);

                    if (image == priority2[index])
                    {
                        if (image == oX[0, 1])
                            position = [0, 1];

                        else if (image == oX[1, 0])
                            position = [1, 0];

                        else if (image == oX[1, 2])
                            position = [1, 2];

                        else if (image == oX[2, 1])
                            position = [2, 1];

                        return position;
                    }
                }
                else
                {
                    index = rng.Next(0, priority1.Length);

                    if (image == priority1[index])
                    {
                        if (image == oX[0, 0])
                            position = [0, 0];

                        else if (image == oX[0, 2])
                            position = [0, 2];

                        else if (image == oX[2, 0])
                            position = [2, 0];

                        else if (image == oX[2, 2])
                            position = [2, 2];

                        return position;
                    }
                }
            }
            int[] random = { rng.Next(0, 3), rng.Next(0, 3) };
            return random;
        }

        public bool Player2IsBot()
        {
            if (lbl_player2.Text == "BOT")
                return true;
            else
                return false;
        }

        public void AllPictureButtons()
        {
            buttons = new PictureBox[] { pb_btn1, pb_btn2, pb_btn3, pb_btn4, pb_btn5, pb_btn6, pb_btn7, pb_btn8, pb_btn9 };
        }

        public void Components()
        {
            pb_ui_page.Image = Image.FromFile("pages\\ui_page.png");
            pb_ui_page.SizeMode = PictureBoxSizeMode.StretchImage;

            buttons = new PictureBox[] { pb_btn1, pb_btn2, pb_btn3, pb_btn4, pb_btn5, pb_btn6, pb_btn7, pb_btn8, pb_btn9 };

            foreach (var btn in buttons)
            {
                btn.Parent = pb_ui_page;
                btn.BackColor = Color.Transparent;
                btn.Image = camouflage;
            }

            labels = new Label[] { lbl_player1, lbl_player2, lbl_score1, lbl_score2, lbl_turn };

            foreach (var lbl in labels)
            {
                lbl.Parent = pb_ui_page;
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.FromArgb(152, 161, 188);
            }
        }
    }
}