namespace TTT_Forms
{
    partial class PvE_Scores
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
            pb_btn_pve_clear = new PictureBox();
            pb_btn_pve_remove = new PictureBox();
            pb_btn_back = new PictureBox();
            pb_pvescores_page = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve_clear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve_remove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_pvescores_page).BeginInit();
            SuspendLayout();
            // 
            // pb_btn_pve_clear
            // 
            pb_btn_pve_clear.Cursor = Cursors.Hand;
            pb_btn_pve_clear.Location = new Point(155, 543);
            pb_btn_pve_clear.Name = "pb_btn_pve_clear";
            pb_btn_pve_clear.Size = new Size(200, 70);
            pb_btn_pve_clear.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pve_clear.TabIndex = 19;
            pb_btn_pve_clear.TabStop = false;
            // 
            // pb_btn_pve_remove
            // 
            pb_btn_pve_remove.Cursor = Cursors.Hand;
            pb_btn_pve_remove.Location = new Point(155, 448);
            pb_btn_pve_remove.Name = "pb_btn_pve_remove";
            pb_btn_pve_remove.Size = new Size(200, 70);
            pb_btn_pve_remove.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pve_remove.TabIndex = 18;
            pb_btn_pve_remove.TabStop = false;
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
            // pb_pvescores_page
            // 
            pb_pvescores_page.Location = new Point(0, 0);
            pb_pvescores_page.Name = "pb_pvescores_page";
            pb_pvescores_page.Size = new Size(510, 700);
            pb_pvescores_page.TabIndex = 16;
            pb_pvescores_page.TabStop = false;
            // 
            // PvE_Scores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_pve_clear);
            Controls.Add(pb_btn_pve_remove);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_pvescores_page);
            Name = "PvE_Scores";
            StartPosition = FormStartPosition.Manual;
            Text = "PvE_Scores";
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve_clear).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve_remove).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_pvescores_page).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_btn_pve_clear;
        private PictureBox pb_btn_pve_remove;
        private PictureBox pb_btn_back;
        private PictureBox pb_pvescores_page;
    }
}