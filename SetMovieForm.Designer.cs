using Control;
using Entity;

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
        public override void Display(string msg)
        {

        }

        public void DisplayPoster(string path)
        {
            //Use API of PictureBox element to render picture
        }
    }
}