namespace TTT_Forms
{
    partial class Continue
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
            pb_btn_username = new PictureBox();
            pb_btn_difficulty = new PictureBox();
            pb_btn_continue = new PictureBox();
            pb_btn_back = new PictureBox();
            pb_continue_page = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_btn_username).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_difficulty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_continue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_continue_page).BeginInit();
            SuspendLayout();
            // 
            // pb_btn_username
            // 
            pb_btn_username.Cursor = Cursors.Hand;
            pb_btn_username.Location = new Point(155, 460);
            pb_btn_username.Name = "pb_btn_username";
            pb_btn_username.Size = new Size(200, 70);
            pb_btn_username.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_username.TabIndex = 16;
            pb_btn_username.TabStop = false;
            // 
            // pb_btn_difficulty
            // 
            pb_btn_difficulty.Cursor = Cursors.Hand;
            pb_btn_difficulty.Location = new Point(155, 345);
            pb_btn_difficulty.Name = "pb_btn_difficulty";
            pb_btn_difficulty.Size = new Size(200, 70);
            pb_btn_difficulty.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_difficulty.TabIndex = 15;
            pb_btn_difficulty.TabStop = false;
            // 
            // pb_btn_continue
            // 
            pb_btn_continue.Cursor = Cursors.Hand;
            pb_btn_continue.Location = new Point(155, 230);
            pb_btn_continue.Name = "pb_btn_continue";
            pb_btn_continue.Size = new Size(200, 70);
            pb_btn_continue.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_continue.TabIndex = 14;
            pb_btn_continue.TabStop = false;
            // 
            // pb_btn_back
            // 
            pb_btn_back.Cursor = Cursors.Hand;
            pb_btn_back.Location = new Point(20, 630);
            pb_btn_back.Name = "pb_btn_back";
            pb_btn_back.Size = new Size(50, 50);
            pb_btn_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_back.TabIndex = 13;
            pb_btn_back.TabStop = false;
            // 
            // pb_continue_page
            // 
            pb_continue_page.Location = new Point(0, 0);
            pb_continue_page.Name = "pb_continue_page";
            pb_continue_page.Size = new Size(510, 700);
            pb_continue_page.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_continue_page.TabIndex = 12;
            pb_continue_page.TabStop = false;
            // 
            // Continue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_username);
            Controls.Add(pb_btn_difficulty);
            Controls.Add(pb_btn_continue);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_continue_page);
            Name = "Continue";
            StartPosition = FormStartPosition.Manual;
            Text = "Continue";
            ((System.ComponentModel.ISupportInitialize)pb_btn_username).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_difficulty).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_continue).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_continue_page).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_btn_username;
        private PictureBox pb_btn_difficulty;
        private PictureBox pb_btn_continue;
        private PictureBox pb_btn_back;
        private PictureBox pb_continue_page;
    }
}