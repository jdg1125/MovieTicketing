using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MovieEntry
    {
        public int Theatre { get; set; }
        public string Title { get; set; }
        public List<Showtime> Showings { get; set; }
        public Showtime Time { get; set; }
        public int SeatsAvailable { get; set; }
        public string PosterPath { get; set; }


        public MovieEntry(int theatre, string title, Showtime time, int seats, string posterpath)
        {
            Theatre = theatre;
            Title = title;
            Time = time;
            SeatsAvailable = seats;
            PosterPath = posterpath;
        } 

        public MovieEntry(int theatre, string title, Showtime showing)    
        {
            Theatre = theatre;
            Title = title;
            Showings = new List<Showtime>();
            Showings.Add(showing);
        }
        public void AddTime(Showtime time)
        {
            Showings.Add(time);
        }
    }
}
