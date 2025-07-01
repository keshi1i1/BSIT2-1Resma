using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TTT_Forms
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(Form loc, string message, string title, string type)
        {
            Form form = new Form();
            form.Text = title;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.FromArgb(85, 88, 121);

            Label label = new Label()
            {
                Text = message,
                ForeColor = Color.FromArgb(152, 161, 188),
                Font = new Font("Comic Sans MS", 15),
                AutoSize = false,
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnOk = new Button()
            {
                Text = "OK",
                Font = new Font("Comic Sans MS", 12),
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(152, 161, 188),
                ForeColor = Color.FromArgb(85, 88, 121),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 40),
                Location = new Point(110, 65),
            };

            Button btnYes = new Button()
            {
                Text = "YES",
                Font = new Font("Comic Sans MS", 12),
                DialogResult = DialogResult.Yes,
                BackColor = Color.FromArgb(152, 161, 188),
                ForeColor = Color.FromArgb(85, 88, 121),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 40),
                Location = new Point(135, 65)
            };

            Button btnNo = new Button()
            {
                Text = "NO",
                Font = new Font("Comic Sans MS", 12),
                DialogResult = DialogResult.No,
                BackColor = Color.FromArgb(152, 161, 188),
                ForeColor = Color.FromArgb(85, 88, 121),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 40),
                Location = new Point(235, 65)
            };

            if (type == "OK")
            {
                form.Size = new Size(310, 170);
                label.Size = new Size(270, 50);
                form.Controls.Add(label);
                form.Controls.Add(btnOk);
                form.AcceptButton = btnOk;
            }
            else if (type == "LONG")
            {
                form.Size = new Size(460, 170);
                label.Size = new Size(420, 50);
                btnOk.Location = new Point(190, 65);
                form.Controls.Add(label);
                form.Controls.Add(btnOk);
                form.AcceptButton = btnOk;
            }
            else if (type == "YES/NO")
            {
                form.Size = new Size(450, 170);
                label.Size = new Size(410, 50);
                form.Controls.Add(label);
                form.Controls.Add(btnYes);
                form.Controls.Add(btnNo);
                form.AcceptButton = btnYes;
                form.CancelButton = btnNo;
            }
            else if (type == "FOOTLONG")
            {
                form.Size = new Size(470, 240);
                label.Size = new Size(430, 120);
                btnYes.Location = new Point(135, 135);
                btnNo.Location = new Point(235, 135);
                form.Controls.Add(label);
                form.Controls.Add(btnYes);
                form.Controls.Add(btnNo);
                form.AcceptButton = btnYes;
                form.CancelButton = btnNo;
            }
            else if (type == "LOADING")
            {
                form.Size = new Size(450, 115);
                label.Size = new Size(410, 50);
                form.Controls.Add(label);
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    form.Close();
                };
                form.Shown += (s, e) => timer.Start();
            }
            else if (type == "LOADING2")
            {
                form.Size = new Size(470, 115);
                label.Size = new Size(430, 50);
                form.Controls.Add(label);
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    form.Close();
                };
                form.Shown += (s, e) => timer.Start();
            }
            return form.ShowDialog();
        }

        public static string ShowInput(Form loc, string message, string title, string type)
        {
            Form form = new Form();
            form.Text = title;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.FromArgb(85, 88, 121);

            Label label = new Label()
            {
                Text = message,
                ForeColor = Color.FromArgb(152, 161, 188),
                Font = new Font("Comic Sans MS", 15),
                AutoSize = false,
                Location = new Point(11, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            TextBox textBox = new TextBox()
            {
                Font = new Font("Comic Sans MS", 12),
                BackColor = Color.FromArgb(152, 161, 188),
                ForeColor = Color.FromArgb(85, 88, 121),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(310, 40),
                Location = new Point(35, 65),
                TextAlign = HorizontalAlignment.Center
            };

            Button btnOk = new Button()
            {
                Text = "OK",
                Font = new Font("Comic Sans MS", 12),
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(152, 161, 188),
                ForeColor = Color.FromArgb(85, 88, 121),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 40),
                Location = new Point(88, 115),
            };

            Button btnCancel = new Button()
            {
                Text = "CANCEL",
                Font = new Font("Comic Sans MS", 12),
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(152, 161, 188),
                ForeColor = Color.FromArgb(85, 88, 121),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 40),
                Location = new Point(188, 115),
            };

            if (type == "INPUT")
            {
                form.Size = new Size(400, 230);
                label.Size = new Size(360, 50);
                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnCancel);
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;
            }
            return (form.ShowDialog() == DialogResult.OK) ? textBox.Text : "CANCEL";

        }
    }
}
