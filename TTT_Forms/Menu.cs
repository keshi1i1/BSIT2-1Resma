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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_menu_page.Image = Image.FromFile("pages\\menu_page.png");
            pb_menu_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterGuide = Image.FromFile("icons\\guide.png");
            Image leaveGuide = Image.FromFile("icons\\guide_hover.png");
            pb_btn_guide.BackColor = Color.Transparent;
            pb_btn_guide.Image = enterGuide;
            pb_btn_guide.MouseEnter += (s, e) => pb_btn_guide.Image = leaveGuide;
            pb_btn_guide.MouseLeave += (s, e) => pb_btn_guide.Image = enterGuide;
            //Menu menu = new Menu();
            //pb_btn_guide.Click += (s, e) => menu.Show();
            //pb_btn_guide.Click += (s, e) => this.Hide();

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            Image enterPvP = Image.FromFile("icons\\pvp.png");
            Image leavePvP = Image.FromFile("icons\\pvp_hover.png");
            pb_btn_pvp.BackColor = Color.Transparent;
            pb_btn_pvp.Image = enterPvP;
            pb_btn_pvp.MouseEnter += (s, e) => pb_btn_pvp.Image = leavePvP;
            pb_btn_pvp.MouseLeave += (s, e) => pb_btn_pvp.Image = enterPvP;
            pb_btn_pvp.Click += PvP_Button;

            Image enterPvE = Image.FromFile("icons\\pve.png");
            Image leavePvE = Image.FromFile("icons\\pve_hover.png");
            pb_btn_pve.BackColor = Color.Transparent;
            pb_btn_pve.Image = enterPvE;
            pb_btn_pve.MouseEnter += (s, e) => pb_btn_pve.Image = leavePvE;
            pb_btn_pve.MouseLeave += (s, e) => pb_btn_pve.Image = enterPvE;
            //Form1 form = new Form1();
            //pb_btn_back.Click += (s, e) => form.Show();
            //pb_btn_back.Click += (s, e) => this.Close();

            Image enterHistory = Image.FromFile("icons\\history.png");
            Image leaveHistory = Image.FromFile("icons\\history_hover.png");
            pb_btn_history.BackColor = Color.Transparent;
            pb_btn_history.Image = enterHistory;
            pb_btn_history.MouseEnter += (s, e) => pb_btn_history.Image = leaveHistory;
            pb_btn_history.MouseLeave += (s, e) => pb_btn_history.Image = enterHistory;
            //Form1 form = new Form1();
            //pb_btn_back.Click += (s, e) => form.Show();
            //pb_btn_back.Click += (s, e) => this.Close();
        }

        private void Back_Button(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void PvP_Button(object sender, EventArgs e)
        {
            PVP pvp = new PVP();
            pvp.Show();
            this.Hide();
        }
    }
}
    