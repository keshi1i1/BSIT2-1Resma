namespace TTT_Forms
{
    partial class New_Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pb_btn_hard = new PictureBox();
            pb_btn_medium = new PictureBox();
            pb_btn_easy = new PictureBox();
            pb_btn_back = new PictureBox();
            pb_newgame_page = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_btn_hard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_medium).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_easy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_newgame_page).BeginInit();
            SuspendLayout();
            // 
            // pb_btn_hard
            // 
            pb_btn_hard.Cursor = Cursors.Hand;
            pb_btn_hard.Location = new Point(155, 460);
            pb_btn_hard.Name = "pb_btn_hard";
            pb_btn_hard.Size = new Size(200, 70);
            pb_btn_hard.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_hard.TabIndex = 11;
            pb_btn_hard.TabStop = false;
            // 
            // pb_btn_medium
            // 
            pb_btn_medium.Cursor = Cursors.Hand;
            pb_btn_medium.Location = new Point(155, 345);
            pb_btn_medium.Name = "pb_btn_medium";
            pb_btn_medium.Size = new Size(200, 70);
            pb_btn_medium.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_medium.TabIndex = 10;
            pb_btn_medium.TabStop = false;
            // 
            // pb_btn_easy
            // 
            pb_btn_easy.Cursor = Cursors.Hand;
            pb_btn_easy.Location = new Point(155, 230);
            pb_btn_easy.Name = "pb_btn_easy";
            pb_btn_easy.Size = new Size(200, 70);
            pb_btn_easy.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_easy.TabIndex = 9;
            pb_btn_easy.TabStop = false;
            // 
            // pb_btn_back
            // 
            pb_btn_back.Cursor = Cursors.Hand;
            pb_btn_back.Location = new Point(20, 630);
            pb_btn_back.Name = "pb_btn_back";
            pb_btn_back.Size = new Size(50, 50);
            pb_btn_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_back.TabIndex = 8;
            pb_btn_back.TabStop = false;
            // 
            // pb_newgame_page
            // 
            pb_newgame_page.Location = new Point(0, 0);
            pb_newgame_page.Name = "pb_newgame_page";
            pb_newgame_page.Size = new Size(510, 700);
            pb_newgame_page.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_newgame_page.TabIndex = 7;
            pb_newgame_page.TabStop = false;
            // 
            // New_Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_hard);
            Controls.Add(pb_btn_medium);
            Controls.Add(pb_btn_easy);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_newgame_page);
            Name = "New_Game";
            StartPosition = FormStartPosition.Manual;
            Text = "New_Game";
            ((System.ComponentModel.ISupportInitialize)pb_btn_hard).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_medium).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_easy).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_newgame_page).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_btn_hard;
        private PictureBox pb_btn_medium;
        private PictureBox pb_btn_easy;
        private PictureBox pb_btn_back;
        private PictureBox pb_newgame_page;
    }
}