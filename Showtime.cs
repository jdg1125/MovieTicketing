using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Showtime
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set;  }

        public Showtime(DateTime? start, DateTime? end)
        {
            Start = start;
            End = end;
        }
    }
}
