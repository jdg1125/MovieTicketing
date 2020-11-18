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
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "Homepage";
        }

        private void Homepage_Load()
        {
            Label header = new Label();
            header.Text = "Welcome";
            header.AutoSize = true;
            header.Font = new Font("Sans Serif", 30);
            header.Location = new Point(ClientSize.Width/2 - header.Width, 25);
            this.Controls.Add(header);

            reserve = new Button();
            reserve.Text = "Reserve Tickets";
            reserve.Location = new Point(ClientSize.Width/9, ClientSize.Height/2);
            reserve.AutoSize = true;
            reserve.BackColor = Color.White;
            reserve.Padding = new Padding(6);
            reserve.Font = new Font("Sans Serif", 30);

            logout = new Button();
            logout.Text = "Log out";
            logout.Location = new Point(ClientSize.Width - 2*logout.Width, 25);
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
                reserve.Location = new Point(5*ClientSize.Width/16, ClientSize.Height/2);
            }
            this.Controls.Add(reserve);
            if (_token[0] == 'a')
            {
                set = new Button();
                set.Text = "Set Movies";
                set.Location = new Point(5*ClientSize.Width/9, ClientSize.Height/2);
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