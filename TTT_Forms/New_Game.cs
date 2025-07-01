using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTT_BusinessLogic;

namespace TTT_Forms
{
    public partial class New_Game : Form
    {
        TTT_Process process = new TTT_Process();
        public New_Game()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_newgame_page.Image = Image.FromFile("pages\\newgame_page.png");
            pb_newgame_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterEasy = Image.FromFile("icons\\easy.png");
            Image leaveEasy = Image.FromFile("icons\\easy_hover.png");
            pb_btn_easy.BackColor = Color.Transparent;
            pb_btn_easy.Image = enterEasy;
            pb_btn_easy.MouseEnter += (s, e) => pb_btn_easy.Image = leaveEasy;
            pb_btn_easy.MouseLeave += (s, e) => pb_btn_easy.Image = enterEasy;
            pb_btn_easy.Click += Easy_Button;

            Image enterMedium = Image.FromFile("icons\\medium.png");
            Image leaveMedium = Image.FromFile("icons\\medium_hover.png");
            pb_btn_medium.BackColor = Color.Transparent;
            pb_btn_medium.Image = enterMedium;
            pb_btn_medium.MouseEnter += (s, e) => pb_btn_medium.Image = leaveMedium;
            pb_btn_medium.MouseLeave += (s, e) => pb_btn_medium.Image = enterMedium;
            pb_btn_medium.Click += Medium_Button;

            Image enterHard = Image.FromFile("icons\\hard.png");
            Image leaveHard = Image.FromFile("icons\\hard_hover.png");
            pb_btn_hard.BackColor = Color.Transparent;
            pb_btn_hard.Image = enterHard;
            pb_btn_hard.MouseEnter += (s, e) => pb_btn_hard.Image = leaveHard;
            pb_btn_hard.MouseLeave += (s, e) => pb_btn_hard.Image = enterHard;
            pb_btn_hard.Click += Hard_Button;
        }

        private void Back_Button(object sender, EventArgs e)
        {
            PVE pve = new PVE();
            pve.Location = this.Location;
            pve.Show();
            this.Hide();
        }

        private void Easy_Button(object sender, EventArgs e)
        {
            NewGame("EASY");
        }

        private void Medium_Button(object sender, EventArgs e)
        {
            NewGame("MEDIUM");
        }

        private void Hard_Button(object sender, EventArgs e)
        {
            NewGame("HARD");
        }

        public void NewGame(string difficulty)
        {
            string username = CustomMessageBox.ShowInput(this, "ENTER YOUR USERNAME", "PLAYER 1", "INPUT");

            if (process.ValidateUsername(username.ToUpper()))
            {
                CustomMessageBox.Show(this, "USERNAME IS ALREADY TAKEN!", "ERROR", "LONG");
                NewGame(difficulty);
            }
            else if (username == "CANCEL");

            else if (username == "")
                CustomMessageBox.Show(this, "INVALID INPUT!", "ERROR", "OK");

            else
            {
                TicTacToe_UI ui = new TicTacToe_UI(username, difficulty, false);
                ui.Location = this.Location;
                ui.Show();
                this.Hide();
            }
        }
    }
}
