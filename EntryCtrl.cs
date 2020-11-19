using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boundary;
using Entity;

namespace Control
{
    public class EntryCtrl : IController
    {
        private string _token;

        private Poster _poster;
        public EntryCtrl(string token)
        {
            _dbConn = new DBConnector();
            _token = token;
            _form = new SetMovieForm(this, _token);

        }

        public override void Initiate(IForm sender)
        {
            sender.Close();
            _form.Show();
        }

        public void Select(string title)
        {
            if ((_poster = _dbConn.GetPoster(title)) == null)
                return;
            (_form as SetMovieForm).DisplayPoster(_poster.Path);
        }

        public MovieEntry CreateEntry(string title, int theater, DateTime start, DateTime end)
        {
            return new MovieEntry(theater, title, new Showtime(start, end));
        }

        public void AddShowTime(MovieEntry entry, DateTime start, DateTime end)
        {
            entry.AddTime(new Showtime(start, end));
        }
        public void Submit(MovieEntry entry, DateTime? start, DateTime? end)
        {
            if (start != null && end != null)
                entry.AddTime(new Showtime(start, end));

            int num;
            if (Validate(entry, out string msg))
                if ((num = _dbConn.Save(entry)) == 0)
                    msg = "Invalid entry. The requested theater already has a movie scheduled at this time.";
                else
                {
                    int i = msg.IndexOf('e') - 2;
                    msg = msg.Insert(i, num.ToString());
                }

            _form.Display(msg);
            _form.Close();
            Homepage homepage = new Homepage(_token);
            homepage.Show();
        }

        private bool Validate(MovieEntry entry, out string msg)
        {

            if (!PosterCheck(entry, out msg))
                return false;

            if (!TitleCheck(entry, out msg))
                return false;

            return ShowingsCheck(entry, out msg);

        }

        private bool PosterCheck(MovieEntry entry, out string msg)
        {
            if ((_poster = _dbConn.GetPoster(entry.Title)) == null) //user may have changed title without changing theater - need to update poster
            {
                msg = "Invalid entry. Database does not contain a matching movie poster.";
                return false;
            }

            msg = "";
            return true;
        }

        private bool TitleCheck(MovieEntry entry, out string msg)
        {
            HashSet<char> forbidden = new HashSet<char>() { '*', ';', '|', '&', '=', '.' };
            string title = entry.Title;
            int len = title.Length;
            bool isValid = len > 0;

            for (int i = 0; isValid && i < len; i++)
                if (forbidden.Contains(title[i]))
                    isValid = false;

            if (!isValid)
            {
                msg = "Invalid entry. ";
                msg += len == 0 ? "Title cannot be empty." : "Title contains invalid characters * ; | . & =";
                return false;
            }

            msg = "";
            return true;
        }

        private bool ShowingsCheck(MovieEntry entry, out string msg)
        {
            int len = entry.Showings.Count;
            Showtime time = entry.Showings[0];
            TimeSpan duration = (DateTime)time.End - (DateTime)time.Start;

            bool isValid = duration.TotalMinutes > 0;
            if (!isValid)  //entries crossing over midnight
            {
                time.End = ((DateTime)time.End).AddDays(1);
                duration = (DateTime)time.End - (DateTime)time.Start;
                isValid = !isValid;
            }

            for (int i = 1; isValid && i < len; i++)  // make sure all showings have same duration 
            {
                time = entry.Showings[i];
                if (time.End - time.Start != duration)
                {
                    if (((TimeSpan)(time.End - time.Start)).TotalMinutes < 0) //entries crossing over midnight
                    {
                        time.End = ((DateTime)time.End).AddDays(1);
                        isValid = (DateTime)time.End - (DateTime)time.Start == duration;
                    }
                }
            }

            for (int i = 0; isValid && i < len; i++)    // check for concurrent showings
            {
                time = entry.Showings[i];
                DateTime tmpStart, tmpEnd;

                for (int j = i + 1; isValid && j < len; j++)
                {
                    tmpStart = (DateTime)entry.Showings[j].Start;
                    tmpEnd = (DateTime)entry.Showings[j].End;
                    isValid = (tmpEnd < time.Start || tmpStart > time.End);  //OR because valid times are in the union of(tmp's that finish before time.Start, tmp's that start after time.End)
                }
            }

            msg = isValid ? "\n                                   entries were successfully created." :
                "Invalid entry. A show time must contain chronological start and end times. \nAll show time durations must match. No concurrent showings allowed.";  //whitespace needed for rendering
            return isValid;
        }
    }
}
