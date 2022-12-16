using System;
using System.Collections.Generic;

#nullable disable

namespace WEB.Models
{
    public partial class Review
    {
        public string ReviewText { get; set; }
        public int ReviewId { get; set; }
        public int? FilmId { get; set; }
        public int? SubscriberId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}
