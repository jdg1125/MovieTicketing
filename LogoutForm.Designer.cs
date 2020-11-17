using Control;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Boundary
{
    partial class LogoutForm : IForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public override void Display(string s)
        {
            
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "LogoutForm";
        }
        private void LogoutForm_Load()
        {
            Button Yes = new Button();
            Yes.Text = "Yes";
            Yes.Width = 600;
            Yes.Height = 100;
            Yes.Location = new Point(480, 300);
            Yes.AutoSize = true;
            Yes.BackColor = Color.White;
            Yes.Padding = new Padding(6);
            Yes.Font = new Font("Sans Serif", 30);
            this.Controls.Add(Yes);
            Label Logout = new Label();
            Logout.Text = "Log out?";
            Logout.AutoSize = true;
            Logout.Location = new Point(700, 25);
            Logout.Font = new Font("Sans Serif", 30);
            this.Controls.Add(Logout);







        }



    }
}