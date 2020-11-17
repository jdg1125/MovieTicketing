using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boundary;
using Entity;

namespace Control
{
    public class ReserveCtrl : IController
    {
        private string _token;

        public override void Initiate(IForm sender)
        {
            sender.Close();
            _form.Show();
        }

        public ReserveCtrl(string token)
        {
            _token = token;
            _dbConn = new DBConnector();
            _form = new ReserveForm(this);
        }

        public void Select(DateTime date)
        {
            List<MovieEntry> entries = _dbConn.GetMovieEntries(date);
            (_form as ReserveForm).Display(entries);
        }

        public void Select(MovieEntry entry) =>
            (_form as ReserveForm).DisplayPoster(entry.PosterPath);

        public void Submit(MovieEntry entry, int seats)
        {
            Reservation res = new Reservation(entry, seats);

            if (Validate(res, out string msg))
                msg += _dbConn.Save(res);
            
            _form.Display(msg);
            _form.Close();
            Homepage homepage = new Homepage(_token);
            //need to explicitly display homepage??
        }

        private bool Validate(Reservation res, out string msg)
        {
            bool isValid = res.NumSeats <= res.MovieEntry.SeatsAvailable;
            msg = isValid ? "Reservation made successfully. Your confirmation number: " : "";
            return isValid;
        }
    }
}
