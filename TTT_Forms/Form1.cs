namespace TTT_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(85, 88, 121);
            this.FormClosed += (s, e) => Application.Exit();

            Components();
        }

        public void Components()
        {
            pb_home_page.Image = Image.FromFile("pages\\home_page.png");
            pb_home_page.SizeMode = PictureBoxSizeMode.StretchImage;

            Image enterPlay = Image.FromFile("icons\\play.png");
            Image leavePlay = Image.FromFile("icons\\play_hover.png");
            pb_btn_play.BackColor = Color.Transparent;
            pb_btn_play.Image = enterPlay;
            pb_btn_play.MouseEnter += (s, e) => pb_btn_play.Image = leavePlay;
            pb_btn_play.MouseLeave += (s, e) => pb_btn_play.Image = enterPlay;
            pb_btn_play.Click += Play_Button;
        }

        private void Play_Button(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
