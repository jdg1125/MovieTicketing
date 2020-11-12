using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Poster
    {
        public string MovieTitle { get; set; }
        public string Path { get; set; }

        public Poster(string title, string path)
        {
            MovieTitle = title;
            Path = path;
        }
    }
}
