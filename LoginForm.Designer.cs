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
            this.WindowState = FormWindowState.Maximized;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "LoginForm";
        }
        private void LoginForm_Load()
        {
            submitBtn = new Button();
            submitBtn.Location = new Point(700, 350);
            submitBtn.Text = "Submit";
            submitBtn.AutoSize = true;
            submitBtn.BackColor = Color.White;
            submitBtn.Padding = new Padding(6);
            submitBtn.Font = new Font("Sans Serif", 20);
            this.Controls.Add(submitBtn);

            Label Main = new Label();
            Main.AutoSize = true;
            Main.Text = "Movie Theater Login";
            Main.Location = new Point(700, 20);
            Main.Font = new Font("Sans Serif", 30);
            this.Controls.Add(Main);

            Label Username = new Label();
            Username.AutoSize = true;
            Username.Text = "Username";
            Username.Location = new Point(698, 100);
            Username.Font = new Font("Sans Serif", 30);
            this.Controls.Add(Username);

            Label Password = new Label();
            Password.AutoSize = true;
            Password.Text = "Password";
            Password.Location = new Point(698, 200);
            Password.Font = new Font("Sans Serif", 30);
            this.Controls.Add(Password);

            usernameBox = new TextBox();
            usernameBox.Location = new Point(700, 150);
            usernameBox.ForeColor = Color.Black;
            usernameBox.BackColor = Color.White;
            usernameBox.BorderStyle = BorderStyle.FixedSingle;
            usernameBox.MaxLength = 5;
            usernameBox.Width = 250;
            usernameBox.Font = new Font("Sans Serif", 30);
            this.Controls.Add(usernameBox);

            passwordBox = new TextBox();
            passwordBox.Font = new Font("Sans Serif", 30);
            passwordBox.Location = new Point(700, 250);
            passwordBox.BackColor = Color.White;
            passwordBox.ForeColor = Color.Black;
            passwordBox.BorderStyle = BorderStyle.FixedSingle;
            passwordBox.MaxLength = 30;
            passwordBox.Width = 250;
            passwordBox.PasswordChar = '*';
            this.Controls.Add(passwordBox);
            
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
            MessageBox.Show("here");
            //display the text on the form   
        }

        private void Submit(object sender, EventArgs e)
        {
            (_ctrl as LoginCtrl).Submit(usernameBox.Text, passwordBox.Text);
        }
    }
}