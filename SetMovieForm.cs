using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;
using Entity;

namespace Boundary
{
    public partial class SetMovieForm : IForm
    {
        private MovieEntry _entryDraft;

        private string _token;

        private Button logout, addNew, submit;

        private TextBox titleBox;

        private ComboBox theaters;

        private PictureBox posterArea;

        private DateTimePicker date, start, end;

        private Label message;

        public SetMovieForm(EntryCtrl ctrl, string token)
        {
            InitializeComponent();
            _ctrl = ctrl;
            _token = token;
            Setmovieform_Load();
        }
       
    }
}
