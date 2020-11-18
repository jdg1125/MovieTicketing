using Control;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace Boundary
{
    partial class Homepage : IForm
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
            this.WindowState = FormWindowState.Maximized;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Homepage";
        }

        private void Homepage_Load()
        {
            Label welcome = new Label();
            welcome.Text = "Welcome";
            welcome.AutoSize = true;
            welcome.Font = new Font("Sans Serif", 30);
            welcome.Location = new Point(700, 25);
            this.Controls.Add(welcome);

            reserve = new Button();
            reserve.Text = "Reserve Tickets";
            reserve.Location = new Point(50, 200);
            reserve.AutoSize = true;
            reserve.BackColor = Color.White;
            reserve.Padding = new Padding(6);
            reserve.Font = new Font("Sans Serif", 30);

            logout = new Button();
            logout.Text = "Log out";
            logout.Location = new Point(1000, 25);
            logout.AutoSize = true;
            logout.BackColor = Color.White;
            logout.Padding = new Padding(6);
            logout.Font = new Font("Sans Serif", 15);
            this.Controls.Add(logout);

            CustomizeHomepage();
            AddEventHandlers();

        }
        private void CustomizeHomepage()
        {
            if (_token[0] == 'e')
            {
                reserve.Location = new Point(650, 200);
            }
            this.Controls.Add(reserve);
            if (_token[0] == 'a')
            {
                set = new Button();
                set.Text = "Set Movies";
                set.Location = new Point(850, 200);
                set.AutoSize = true;
                set.BackColor = Color.White;
                set.Padding = new Padding(6);
                set.Font = new Font("Sans Serif", 30);
                this.Controls.Add(set);

            }
        }

        private void AddEventHandlers()
        {
            logout.Click += new EventHandler(Logout);
            reserve.Click += new EventHandler(Reserve);
            if (set != null)
                set.Click += new EventHandler(SetMovie);
        }

        private void Logout(object sender, EventArgs e)
        {
            LogoutCtrl logoutCtrl = new LogoutCtrl(_token);
            logoutCtrl.Initiate(this);
        }
        private void Reserve(object sender, EventArgs e)
        {
            ReserveCtrl reserveCtrl = new ReserveCtrl(_token);
            reserveCtrl.Initiate(this);
        }
        private void SetMovie(object sender, EventArgs e)
        {
            EntryCtrl entryCtrl = new EntryCtrl(_token);
            entryCtrl.Initiate(this);
        }
        public override void Close()
        {
            this.Dispose();
            (this as Form).Close();
        }

        public override void Display(string s) { }
    }
}