

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MovieEntry
    {
        public int Id { get; set; }
        public int Theatre { get; set; }
        public string Title { get; set; }
        public List<Showtime> Showings { get; set; }
        public Showtime Time { get; set; }
        public int SeatsAvailable { get; set; }
        public string PosterPath { get; set; }


        public MovieEntry(int id, int theatre, string title, Showtime time, int seats, string posterpath)
        {
            Id = id;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("id: " + Id);
            sb.Append("\ntheater: " + Theatre);
            sb.Append("\n" + Title);
            sb.Append("\nstart: " + Time.Start.ToString());
            sb.Append("\nend: " + Time.End.ToString());
            sb.Append("\nseats: " + SeatsAvailable);
            sb.Append("\n" + PosterPath);

            return sb.ToString();



        }
    }
}
