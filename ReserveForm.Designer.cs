using System.Collections.Generic;
using Control;
using Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Boundary
{
    partial class ReserveForm : IForm
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
        private void ReserveForm_Load()
        {
            Label Reservee = new Label();
            Reservee.Text = "Reserve Tickets";
            Reservee.Location = new Point(700, 25);
            Reservee.Font = new Font("Sans Serif", 25);
            Reservee.AutoSize = true;
            this.Controls.Add(Reservee);
            Button Logout = new Button();
            Logout.Text = "Log out";
            Logout.AutoSize = true;
            Logout.Location = new Point(1000, 25);
            Logout.BackColor = Color.White;
            Logout.Padding = new Padding(6);
            Logout.Font = new Font("Sans Serif", 15);
            this.Controls.Add(Logout);
            Button Reserve = new Button();
            Reserve.Text = "Reserve";
            Reserve.AutoSize = true;
            Reserve.Location = new Point(975, 550);
            Reserve.BackColor = Color.White;
            Reserve.Padding = new Padding(6);
            Reserve.Font = new Font("Sans Serif", 25);
            this.Controls.Add(Reserve);
            TextBox EnterSeats = new TextBox();
            EnterSeats.Location = new Point(725, 550);
            EnterSeats.BackColor = Color.White;
            EnterSeats.ForeColor = Color.Black;
            EnterSeats.BorderStyle = BorderStyle.FixedSingle;
            EnterSeats.MaxLength = 2;
            EnterSeats.Font = new Font("Sans Serif", 15);
            this.Controls.Add(EnterSeats);
            TextBox NumberofSeats = new TextBox();
            NumberofSeats.Font = new Font("Sans Serif", 15);
            NumberofSeats.Width = 200;
            NumberofSeats.Location = new Point(525, 550);
            NumberofSeats.BackColor = Color.Gray;
            NumberofSeats.ForeColor = Color.Black;
            NumberofSeats.BorderStyle = BorderStyle.FixedSingle;
            NumberofSeats.Text = "Number of Seats";
            NumberofSeats.ReadOnly = true;
            this.Controls.Add(NumberofSeats);
            Label movie = new Label();
            movie.Text = "Movies/Times/Seats Selection";
            movie.AutoSize = true;
            movie.Font = new Font("Sans Serif", 20);
            movie.Location = new Point(800, 300);
            this.Controls.Add(movie);
            ComboBox movieselect = new ComboBox();
            movieselect.Text = "Movie/Time/Avaiable Seats Selection";
            movieselect.Width = 500;
            movieselect.Font = new Font("Sans Serif", 15);
            movieselect.Items.Add("Movie1 12:30 12 Seats available");
            movieselect.Items.Add("Movie2 12:15 20 Seats available");
            movieselect.Items.Add("Movie3 5:00 5 Seats available");
            movieselect.Location = new Point(800, 350);
            this.Controls.Add(movieselect);
            TextBox Dateselect = new TextBox();
            Dateselect.Text = "Date Selection";
            Dateselect.Font = new Font("Sans Serif", 10);
            Dateselect.BackColor = Color.Gray;
            Dateselect.ForeColor = Color.Black;
            Dateselect.Location = new Point(550, 100);
            this.Controls.Add(Dateselect);
            DateTimePicker Date = new DateTimePicker();
            Date.Font = new Font("Sans Serif", 10);
            Date.Value = DateTime.Today;
            Date.Location = new Point(650, 100);
            Date.Width = 350;
            this.Controls.Add(Date);
            PictureBox movieposter = new PictureBox();
            movieposter.Location = new Point(100, 200);
            movieposter.Size = new Size (400, 500);
            movieposter.ImageLocation = @"C:\Users\mags0\Downloads\marvel.jpg";
            this.Controls.Add(movieposter);
            Label Checkout = new Label();
            Checkout.Text = "Checkout";
            Checkout.AutoSize = true;
            Checkout.Font = new Font("Sans Serif", 20);
            Checkout.Location = new Point(825, 450);
            this.Controls.Add(Checkout);







        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "ReserveForm";
        }

        public override void Display(string s)
        {
            
        }

        public void Display(List<MovieEntry> entries)
        {

        }

        public void DisplayPoster(string path)
        {

        }
    }
}