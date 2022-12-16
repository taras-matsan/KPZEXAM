using System;
using System.Collections.Generic;

#nullable disable

namespace WEB.Models
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
        }

        public string SubscriberNick { get; set; }
        public int SubscriberId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
