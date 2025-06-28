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
    public partial class PvE_Scores : Form
    {
        public PvE_Scores()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_pvescores_page.Image = Image.FromFile("pages\\pvescores_page.png");
            pb_pvescores_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterRemove = Image.FromFile("icons\\remove_history.png");
            Image leaveRemove = Image.FromFile("icons\\remove_history_hover.png");
            pb_btn_pve_remove.BackColor = Color.Transparent;
            pb_btn_pve_remove.Image = enterRemove;
            pb_btn_pve_remove.MouseEnter += (s, e) => pb_btn_pve_remove.Image = leaveRemove;
            pb_btn_pve_remove.MouseLeave += (s, e) => pb_btn_pve_remove.Image = enterRemove;
            pb_btn_pve_remove.Click += PvE_Remove_Button;

            Image enterClear = Image.FromFile("icons\\clear_history.png");
            Image leaveClear = Image.FromFile("icons\\clear_history_hover.png");
            pb_btn_pve_clear.BackColor = Color.Transparent;
            pb_btn_pve_clear.Image = enterClear;
            pb_btn_pve_clear.MouseEnter += (s, e) => pb_btn_pve_clear.Image = leaveClear;
            pb_btn_pve_clear.MouseLeave += (s, e) => pb_btn_pve_clear.Image = enterClear;
            pb_btn_pve_clear.Click += PvE_Clear_Button;
        }

        private void Back_Button(object sender, EventArgs e)
        {
            History history = new History();
            history.Location = this.Location;
            history.Show();
            this.Hide();
        }

        private void PvE_Remove_Button(object sender, EventArgs e)
        {
        }

        private void PvE_Clear_Button(object sender, EventArgs e)
        {
        }
    }
}
