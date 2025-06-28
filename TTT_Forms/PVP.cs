using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTT_Forms
{
    public partial class PVP : Form
    {
        public PVP()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_pvp_page.Image = Image.FromFile("pages\\pvp_page.png");
            pb_pvp_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterStart = Image.FromFile("icons\\start_pvp.png");
            Image leaveStart = Image.FromFile("icons\\start_pvp_hover.png");
            pb_btn_start_pvp.BackColor = Color.Transparent;
            pb_btn_start_pvp.Image = enterStart;
            pb_btn_start_pvp.MouseEnter += (s, e) => pb_btn_start_pvp.Image = leaveStart;
            pb_btn_start_pvp.MouseLeave += (s, e) => pb_btn_start_pvp.Image = enterStart;
            //pb_btn_start_pvp.Click += PvP_Button;

            tb_player1.BackColor = Color.FromArgb(152, 161, 188);
            tb_player1.ForeColor = Color.FromArgb(120, 123, 155);
            tb_player1.MouseEnter += P1_Text_Box1;
            tb_player1.MouseLeave += P1_Text_Box2;
            tb_player1.ReadOnly = true;

            tb_player2.BackColor = Color.FromArgb(152, 161, 188);
            tb_player2.ForeColor = Color.FromArgb(120, 123, 155);
            tb_player2.MouseEnter += P2_Text_Box1;
            tb_player2.MouseLeave += P2_Text_Box2;
            tb_player2.ReadOnly = true;
        }
        private void Back_Button(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void P1_Text_Box1(object sender, EventArgs e)
        {
            if (tb_player1.Text == "Player 1")
            {
                tb_player1.Text = "";
                tb_player1.ReadOnly = false;
                tb_player1.ForeColor = this.BackColor;
            }
        }

        private void P1_Text_Box2(object sender, EventArgs e)
        {
            if (tb_player1.Text == "")
            {
                tb_player1.Text = "Player 1";
                tb_player1.ReadOnly = true;
                tb_player1.ForeColor = Color.FromArgb(120, 123, 155);
            }
        }

        private void P2_Text_Box1(object sender, EventArgs e)
        {
            if (tb_player2.Text == "Player 2")
            {
                tb_player2.Text = "";
                tb_player2.ReadOnly = false;
                tb_player2.ForeColor = this.BackColor;
            }
        }

        private void P2_Text_Box2(object sender, EventArgs e)
        {
            if (tb_player2.Text == "")
            {
                tb_player2.Text = "Player 2";
                tb_player2.ReadOnly = true;
                tb_player2.ForeColor = Color.FromArgb(120, 123, 155);
            }
        }
    }
}
