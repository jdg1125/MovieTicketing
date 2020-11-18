using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Control;

namespace Boundary
{
    public partial class ReserveForm : IForm
    {
        private List<MovieEntry> _movies;

        private Button logout, reserve, search;
        private TextBox enterSeats;
        private ComboBox movieSelector;
        private PictureBox posterArea;
        private DateTimePicker date;
        private Label message;

        public ReserveForm(ReserveCtrl ctrl)
        {
            InitializeComponent();
            _ctrl = ctrl;
            ReserveForm_Load();
        }
    }
}
