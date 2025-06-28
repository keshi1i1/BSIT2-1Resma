namespace TTT_Forms
{
    partial class PVP
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
            pb_pvp_page = new PictureBox();
            pb_btn_back = new PictureBox();
            pb_btn_start = new PictureBox();
            tb_player1 = new TextBox();
            tb_player2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pb_pvp_page).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_start).BeginInit();
            SuspendLayout();
            // 
            // pb_pvp_page
            // 
            pb_pvp_page.Location = new Point(0, 0);
            pb_pvp_page.Name = "pb_pvp_page";
            pb_pvp_page.Size = new Size(510, 700);
            pb_pvp_page.TabIndex = 1;
            pb_pvp_page.TabStop = false;
            // 
            // pb_btn_back
            // 
            pb_btn_back.Cursor = Cursors.Hand;
            pb_btn_back.Location = new Point(20, 630);
            pb_btn_back.Name = "pb_btn_back";
            pb_btn_back.Size = new Size(50, 50);
            pb_btn_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_back.TabIndex = 3;
            pb_btn_back.TabStop = false;
            // 
            // pb_btn_start
            // 
            pb_btn_start.Cursor = Cursors.Hand;
            pb_btn_start.Location = new Point(155, 490);
            pb_btn_start.Name = "pb_btn_start";
            pb_btn_start.Size = new Size(200, 70);
            pb_btn_start.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_btn_start.TabIndex = 5;
            pb_btn_start.TabStop = false;
            // 
            // tb_player1
            // 
            tb_player1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_player1.BorderStyle = BorderStyle.None;
            tb_player1.Cursor = Cursors.IBeam;
            tb_player1.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_player1.Location = new Point(60, 386);
            tb_player1.Name = "tb_player1";
            tb_player1.Size = new Size(135, 33);
            tb_player1.TabIndex = 6;
            tb_player1.TabStop = false;
            tb_player1.Text = "Player 1";
            tb_player1.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_player2
            // 
            tb_player2.BorderStyle = BorderStyle.None;
            tb_player2.Cursor = Cursors.IBeam;
            tb_player2.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_player2.Location = new Point(310, 386);
            tb_player2.Name = "tb_player2";
            tb_player2.Size = new Size(135, 33);
            tb_player2.TabIndex = 7;
            tb_player2.TabStop = false;
            tb_player2.Text = "Player 2";
            tb_player2.TextAlign = HorizontalAlignment.Center;
            // 
            // PVP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(tb_player2);
            Controls.Add(tb_player1);
            Controls.Add(pb_btn_start);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_pvp_page);
            Name = "PVP";
            StartPosition = FormStartPosition.Manual;
            Text = "PVP";
            ((System.ComponentModel.ISupportInitialize)pb_pvp_page).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_btn_start).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_pvp_page;
        private PictureBox pb_btn_back;
        private PictureBox pb_btn_start;
        private TextBox tb_player1;
        private TextBox tb_player2;
    }
}