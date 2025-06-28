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
    public partial class Guide : Form
    {
        public Guide()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_guide_page.Image = Image.FromFile("pages\\guide_page.png");
            pb_guide_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterBack = Image.FromFile("icons\\back.png");
            Image leaveBack = Image.FromFile("icons\\back_hover.png");
            pb_btn_back.BackColor = Color.Transparent;
            pb_btn_back.Image = enterBack;
            pb_btn_back.MouseEnter += (s, e) => pb_btn_back.Image = leaveBack;
            pb_btn_back.MouseLeave += (s, e) => pb_btn_back.Image = enterBack;
            pb_btn_back.Click += Back_Button;

            tb_guide.BackColor = this.BackColor;
            tb_guide.ForeColor = Color.FromArgb(152, 161, 188);
        }
        private void Back_Button(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Location = this.Location;
            menu.Show();
            this.Hide();
        }
    }
}
