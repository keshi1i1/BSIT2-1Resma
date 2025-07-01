using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTT_BusinessLogic;
using TTT_History;

namespace TTT_Forms
{
    public partial class Continue : Form
    {
        TTT_Process process = new TTT_Process();

        string player1;

        public Continue(string username)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            player1 = username;

            pb_btn_continue.Click += Continue_Match_Button;
            pb_btn_difficulty.Click += Change_Difficulty_Button;
            pb_btn_username.Click += Change_Username_Button;
            Components();
        }

        public void Components()
        {
            pb_continue_page.Image = Image.FromFile("pages\\continue_page.png");
            pb_continue_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterContinue = Image.FromFile("icons\\continue.png");
            Image leaveContinue = Image.FromFile("icons\\continue_hover.png");
            pb_btn_continue.BackColor = Color.Transparent;
            pb_btn_continue.Image = enterContinue;
            pb_btn_continue.MouseEnter += (s, e) => pb_btn_continue.Image = leaveContinue;
            pb_btn_continue.MouseLeave += (s, e) => pb_btn_continue.Image = enterContinue;

            Image enterDifficulty = Image.FromFile("icons\\change_difficulty.png");
            Image leaveDifficulty = Image.FromFile("icons\\change_difficulty_hover.png");
            pb_btn_difficulty.BackColor = Color.Transparent;
            pb_btn_difficulty.Image = enterDifficulty;
            pb_btn_difficulty.MouseEnter += (s, e) => pb_btn_difficulty.Image = leaveDifficulty;
            pb_btn_difficulty.MouseLeave += (s, e) => pb_btn_difficulty.Image = enterDifficulty;

            Image enterUsername = Image.FromFile("icons\\change_username.png");
            Image leaveUsername = Image.FromFile("icons\\change_username_hover.png");
            pb_btn_username.BackColor = Color.Transparent;
            pb_btn_username.Image = enterUsername;
            pb_btn_username.MouseEnter += (s, e) => pb_btn_username.Image = leaveUsername;
            pb_btn_username.MouseLeave += (s, e) => pb_btn_username.Image = enterUsername;
        }

        private void Back_Button(object sender, EventArgs e)
        {
            PVE pve = new PVE();
            pve.Location = this.Location;
            pve.Show();
            this.Hide();
        }

        public void Continue_Match_Button(object sender, EventArgs e)
        {
            string p2 = "BOT";

            TicTacToe_UI ui = new TicTacToe_UI(player1, p2, true);
            ui.Location = this.Location;
            ui.Show();
            this.Hide();
        }

        private void Change_Difficulty_Button(object sender, EventArgs e)
        {
            Change_Difficulty();
        }

        public void Change_Difficulty()
        {
            TicTacToe_UI ui = new TicTacToe_UI(player1, "BOT", true);

            string difficulty = CustomMessageBox.ShowInput(this, "EASY | MEDIUM | HARD", $"BOT DIFFICULTY: {ui.chosenDifficulty}", "INPUT");

            if (difficulty.ToUpper() != ui.chosenDifficulty)
            {
                if(difficulty.ToUpper() == "EASY")
                    ConfirmationDifficultyChange(player1, "EASY");

                else if (difficulty.ToUpper() == "MEDIUM")
                    ConfirmationDifficultyChange(player1, "MEDIUM");
                
                else if (difficulty.ToUpper() == "HARD")
                    ConfirmationDifficultyChange(player1, "HARD");
            }

            else if (difficulty == "")
                CustomMessageBox.Show(this, "INVALID INPUT!", "ERROR", "OK");

            else if (difficulty.ToUpper() == ui.chosenDifficulty)
            {
                CustomMessageBox.Show(this, "SAME DIFFICULTY!", "ERROR", "LONG");
                Change_Difficulty();
            }
        }

        public void ConfirmationDifficultyChange(string player1, string difficulty)
        {
            DialogResult result = CustomMessageBox.Show(this, "CHANGING DIFFICULTY WILL RESET YOUR SCORES BACK TO 0.\nARE YOU SURE?", "CONFIRMATION", "FOOTLONG");

            if (result == DialogResult.Yes)
            {
                CustomMessageBox.Show(this, "CHANGING YOUR DIFFICULTY...", "LOADING", "LOADING2");
                process.UpdateDifficulty(player1, difficulty);
            }
            else
                CustomMessageBox.Show(this, "CANCELLING CHANGES...", "LOADING", "LOADING2");

        }

        private void Change_Username_Button(object sender, EventArgs e)
        {
        }
    }
}
