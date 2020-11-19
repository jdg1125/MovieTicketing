using Control;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

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
        private void InitializeComponent()
        {
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Text = "LogoutForm";
        }
        private void LogoutForm_Load()
        {

            Label header = new Label();
            header.Text = "Logout?";
            header.AutoSize = true;
            header.Location = new Point(ClientSize.Width / 2 - header.Width + 20, 50);
            header.Font = new Font("Sans Serif", 30);
            this.Controls.Add(header);

            message = new Label();
            message.Location = new Point(90, ClientSize.Height/2 + 115);
            message.Font = new Font("Sans Serif", 16);
            message.ForeColor = Color.Red;
            message.AutoSize = true;
            this.Controls.Add(message);

            yes = new Button();
            yes.Text = "Yes";
            yes.Height = 80;
            yes.Width = 100;
            yes.Location = new Point(ClientSize.Width / 2 - yes.Width + 50, ClientSize.Height/2);
            yes.AutoSize = true;
            yes.BackColor = Color.White;
            yes.Padding = new Padding(6);
            yes.Font = new Font("Sans Serif", 20);
            this.Controls.Add(yes);

            yes.Click += new EventHandler(Submit);

        }
       
        private void Submit(object sender, EventArgs e)
        {
            (_ctrl as LogoutCtrl).Submit();
        }
        public override void Display(string msg)
        {
            message.Text = msg;
            message.Refresh();
            Thread.Sleep(3000);
        }
        public override void Close()
        {
            this.Dispose();
            (this as Form).Close();
        }
    }
}