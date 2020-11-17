using Control;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace Boundary
{
    partial class Homepage: IForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Homepage";
        }
        
         public void Homepage_Load()
        {
            Label Welcom = new Label();
            Welcom.Text = "Welcome";
            Welcom.AutoSize = true;
            Welcom.Font = new Font("Sans Serif", 30);
            Welcom.Location = new Point(700, 25);
            this.Controls.Add(Welcom);
            Button ReserveTickets = new Button();
            ReserveTickets.Text = "Reserve Tickets";
            ReserveTickets.Location = new Point(50, 200);
            ReserveTickets.AutoSize = true;
            ReserveTickets.BackColor = Color.White;
            ReserveTickets.Padding = new Padding(6);
            ReserveTickets.Font = new Font("Sans Serif", 30);
            Button Logout = new Button();
            Logout.Text = "Log out";
            Logout.Location = new Point(1000, 25);
            Logout.AutoSize = true;
            Logout.BackColor = Color.White;
            Logout.Padding = new Padding(6);
            Logout.Font = new Font("Sans Serif", 15);
            this.Controls.Add(Logout);
            CustomizeHomepage(ReserveTickets);

            
        }
        public void CustomizeHomepage(Button ReserveTicket ) {
            if (_token == "E")
            {
                ReserveTicket.Location = new Point(650, 200);
            } 
            this.Controls.Add(ReserveTicket);
            if (_token == "A")
            {
                Button Movie = new Button();
                Movie.Text = "Set Movies";
                Movie.Location = new Point(850, 200);
                Movie.AutoSize = true;
                Movie.BackColor = Color.White;
                Movie.Padding = new Padding(6);
                Movie.Font = new Font("Sans Serif", 30);
                this.Controls.Add(Movie);

            }


        }

        public override void Display(string s)
        {

        }
    }
}