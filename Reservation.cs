using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Reservation
    {
        public MovieEntry MovieEntry { get; set; }
        public int NumSeats { get; set; }

        public Reservation(MovieEntry entry, int seats)
        {
            MovieEntry = entry;
            NumSeats = seats;
        }

    }
}
