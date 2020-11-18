using System;
using System.Windows.Forms;
using System.Drawing;

namespace Boundary
{
    public partial class LoginForm : IForm
    {

        private System.ComponentModel.IContainer components = null;

        //buttons and text boxes go here

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Text = "LoginForm";
        }
        private void LoginForm_Load()
        {
            submitBtn = new Button();
            submitBtn.Location = new Point(ClientSize.Width/2 -submitBtn.Width + 10, ClientSize.Height-100);
            submitBtn.Text = "Submit";
            submitBtn.AutoSize = true;
            submitBtn.BackColor = Color.White;
            submitBtn.Padding = new Padding(6);
            submitBtn.Font = new Font("Sans Serif", 20);
            this.Controls.Add(submitBtn);

            Label header = new Label();
            header.AutoSize = true;
            header.Text = "Movie Theater Login";
            header.Location = new Point(ClientSize.Width/2 - 2*header.Width +10, 20);
            header.Font = new Font("Sans Serif", 30);
            this.Controls.Add(header);

            Label nameLabel = new Label();
            nameLabel.AutoSize = true;
            nameLabel.Text = "Username";
            nameLabel.Location = new Point(ClientSize.Width/2 - nameLabel.Width+15, 120);
            nameLabel.Font = new Font("Sans Serif", 20);
            this.Controls.Add(nameLabel);

            Label pwLabel = new Label();
            pwLabel.AutoSize = true;
            pwLabel.Text = "Password";
            pwLabel.Location = new Point(ClientSize.Width/2 - pwLabel.Width+15, 250);
            pwLabel.Font = new Font("Sans Serif", 20);
            this.Controls.Add(pwLabel);

            usernameBox = new TextBox();
            usernameBox.Location = new Point(ClientSize.Width/2 - usernameBox.Width/2 - 80, 175);
            usernameBox.ForeColor = Color.Black;
            usernameBox.BackColor = Color.White;
            usernameBox.BorderStyle = BorderStyle.FixedSingle;
            usernameBox.MaxLength = 5;
            usernameBox.Width = 250;
            usernameBox.Font = new Font("Sans Serif", 30);
            this.Controls.Add(usernameBox);

            passwordBox = new TextBox();
            passwordBox.Font = new Font("Sans Serif", 30);
            passwordBox.Location = new Point(ClientSize.Width / 2 - passwordBox.Width / 2 - 80, 305);
            passwordBox.BackColor = Color.White;
            passwordBox.ForeColor = Color.Black;
            passwordBox.BorderStyle = BorderStyle.FixedSingle;
            passwordBox.MaxLength = 30;
            passwordBox.Width = 250;
            passwordBox.PasswordChar = '*';
            this.Controls.Add(passwordBox);

            message = new Label();
            message.Location = new Point(ClientSize.Width/2 - 110, ClientSize.Height - 180);
            message.Font = new Font("Sans Serif", 16);
            message.ForeColor = Color.Red;
            message.AutoSize = true;
            this.Controls.Add(message);

            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            submitBtn.Click += new EventHandler(Submit);
        }
        public override void Close()
        {
            (this as Form).Hide(); //can't close because it's the main form
        }

        public override void Display(string msg)
        {
            message.Text = msg;
            message.Refresh();
        }

        private void Submit(object sender, EventArgs e)
        {
            (_ctrl as LoginCtrl).Submit(usernameBox.Text, passwordBox.Text);
        }
    }
}