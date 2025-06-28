using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TTT_Forms
{
    public partial class PVE : Form
    {
        public PVE()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_pve_page.Image = Image.FromFile("pages\\pve_page.png");
            pb_pve_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterNew = Image.FromFile("icons\\new_game.png");
            Image leaveNew = Image.FromFile("icons\\new_game_hover.png");
            pb_btn_new.BackColor = Color.Transparent;
            pb_btn_new.Image = enterNew;
            pb_btn_new.MouseEnter += (s, e) => pb_btn_new.Image = leaveNew;
            pb_btn_new.MouseLeave += (s, e) => pb_btn_new.Image = enterNew;
            pb_btn_new.Click += New_Button;

            Image enterContinue = Image.FromFile("icons\\continue.png");
            Image leaveContinue = Image.FromFile("icons\\continue_hover.png");
            pb_btn_continue.BackColor = Color.Transparent;
            pb_btn_continue.Image = enterContinue;
            pb_btn_continue.MouseEnter += (s, e) => pb_btn_continue.Image = leaveContinue;
            pb_btn_continue.MouseLeave += (s, e) => pb_btn_continue.Image = enterContinue;
            pb_btn_continue.Click += Continue_Button;
        }
        private void Back_Button(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Location = this.Location;
            menu.Show();
            this.Hide();
        }

        private void New_Button(object sender, EventArgs e)
        {
            New_Game newgame = new New_Game();
            newgame.Location = this.Location;
            newgame.Show();
            this.Hide();
        }

        private void Continue_Button(object sender, EventArgs e)
        {
            Continue continueMatch = new Continue();
            continueMatch.Location = this.Location;
            continueMatch.Show();
            this.Hide();
        }
    }
}
