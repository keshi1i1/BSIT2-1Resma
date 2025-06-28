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

namespace TTT_Forms
{
    public partial class TicTacToe_UI : Form
    {
        TTT_Process process = new TTT_Process();

        PictureBox[] buttons;

        Image camouflage = Image.FromFile("icons\\transparent_bg.png");
        Image X = Image.FromFile("icons\\x_icon.png");
        Image O = Image.FromFile("icons\\o_icon.png");

        bool p1turn = RNGTurn();

        public TicTacToe_UI(string player1, string player2)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            lbl_player1.Text = player1.ToUpper();
            lbl_player2.Text = player2.ToUpper();

            lbl_score1.Text = Convert.ToString(process.score1);
            lbl_score2.Text = Convert.ToString(process.score2);

            Components();

            buttons = new PictureBox[] { pb_btn1, pb_btn2, pb_btn3, pb_btn4, pb_btn5, pb_btn6, pb_btn7, pb_btn8, pb_btn9 };

            foreach (var btn in buttons)
            {
                lbl_turn.Text = $"{lbl_player1.Text}'s TURN";

                btn.Click += ButtonClick;
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

        private void ButtonClick(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked.Image != camouflage)
                return;

            clicked.Image = (p1turn) ? X : O;
            if (p1turn)
            {
                p1turn = false;
                lbl_turn.Text = $"{lbl_player2.Text}'s TURN";
            }
            else
            {
                p1turn = true;
                lbl_turn.Text = $"{lbl_player1.Text}'s TURN";
            }

            CheckForWinner();
        }
        private void CheckForWinner()
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

        private void CheckForDraw()
        {
            if (buttons.All(b => b.Image != camouflage))
            {
                MessageBox.Show("Draw!");
                ResetBoard();
            }
        }

        private void EndGame(Image winner)
        {
            if(winner == X)
                MessageBox.Show($"X wins!");
            else if (winner == O)
                MessageBox.Show($"O wins!");
            ResetBoard();
        }

        private void ResetBoard()
        {
            foreach (var btn in buttons)
                btn.Image = camouflage;

            p1turn = true;
        }

        public void Components()
        {
            pb_ui_page.Image = Image.FromFile("pages\\ui_page.png");
            pb_ui_page.SizeMode = PictureBoxSizeMode.StretchImage;

            pb_btn1.Image = camouflage;
            pb_btn2.Image = camouflage;
            pb_btn3.Image = camouflage;
            pb_btn4.Image = camouflage;
            pb_btn5.Image = camouflage;
            pb_btn6.Image = camouflage;
            pb_btn7.Image = camouflage;
            pb_btn8.Image = camouflage;
            pb_btn9.Image = camouflage;

            lbl_player1.BackColor = Color.Transparent;
            lbl_player1.ForeColor = Color.FromArgb(152, 161, 188);

            lbl_player2.BackColor = Color.Transparent;
            lbl_player2.ForeColor = Color.FromArgb(152, 161, 188);

            lbl_score1.BackColor = Color.Transparent;
            lbl_score1.ForeColor = Color.FromArgb(152, 161, 188);

            lbl_score2.BackColor = Color.Transparent;
            lbl_score2.ForeColor = Color.FromArgb(152, 161, 188);

            lbl_turn.BackColor = Color.Transparent;
            lbl_turn.ForeColor = Color.FromArgb(152, 161, 188);
        }


    }
}