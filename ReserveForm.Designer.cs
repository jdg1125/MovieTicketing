using System.Collections.Generic;
using Control;
using Entity;
using System;
using System.Threading;
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
        private void InitializeComponent()
        {
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Text = "Reserve Form";
            this.AutoScroll = true;
        }
        private void ReserveForm_Load()
        {
            Label header = new Label();
            header.Text = "Reserve Tickets";
            header.Font = new Font("Sans Serif", 30);
            header.AutoSize = true;
            header.Location = new Point(ClientSize.Width / 2 - 3 * header.Width / 2, 25);
            this.Controls.Add(header);

            logout = new Button();
            logout.Text = "Logout";
            logout.Location = new Point(ClientSize.Width - 200, 25);
            logout.AutoSize = true;
            logout.BackColor = Color.White;
            logout.Padding = new Padding(6);
            logout.Font = new Font("Sans Serif", 15);
            this.Controls.Add(logout);

            Label dateLabel = new Label();
            dateLabel.Text = "Date Selection";
            dateLabel.Font = new Font("Sans Serif", 16);
            dateLabel.Location = new Point(170, 150);
            this.Controls.Add(dateLabel);

            date = new DateTimePicker();
            date.Font = new Font("Sans Serif", 16);
            date.MinDate = DateTime.Today;
            date.Location = new Point(270, 150);
            date.Width = ClientSize.Width / 2 - 100;
            this.Controls.Add(date);

            search = new Button();
            search.Text = "Search";
            search.Location = new Point(ClientSize.Width / 2 + 200, 140);
            search.AutoSize = true;
            search.BackColor = Color.White;
            search.Padding = new Padding(6);
            search.Font = new Font("Sans Serif", 15);
            this.Controls.Add(search);

            posterArea = new PictureBox();
            posterArea.Location = new Point(150, 250);
            posterArea.Size = new Size(250, 320);
            this.Controls.Add(posterArea);

            Label movieLabel = new Label();
            movieLabel.Text = "Movies/Times/Seats Selection";
            movieLabel.AutoSize = true;
            movieLabel.Font = new Font("Sans Serif", 20);
            movieLabel.Location = new Point(ClientSize.Width / 2, ClientSize.Height / 3);
            this.Controls.Add(movieLabel);

            movieSelector = new ComboBox();
            movieSelector.Text = "Movie/Time/Avaiable Seats";
            movieSelector.Width = 400;
            movieSelector.Font = new Font("Sans Serif", 15);
            movieSelector.Location = new Point(ClientSize.Width / 2, 5 * ClientSize.Height / 12);
            this.Controls.Add(movieSelector);

            message = new Label();
            message.Location = new Point(20, ClientSize.Height - 260);
            message.Font = new Font("Sans Serif", 16);
            message.ForeColor = Color.Red;
            message.AutoSize = true;
            this.Controls.Add(message);

            Label reserveLabel = new Label();
            reserveLabel.Text = "Checkout";
            reserveLabel.AutoSize = true;
            reserveLabel.Font = new Font("Sans Serif", 20);
            reserveLabel.Location = new Point(ClientSize.Width / 2 - reserveLabel.Width / 2, ClientSize.Height - 200);
            this.Controls.Add(reserveLabel);

            reserve = new Button();
            reserve.Text = "Reserve";
            reserve.AutoSize = true;
            reserve.Location = new Point(3 * ClientSize.Width / 4 - reserve.Width, ClientSize.Height - 100);
            reserve.BackColor = Color.White;
            reserve.Padding = new Padding(6);
            reserve.Font = new Font("Sans Serif", 20);
            this.Controls.Add(reserve);

            Label seatsLabel = new Label();
            seatsLabel.Font = new Font("Sans Serif", 16);
            seatsLabel.Width = 200;
            seatsLabel.Location = new Point(ClientSize.Width / 8, ClientSize.Height - 85);
            seatsLabel.Text = "Number of Seats";
            this.Controls.Add(seatsLabel);

            enterSeats = new TextBox();
            enterSeats.Location = new Point(ClientSize.Width / 8 + seatsLabel.Width, ClientSize.Height - 90);
            enterSeats.Text = "";
            enterSeats.BackColor = Color.White;
            enterSeats.ForeColor = Color.Black;
            enterSeats.BorderStyle = BorderStyle.FixedSingle;
            enterSeats.MaxLength = 2;
            enterSeats.Font = new Font("Sans Serif", 20);
            this.Controls.Add(enterSeats);

            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            logout.Click += new EventHandler(Logout);
            search.Click += new EventHandler(SelectDate);
            movieSelector.DropDownClosed += new EventHandler(SelectMovie);
            reserve.Click += new EventHandler(Submit);
            enterSeats.KeyPress += new KeyPressEventHandler(AllowOnlyNumbers);
        }
        private void Logout(object sender, EventArgs e)
        {
            LogoutCtrl logoutCtrl = new LogoutCtrl(_token);
            logoutCtrl.Initiate(this);
        }

        private void SelectDate(object sender, EventArgs e)
        {
            (_ctrl as ReserveCtrl).Select(date.Value);
        }

        public void Display(List<MovieEntry> entries)
        {
            _movies = entries;

            movieSelector.Items.Clear();

            foreach (var entry in entries)
                movieSelector.Items.Add(entry.ToString());

            movieSelector.Refresh();            
        }

        private void SelectMovie(object sender, EventArgs e) => DisplayPoster();

        private void DisplayPoster()
        {
            if (movieSelector.SelectedIndex < 0)
                return;
            posterArea.ImageLocation = _movies[movieSelector.SelectedIndex].PosterPath;
            posterArea.Refresh();
        }

        private void AllowOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
        private void Submit(object sender, EventArgs e)
        {
            int.TryParse(enterSeats.Text, out int numSeats);
            (_ctrl as ReserveCtrl).Submit(_movies[movieSelector.SelectedIndex], numSeats);
        }
        public override void Close()
        {
            this.Dispose();
            (this as Form).Close();
        }

        public override void Display(string s)
        {
            message.Text = s;
            message.Refresh();
            Thread.Sleep(3000);
        }
    }
}