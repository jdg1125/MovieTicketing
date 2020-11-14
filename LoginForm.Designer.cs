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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "LoginForm";
        }
        private void LoginForm_Load() 
    { 
        Button Submit = new Button();
        Submit.Location = new Point(330, 350);
        Submit.Text = "Submit";
        Submit.AutoSize = true;
        Submit.BackColor = Color.White;
        Submit.Padding = new Padding(6);
        Submit.Font = new Font("Sans Serif", 20);
        this.Controls.Add(Submit);
      
        Label Main = new Label();
        Main.AutoSize = true;
        Main.Text = "Movie Theater Login";
        Main.Location = new Point(275, 20);
        Main.Font = new Font("Sans Serif", 20);
        this.Controls.Add(Main);
        Label Username = new Label();
        Username.AutoSize= true;
        Username.Text = "Username";
        Username.Location = new Point(298, 100);
        Username.Font = new Font("Sans Serif", 15);
        this.Controls.Add(Username);
        Label Password = new Label();
        Password.AutoSize=true;
        Password.Text = "Password";
        Password.Location = new Point (298,200);
        Password.Font = new Font("Sans Serif", 15);
        this.Controls.Add(Password);
        TextBox UsernameBox = new TextBox();
        UsernameBox.Location = new Point(300,150);
        UsernameBox.ForeColor = Color.Black;
        UsernameBox.BackColor = Color.White;
        UsernameBox.BorderStyle = BorderStyle.FixedSingle;
        UsernameBox.MaxLength = 5; 
        this.Controls.Add(UsernameBox);
        TextBox PasswordBox = new TextBox();
        PasswordBox.Location = new Point(300,250);
        PasswordBox.BackColor = Color.White;
        PasswordBox.ForeColor = Color.Black;
        PasswordBox.BorderStyle = BorderStyle.FixedSingle;
        PasswordBox.MaxLength = 30;
        PasswordBox.PasswordChar = '*';
        this.Controls.Add(PasswordBox);
        




        }


        
        public override void Display(string msg)
        {
            
        }
    }
}