using Control;
using Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Boundary
{
    partial class SetMovieForm : IForm
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
            this.Text = "SetMovieForm";
        }
        private void Setmovieform_Load()
        {
            Label Setmovies = new Label();
            Setmovies.Text = "Set Movies";
            Setmovies.Font = new Font("Sans Serif", 30);
            Setmovies.AutoSize = true;
            Setmovies.Location = new Point(600, 25);
            this.Controls.Add(Setmovies);
            Button Logout = new Button();
            Logout.Text = "Log out";
            Logout.AutoSize = true;
            Logout.Location = new Point(1100, 25);
            Logout.BackColor = Color.White;
            Logout.Padding = new Padding(6);
            Logout.Font = new Font("Sans Serif", 15);
            this.Controls.Add(Logout);
            TextBox Title = new TextBox();
            Title.Location = new Point(175, 100);
            Title.BackColor = Color.White;
            Title.Width = 1000;
            Title.BorderStyle = BorderStyle.FixedSingle;
            Title.Font = new Font("Sans Serif", 30);
            this.Controls.Add(Title);
            TextBox Titlelabel = new TextBox();
            Titlelabel.Text = "Title";
            Titlelabel.Location = new Point(75, 100);
            Titlelabel.BackColor = Color.Gray;
            Titlelabel.BorderStyle = BorderStyle.FixedSingle;
            Titlelabel.ReadOnly = true;
            Titlelabel.Font = new Font("Sans Serif", 30);
            this.Controls.Add(Titlelabel);
            ComboBox Theater = new ComboBox();
            Theater.Text = "Enter Theater";
            Theater.Width = 200;
            Theater.Height = 200;
            Theater.Items.Add("Theater1");
            Theater.Items.Add("Theater2");
            Theater.Items.Add("Theater3");
            Theater.Location = new Point(400, 100);
            this.Controls.Add(Theater);
            PictureBox movieposter = new PictureBox();
            movieposter.Location = new Point(100, 200);
            movieposter.Size = new Size(400, 500);
            movieposter.ImageLocation = @"C:\Users\mags0\Downloads\marvel.jpg";
            this.Controls.Add(movieposter);
            DateTimePicker Start = new DateTimePicker();
            Start.Format = DateTimePickerFormat.Custom;
            Start.CustomFormat = "HH:mm tt";
            Start.ShowUpDown = true;
            Start.Location = new Point(800, 250);
            Start.Width = 100;
            this.Controls.Add(Start);
            DateTimePicker End = new DateTimePicker();
            End.Format = DateTimePickerFormat.Custom;
            End.CustomFormat = "HH:mm tt";
            End.ShowUpDown = true;
            End.Location = new Point(915, 250);
            End.Width = 100;
            this.Controls.Add(End);
            DateTimePicker Date = new DateTimePicker();
            Date.Value = DateTime.Today;
            Date.Location = new Point(625, 350);
            Date.Font = new Font("Sans Serif", 10);
            Date.Width = 250;
            this.Controls.Add(Date);
            Button showtime = new Button();
            showtime.Text = "Add New Showtime";
            showtime.AutoSize = true;
            showtime.Location = new Point(600, 400);
            showtime.BackColor = Color.White;
            showtime.Padding = new Padding(6);
            showtime.Font = new Font("Sans Serif", 25);
            this.Controls.Add(showtime);
            Button Submit = new Button();
            Submit.Text = "Submit";
            Submit.AutoSize = true;
            Submit.Location = new Point(700, 400);
            Submit.BackColor = Color.White;
            Submit.Padding = new Padding(6);
            Submit.Font = new Font("Sans Serif", 20);
            this.Controls.Add(Submit);
            TextBox pickd = new TextBox();
            pickd.Text = "Day";
            pickd.Location = new Point(525, 350);
            pickd.Font = new Font("Sans Serif", 10);
            pickd.BackColor = Color.White;
            pickd.ForeColor = Color.Black;
            pickd.BorderStyle = BorderStyle.FixedSingle;
            pickd.Width = 100;
            this.Controls.Add(pickd);
            TextBox picks = new TextBox();
            picks.Text = "Start time";
            picks.Location = new Point(800, 200);
            picks.Font = new Font("Sans Serif", 10);
            picks.BackColor = Color.White;
            picks.ForeColor = Color.Black;
            picks.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(picks);
            TextBox picke = new TextBox();
            picke.Text = "End time";
            picke.Location = new Point(900, 200);
            picke.Font = new Font("Sans Serif", 10);
            picke.BackColor = Color.White;
            picke.ForeColor = Color.Black;
            picke.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(picke);
            Label Showtimes = new Label();
            Showtimes.Text = "Showtimes";
            Showtimes.Location = new Point(800, 800);
            Showtimes.Font = new Font("Sans Serif", 25);
            Showtimes.AutoSize = true;
            this.Controls.Add(Showtimes);




            









        }
        public override void Display(string msg)
        {

        }

        public void DisplayPoster(string path)
        {
            //Use API of PictureBox element to render picture
        }
    }
}