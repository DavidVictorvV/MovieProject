using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class Movie
    {
        public Guid ID { get; set; }

        public string MovieName { get; set; }

        public string Genre { get; set; }

        public int MovieLength  { get; set; }

        public int ReleaseDate { get; set; }


    }
}
