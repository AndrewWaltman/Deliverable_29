using System;
using System.Collections.Generic;

namespace Deliverable_29.Models
{
    public partial class MoviesApi
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public decimal? Imdbrating { get; set; }
    }
}
