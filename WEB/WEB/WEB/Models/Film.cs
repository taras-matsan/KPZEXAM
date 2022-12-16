using System;
using System.Collections.Generic;

#nullable disable

namespace WEB.Models
{
    public partial class Film
    {
        public Film()
        {
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
        }

        public string FilmName { get; set; }
        public string FilmPath { get; set; }
        public int FilmId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
