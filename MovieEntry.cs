﻿using System;
using System.Collections.Generic;
using System.Text;

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
            string delimiter = " / ";
            StringBuilder sb = new StringBuilder();
            sb.Append("Th: ");
            sb.Append(Theatre);
            sb.Append(delimiter);
            sb.Append(Title);
            sb.Append(delimiter);
            sb.Append(((DateTime)Time.Start).ToString("hh:mm tt"));
            sb.Append(delimiter);
            sb.Append(SeatsAvailable);
            return sb.ToString();
        }
    }
}
