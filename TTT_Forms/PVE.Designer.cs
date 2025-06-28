namespace TTT_Forms
{
    partial class PVE
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
            pb_btn_back = new PictureBox();
            pb_pve_page = new PictureBox();
            pb_btn_continue = new PictureBox();
            pb_btn_new = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_pve_page).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_continue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_new).BeginInit();
            SuspendLayout();
            // 
            // pb_btn_back
            // 
            pb_btn_back.Cursor = Cursors.Hand;
            pb_btn_back.Location = new Point(20, 630);
            pb_btn_back.Name = "pb_btn_back";
            pb_btn_back.Size = new Size(50, 50);
            pb_btn_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_back.TabIndex = 5;
            pb_btn_back.TabStop = false;
            // 
            // pb_pve_page
            // 
            pb_pve_page.Location = new Point(0, 0);
            pb_pve_page.Name = "pb_pve_page";
            pb_pve_page.Size = new Size(510, 700);
            pb_pve_page.TabIndex = 4;
            pb_pve_page.TabStop = false;
            // 
            // pb_btn_continue
            // 
            pb_btn_continue.Cursor = Cursors.Hand;
            pb_btn_continue.Location = new Point(155, 403);
            pb_btn_continue.Name = "pb_btn_continue";
            pb_btn_continue.Size = new Size(200, 70);
            pb_btn_continue.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_continue.TabIndex = 7;
            pb_btn_continue.TabStop = false;
            // 
            // pb_btn_new
            // 
            pb_btn_new.Cursor = Cursors.Hand;
            pb_btn_new.Location = new Point(155, 288);
            pb_btn_new.Name = "pb_btn_new";
            pb_btn_new.Size = new Size(200, 70);
            pb_btn_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_new.TabIndex = 6;
            pb_btn_new.TabStop = false;
            // 
            // PVE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_continue);
            Controls.Add(pb_btn_new);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_pve_page);
            Name = "PVE";
            StartPosition = FormStartPosition.Manual;
            Text = "PVE";
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_pve_page).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_continue).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_new).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_btn_back;
        private PictureBox pb_pve_page;
        private PictureBox pb_btn_continue;
        private PictureBox pb_btn_new;
    }
}