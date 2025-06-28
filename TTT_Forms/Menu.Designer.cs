namespace TTT_Forms
{
    partial class Menu
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
            pb_menu_page = new PictureBox();
            pb_btn_back = new PictureBox();
            pb_btn_guide = new PictureBox();
            pb_btn_pvp = new PictureBox();
            pb_btn_pve = new PictureBox();
            pb_btn_history = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_menu_page).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_guide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_history).BeginInit();
            SuspendLayout();
            // 
            // pb_menu_page
            // 
            pb_menu_page.Location = new Point(0, 0);
            pb_menu_page.Name = "pb_menu_page";
            pb_menu_page.Size = new Size(510, 700);
            pb_menu_page.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_menu_page.TabIndex = 1;
            pb_menu_page.TabStop = false;
            // 
            // pb_btn_back
            // 
            pb_btn_back.Cursor = Cursors.Hand;
            pb_btn_back.Location = new Point(20, 630);
            pb_btn_back.Name = "pb_btn_back";
            pb_btn_back.Size = new Size(50, 50);
            pb_btn_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_back.TabIndex = 2;
            pb_btn_back.TabStop = false;
            // 
            // pb_btn_guide
            // 
            pb_btn_guide.Cursor = Cursors.Hand;
            pb_btn_guide.Location = new Point(440, 20);
            pb_btn_guide.Name = "pb_btn_guide";
            pb_btn_guide.Size = new Size(50, 50);
            pb_btn_guide.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_guide.TabIndex = 3;
            pb_btn_guide.TabStop = false;
            // 
            // pb_btn_pvp
            // 
            pb_btn_pvp.Cursor = Cursors.Hand;
            pb_btn_pvp.Location = new Point(155, 200);
            pb_btn_pvp.Name = "pb_btn_pvp";
            pb_btn_pvp.Size = new Size(200, 70);
            pb_btn_pvp.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pvp.TabIndex = 4;
            pb_btn_pvp.TabStop = false;
            // 
            // pb_btn_pve
            // 
            pb_btn_pve.Cursor = Cursors.Hand;
            pb_btn_pve.Location = new Point(155, 315);
            pb_btn_pve.Name = "pb_btn_pve";
            pb_btn_pve.Size = new Size(200, 70);
            pb_btn_pve.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_pve.TabIndex = 5;
            pb_btn_pve.TabStop = false;
            // 
            // pb_btn_history
            // 
            pb_btn_history.Cursor = Cursors.Hand;
            pb_btn_history.Location = new Point(155, 430);
            pb_btn_history.Name = "pb_btn_history";
            pb_btn_history.Size = new Size(200, 70);
            pb_btn_history.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_history.TabIndex = 6;
            pb_btn_history.TabStop = false;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(pb_btn_history);
            Controls.Add(pb_btn_pve);
            Controls.Add(pb_btn_pvp);
            Controls.Add(pb_btn_guide);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_menu_page);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pb_menu_page).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_guide).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pvp).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_pve).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_history).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_menu_page;
        private PictureBox pb_btn_back;
        private PictureBox pb_btn_guide;
        private PictureBox pb_btn_pvp;
        private PictureBox pb_btn_pve;
        private PictureBox pb_btn_history;
    }
}