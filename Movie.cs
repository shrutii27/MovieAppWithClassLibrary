using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWithClassLibrary
{
    [Serializable]
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }

    }
}
