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
        public EntryCtrl()
        {
            _dbConn = new DBConnector();
            _form = new SetMovieForm(this);
        }

        public override void Initiate(IForm sender, string token)
        {
            _token = token;
            sender.Close();
            _form.Show();
        }

        public void Select(string title)
        {
            _poster = _dbConn.GetPoster(title);
            (_form as SetMovieForm).DisplayPoster(_poster.Path);
        }

        public MovieEntry CreateEntry(string title, int theater, DateTime start, DateTime end)
        {
            if (start != null && end != null)   //if we can grey out button on form until 3 values are selected, we can remove this error check
                return new MovieEntry(theater, title, new Showtime(start, end));

            return null;
        }

        public void AddShowTime(MovieEntry entry, DateTime start, DateTime end)
        {
            if (start != null && end != null)   //if we can grey out button on form until 3 values are selected, we can remove this error check
                entry.AddTime(new Showtime(start, end));
        }
        public void Submit(MovieEntry entry, DateTime start, DateTime end)
        {
            if (start != null && end != null)
                entry.AddTime(new Showtime(start, end));

            if (Validate(entry, out string msg))
                _dbConn.Save(entry);

            _form.Display(msg);
            _form.Close();
            Homepage homepage = new Homepage(_token);
            // do we have to call a method in homepage to display it?
        }

        private bool Validate(MovieEntry entry, out string msg)
        {

            if (!CompletionCheck(entry, out msg))
                return false;

            if (!TitleCheck(entry, out msg))
                return false;

            return ShowingsCheck(entry, out msg);
           
        }

        private bool CompletionCheck(MovieEntry entry, out string msg)
        {
            if (entry==null || entry.Showings.Count == 0 || _poster == null) 
            {
                if (entry == null)                                      //remove this condition if grey out buttons eliminates null entry possibility
                    msg = "Entry was null. Nothing to validate.";
                else
                {
                    msg = "Invalid entry. ";
                    msg += (_poster == null) ? "Database does not contain a matching movie poster." : "You must supply at least one show time.";
                }
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

            for (int i = 1; isValid && i < len; i++)  // make sure all showings have same duration > 0
            {
                time = entry.Showings[i];
                if (time.End - time.Start != duration)
                    isValid = false;
            }

            for(int i=0; isValid && i<len; i++)    // check for concurrent showings
            {
                time = entry.Showings[i];
                DateTime tmpStart, tmpEnd;
                
                for(int j = i+1; isValid && j<len; j++ )
                {
                    tmpStart = (DateTime)entry.Showings[j].Start;
                    tmpEnd = (DateTime)entry.Showings[j].End;
                    isValid = (tmpEnd < time.Start || tmpStart > time.End);  //OR because valid times are in the union of(tmp's that finish before time.Start, tmp's that start after time.End)
                }
            }

            msg = isValid ? "Entry was successfully created." : "Invalid entry. A show time must contain chronological start and end times. All show time durations must match. No concurrent showings allowed.";
            return isValid;
        }
    }
}
