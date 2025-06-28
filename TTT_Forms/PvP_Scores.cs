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
    public partial class PvP_Scores : Form
    {
        public PvP_Scores()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_pvpscores_page.Image = Image.FromFile("pages\\pvpscores_page.png");
            pb_pvpscores_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterRemove = Image.FromFile("icons\\remove_history.png");
            Image leaveRemove = Image.FromFile("icons\\remove_history_hover.png");
            pb_btn_pvp_remove.BackColor = Color.Transparent;
            pb_btn_pvp_remove.Image = enterRemove;
            pb_btn_pvp_remove.MouseEnter += (s, e) => pb_btn_pvp_remove.Image = leaveRemove;
            pb_btn_pvp_remove.MouseLeave += (s, e) => pb_btn_pvp_remove.Image = enterRemove;
            pb_btn_pvp_remove.Click += PvP_Remove_Button;

            Image enterClear = Image.FromFile("icons\\clear_history.png");
            Image leaveClear = Image.FromFile("icons\\clear_history_hover.png");
            pb_btn_pvp_clear.BackColor = Color.Transparent;
            pb_btn_pvp_clear.Image = enterClear;
            pb_btn_pvp_clear.MouseEnter += (s, e) => pb_btn_pvp_clear.Image = leaveClear;
            pb_btn_pvp_clear.MouseLeave += (s, e) => pb_btn_pvp_clear.Image = enterClear;
            pb_btn_pvp_clear.Click += PvP_Clear_Button;
        }

        private void Back_Button(object sender, EventArgs e)
        {
            History history = new History();
            history.Location = this.Location;
            history.Show();
            this.Hide();
        }

        private void PvP_Remove_Button(object sender, EventArgs e)
        {
        }

        private void PvP_Clear_Button(object sender, EventArgs e)
        {
        }
    }
}
