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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_history_page.Image = Image.FromFile("pages\\history_page.png");
            pb_history_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterPvPScores = Image.FromFile("icons\\pvp_scores.png");
            Image leavePvPScores = Image.FromFile("icons\\pvp_scores_hover.png");
            pb_btn_pvp_scores.BackColor = Color.Transparent;
            pb_btn_pvp_scores.Image = enterPvPScores;
            pb_btn_pvp_scores.MouseEnter += (s, e) => pb_btn_pvp_scores.Image = leavePvPScores;
            pb_btn_pvp_scores.MouseLeave += (s, e) => pb_btn_pvp_scores.Image = enterPvPScores;
            pb_btn_pvp_scores.Click += PvP_Scores_Button;

            Image enterPvEScores = Image.FromFile("icons\\pve_scores.png");
            Image leavePvEScores = Image.FromFile("icons\\pve_scores_hover.png");
            pb_btn_pve_scores.BackColor = Color.Transparent;
            pb_btn_pve_scores.Image = enterPvEScores;
            pb_btn_pve_scores.MouseEnter += (s, e) => pb_btn_pve_scores.Image = leavePvEScores;
            pb_btn_pve_scores.MouseLeave += (s, e) => pb_btn_pve_scores.Image = enterPvEScores;
            pb_btn_pve_scores.Click += PvE_Scores_Button;
        }
        private void Back_Button(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Location = this.Location;
            menu.Show();
            this.Hide();
        }

        private void PvP_Scores_Button(object sender, EventArgs e)
        {
            PvP_Scores pvp_scores = new PvP_Scores();
            pvp_scores.Location = this.Location;
            pvp_scores.Show();
            this.Hide();
        }

        private void PvE_Scores_Button(object sender, EventArgs e)
        {
            PvE_Scores pve_scores = new PvE_Scores();
            pve_scores.Location = this.Location;
            pve_scores.Show();
            this.Hide();
        }
    }
}
