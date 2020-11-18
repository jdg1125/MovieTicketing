using Control;
using Entity;
using System;
using System.Drawing;
using System.Threading;
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
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Text = "Set Movie Form";
        }
        private void Setmovieform_Load()
        {
            Label header = new Label();
            header.Text = "Set Movies";
            header.Font = new Font("Sans Serif", 30);
            header.AutoSize = true;
            header.Location = new Point(ClientSize.Width / 2 - header.Width / 2, 25);
            this.Controls.Add(header);

            logout = new Button();
            logout.Text = "Log out";
            logout.AutoSize = true;
            logout.Location = new Point(ClientSize.Width - 200, 25);
            logout.BackColor = Color.White;
            logout.Padding = new Padding(6);
            logout.Font = new Font("Sans Serif", 15);
            this.Controls.Add(logout);

            titleBox = new TextBox();
            titleBox.Location = new Point(220, 100);
            titleBox.BackColor = Color.White;
            titleBox.Width = ClientSize.Width - 300;
            titleBox.BorderStyle = BorderStyle.FixedSingle;
            titleBox.Font = new Font("Sans Serif", 30);
            this.Controls.Add(titleBox);

            Label titleLabel = new Label();
            titleLabel.Text = "Movie title   ";
            titleLabel.Location = new Point(75, 110);
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Sans Serif", 20);
            this.Controls.Add(titleLabel);

            theaters = new ComboBox();
            theaters.Text = "Select a theater  ";
            theaters.Width = 250;
            theaters.Font = new Font("Sans Serif", 20);
            for (int i = 1; i < 13; i++)
                theaters.Items.Add(i);
            theaters.Location = new Point(2 * ClientSize.Width / 3, 350);
            this.Controls.Add(theaters);

            posterArea = new PictureBox();
            posterArea.Location = new Point(200, 200);
            posterArea.Size = new Size(250, 320);
            this.Controls.Add(posterArea);

            start = new DateTimePicker();
            start.Format = DateTimePickerFormat.Custom;
            start.CustomFormat = "HH:mm tt";
            start.ShowCheckBox = true;
            start.Checked = false;
            start.ShowUpDown = true;
            start.Font = new Font("Sans Serif", 14);
            start.Location = new Point(ClientSize.Width - start.Width - 80, 11 * ClientSize.Height / 16 - 50);
            start.Width = 150;
            this.Controls.Add(start);

            end = new DateTimePicker();
            end.Format = DateTimePickerFormat.Custom;
            end.CustomFormat = "HH:mm tt";
            end.ShowCheckBox = true;
            end.Checked = false;
            end.ShowUpDown = true;
            end.Font = new Font("Sans Serif", 14);
            end.Location = new Point(ClientSize.Width - end.Width - 80, 11 * ClientSize.Height / 16);
            end.Width = 150;
            this.Controls.Add(end);

            message = new Label();
            message.Location = new Point(20, ClientSize.Height - 260);
            message.Font = new Font("Sans Serif", 16);
            message.ForeColor = Color.Red;
            message.AutoSize = true;
            this.Controls.Add(message);

            date = new DateTimePicker();
            date.Value = DateTime.Today;
            date.ShowCheckBox = true;
            date.Checked = false;
            date.Location = new Point(150, 2 * ClientSize.Height / 3);
            date.Font = new Font("Sans Serif", 16);
            date.Width = 400;
            this.Controls.Add(date);

            addNew = new Button();
            addNew.Text = "Add New";
            addNew.AutoSize = true;
            addNew.Location = new Point(ClientSize.Width / 2 - addNew.Width / 2, 3 * ClientSize.Height / 4);
            addNew.BackColor = Color.White;
            addNew.Padding = new Padding(6);
            addNew.Font = new Font("Sans Serif", 25);
            addNew.Enabled = false;
            this.Controls.Add(addNew);

            submit = new Button();
            submit.Text = "Submit";
            submit.AutoSize = true;
            submit.Location = new Point(ClientSize.Width / 2 - submit.Width / 2, ClientSize.Height - 100);
            submit.BackColor = Color.White;
            submit.Padding = new Padding(6);
            submit.Font = new Font("Sans Serif", 20);
            submit.Enabled = false;
            this.Controls.Add(submit);

            Label dateLabel = new Label();
            dateLabel.Text = "Day";
            dateLabel.Location = new Point(85, 2 * ClientSize.Height / 3 + 3);
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Sans Serif", 16);
            dateLabel.Width = 100;
            this.Controls.Add(dateLabel);

            Label startLabel = new Label();
            startLabel.Text = "Start Time";
            startLabel.AutoSize = true;
            startLabel.Location = new Point(ClientSize.Width - start.Width - 150 - startLabel.Width, 11 * ClientSize.Height / 16 - 50);
            startLabel.Font = new Font("Sans Serif", 16);
            this.Controls.Add(startLabel);

            Label endLabel = new Label();
            endLabel.Text = "End Time";
            endLabel.AutoSize = true;
            endLabel.Location = new Point(ClientSize.Width - end.Width - 150 - endLabel.Width, 11 * ClientSize.Height / 16);
            endLabel.Font = new Font("Sans Serif", 16);
            this.Controls.Add(endLabel);

            Label showtimes = new Label();
            showtimes.Text = "Showtimes";
            showtimes.Location = new Point(ClientSize.Width / 2 - showtimes.Width / 2, 7 * ClientSize.Height / 12);
            showtimes.Font = new Font("Sans Serif", 20);
            showtimes.AutoSize = true;
            this.Controls.Add(showtimes);

            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            logout.Click += new EventHandler(Logout);
            submit.Click += new EventHandler(Submit);
            addNew.Click += new EventHandler(AddNew);
            theaters.DropDownClosed += new EventHandler(SelectThr);
        }

        private void Logout(object sender, EventArgs e)
        {
            LogoutCtrl logoutCtrl = new LogoutCtrl(_token);
            logoutCtrl.Initiate(this);
        }

        private void Submit(object sender, EventArgs e)
        {
            DateTime? date = null, start = null, end = null;

            if (this.date.Checked && this.start.Checked && this.end.Checked)
            {
                date = this.date.Value.Subtract(this.date.Value.TimeOfDay); //set date's time element to 00:00 to avoid incrementing TimeOfDay of start, end
                start = ((DateTime)date).Add(this.start.Value.TimeOfDay);
                end = ((DateTime)date).Add(this.end.Value.TimeOfDay);
            }

            (_ctrl as EntryCtrl).Submit(_entryDraft, start, end);
        }
        public override void Close()
        {
            this.Dispose();
            (this as Form).Close();
        }

        public override void Display(string msg)
        {
            message.Text = msg;
            message.Refresh();
            Thread.Sleep(3000);
        }

        public void DisplayPoster(string path)
        {
            posterArea.ImageLocation = path;
            posterArea.Refresh();
        }

        private void SelectThr(object sender, EventArgs e)
        {
            string title;

            if ((title = titleBox.Text) != "")
            {
                (_ctrl as EntryCtrl).Select(title);
                addNew.Enabled = true;
            }
        }

        private void AddNew(object sender, EventArgs e)
        {
            if (!this.date.Checked || !this.start.Checked || !this.end.Checked)
                return;

            DateTime date = this.date.Value.Subtract(this.date.Value.TimeOfDay); //set date to midnight
            DateTime start = date.Add(this.start.Value.TimeOfDay);
            DateTime end = date.Add(this.end.Value.TimeOfDay);

            if (_entryDraft == null)
                _entryDraft = (_ctrl as EntryCtrl).CreateEntry(titleBox.Text, theaters.SelectedIndex + 1, start, end);
            else
                (_ctrl as EntryCtrl).AddShowTime(_entryDraft, start, end);

            if (_entryDraft.Showings.Count > 0)
                submit.Enabled = true;

            //foreach (var showtime in _entryDraft.Showings)
            //    MessageBox.Show(_entryDraft.Title + " " + _entryDraft.Theatre + " " + ((DateTime)showtime.Start).ToString("yyyy-MM-dd HH:mm:ss") +
            //        " " + ((DateTime)showtime.End).ToString("yyyy-MM-dd HH:mm:ss"));

            RefreshTimesMenu();
        }

        private void RefreshTimesMenu()
        {
            date.Checked = start.Checked = end.Checked = false;
        }

    }
}