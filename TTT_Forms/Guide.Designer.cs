namespace TTT_Forms
{
    partial class Guide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Guide));
            pb_btn_back = new PictureBox();
            pb_guide_page = new PictureBox();
            tb_guide = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_guide_page).BeginInit();
            SuspendLayout();
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
            // pb_guide_page
            // 
            pb_guide_page.Location = new Point(0, 0);
            pb_guide_page.Name = "pb_guide_page";
            pb_guide_page.Size = new Size(510, 700);
            pb_guide_page.TabIndex = 12;
            pb_guide_page.TabStop = false;
            // 
            // tb_guide
            // 
            tb_guide.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_guide.BorderStyle = BorderStyle.None;
            tb_guide.Cursor = Cursors.IBeam;
            tb_guide.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tb_guide.Location = new Point(88, 166);
            tb_guide.Margin = new Padding(10);
            tb_guide.Multiline = true;
            tb_guide.Name = "tb_guide";
            tb_guide.ReadOnly = true;
            tb_guide.ScrollBars = ScrollBars.Vertical;
            tb_guide.Size = new Size(334, 412);
            tb_guide.TabIndex = 14;
            tb_guide.TabStop = false;
            tb_guide.Text = resources.GetString("tb_guide.Text");
            tb_guide.TextAlign = HorizontalAlignment.Center;
            // 
            // Guide
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 700);
            Controls.Add(tb_guide);
            Controls.Add(pb_btn_back);
            Controls.Add(pb_guide_page);
            Name = "Guide";
            StartPosition = FormStartPosition.Manual;
            Text = "Guide";
            ((System.ComponentModel.ISupportInitialize)pb_btn_back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_guide_page).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pb_btn_back;
        private PictureBox pb_guide_page;
        private TextBox tb_guide;
    }
}