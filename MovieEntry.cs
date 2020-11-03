using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MovieEntry
    {
        public int Theatre { get; set; }
        public string Title { get; set; }
        public List<Showtime> Showings { get; set; }
        public int SeatsAvailable { get; set; }
        public string PosterPath { get; set; }

        public MovieEntry()
        {
            Showings = new List<Showtime>();
        }
        public MovieEntry(int theatre, string title, List<Showtime> showings, int seats, string posterpath) 
        {
            Theatre = theatre;
            Title = title;
            Showings = showings;
            SeatsAvailable = seats;
            PosterPath = posterpath;
        }

        public MovieEntry(int theatre, string title, List<Showtime> showings)
        {
            Theatre = theatre;
            Title = title;
            Showings = showings;
        }
        public void AddTime(Showtime time)
        {
            Showings.Add(time);
        }
    }
}
