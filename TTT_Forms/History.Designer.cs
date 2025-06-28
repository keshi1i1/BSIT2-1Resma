namespace TTT_Forms
{
    partial class History
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
            pb_btn_pve_scores = new PictureBox();
            pb_btn_pvp_scores = new PictureBox();
            pb_btn_back = new PictureBox();
            pb_history_page = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve_scores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp_scores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_history_page).BeginInit();
            SuspendLayout();
            // 
            // pb_btn_pve_scores
            // 
            pb_btn_pve_scores.Cursor = Cursors.Hand;
            pb_btn_pve_scores.Location = new Point(155, 403);
            pb_btn_pve_scores.Name = "pb_btn_pve_scores";
            pb_btn_pve_scores.Size = new Size(200, 70);
            pb_btn_pve_scores.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pve_scores.TabIndex = 11;
            pb_btn_pve_scores.TabStop = false;
            // 
            // pb_btn_pvp_scores
            // 
            pb_btn_pvp_scores.Cursor = Cursors.Hand;
            pb_btn_pvp_scores.Location = new Point(155, 288);
            pb_btn_pvp_scores.Name = "pb_btn_pvp_scores";
            pb_btn_pvp_scores.Size = new Size(200, 70);
            pb_btn_pvp_scores.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pvp_scores.TabIndex = 10;
            pb_btn_pvp_scores.TabStop = false;
            // 
            // pb_btn_back
            // 
            pb_btn_back.Cursor = Cursors.Hand;
            pb_btn_back.Location = new Point(20, 630);
            pb_btn_back.Name = "pb_btn_back";
            pb_btn_back.Size = new Size(50, 50);
            pb_btn_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_back.TabIndex = 9;
            pb_btn_back.TabStop = false;
            // 
            // pb_history_page
            // 
            pb_history_page.Location = new Point(0, 0);
            pb_history_page.Name = "pb_history_page";
            pb_history_page.Size = new Size(510, 700);
            pb_history_page.TabIndex = 8;
            pb_history_page.TabStop = false;
            // 
            // History
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_pve_scores);
            Controls.Add(pb_btn_pvp_scores);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_history_page);
            Name = "History";
            StartPosition = FormStartPosition.Manual;
            Text = "History";
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve_scores).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp_scores).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_history_page).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_btn_pve_scores;
        private PictureBox pb_btn_pvp_scores;
        private PictureBox pb_btn_back;
        private PictureBox pb_history_page;
    }
}