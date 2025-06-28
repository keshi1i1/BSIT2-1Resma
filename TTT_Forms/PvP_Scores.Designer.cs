namespace TTT_Forms
{
    partial class PvP_Scores
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
            pb_btn_pvp_clear = new PictureBox();
            pb_btn_pvp_remove = new PictureBox();
            pb_btn_back = new PictureBox();
            pb_pvpscores_page = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp_clear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp_remove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_pvpscores_page).BeginInit();
            SuspendLayout();
            // 
            // pb_btn_pvp_clear
            // 
            pb_btn_pvp_clear.Cursor = Cursors.Hand;
            pb_btn_pvp_clear.Location = new Point(155, 543);
            pb_btn_pvp_clear.Name = "pb_btn_pvp_clear";
            pb_btn_pvp_clear.Size = new Size(200, 70);
            pb_btn_pvp_clear.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pvp_clear.TabIndex = 19;
            pb_btn_pvp_clear.TabStop = false;
            // 
            // pb_btn_pvp_remove
            // 
            pb_btn_pvp_remove.Cursor = Cursors.Hand;
            pb_btn_pvp_remove.Location = new Point(155, 448);
            pb_btn_pvp_remove.Name = "pb_btn_pvp_remove";
            pb_btn_pvp_remove.Size = new Size(200, 70);
            pb_btn_pvp_remove.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pvp_remove.TabIndex = 18;
            pb_btn_pvp_remove.TabStop = false;
            // 
            // pb_btn_back
            // 
            pb_btn_back.Cursor = Cursors.Hand;
            pb_btn_back.Location = new Point(20, 630);
            pb_btn_back.Name = "pb_btn_back";
            pb_btn_back.Size = new Size(50, 50);
            pb_btn_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_back.TabIndex = 17;
            pb_btn_back.TabStop = false;
            // 
            // pb_pvpscores_page
            // 
            pb_pvpscores_page.Location = new Point(0, 0);
            pb_pvpscores_page.Name = "pb_pvpscores_page";
            pb_pvpscores_page.Size = new Size(510, 700);
            pb_pvpscores_page.TabIndex = 16;
            pb_pvpscores_page.TabStop = false;
            // 
            // PvP_Scores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_pvp_clear);
            Controls.Add(pb_btn_pvp_remove);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_pvpscores_page);
            Name = "PvP_Scores";
            StartPosition = FormStartPosition.Manual;
            Text = "PvP_Scores";
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp_clear).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp_remove).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_pvpscores_page).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_btn_pvp_clear;
        private PictureBox pb_btn_pvp_remove;
        private PictureBox pb_btn_back;
        private PictureBox pb_pvpscores_page;
    }
}