namespace TTT_Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pb_home_page = new PictureBox();
            pb_btn_play = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_home_page).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_play).BeginInit();
            SuspendLayout();
            // 
            // pb_home_page
            // 
            pb_home_page.BackColor = Color.White;
            pb_home_page.Location = new Point(0, 0);
            pb_home_page.Name = "pb_home_page";
            pb_home_page.Size = new Size(510, 700);
            pb_home_page.TabIndex = 0;
            pb_home_page.TabStop = false;
            // 
            // pb_btn_play
            // 
            pb_btn_play.Cursor = Cursors.Hand;
            pb_btn_play.Location = new Point(190, 480);
            pb_btn_play.Name = "pb_btn_play";
            pb_btn_play.Size = new Size(130, 130);
            pb_btn_play.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_play.TabIndex = 2;
            pb_btn_play.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_play);
            Controls.Add(pb_home_page);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pb_home_page).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_play).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_home_page;
        private PictureBox pb_btn_play;
    }
}
