using System;
using System.Windows.Forms;

namespace Boundary
{
    public partial class LoginForm : IForm
    {

        private System.ComponentModel.IContainer components = null;

        public TextBox tb { get; set; }

        public Button btn { get; set; }

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

        public void BtnEventHandler(object sender, EventArgs e)
        {
            Display("Button was clicked");
        }
        public override void Display(string msg)
        {
            tb.Text = msg;
        }
    }
}