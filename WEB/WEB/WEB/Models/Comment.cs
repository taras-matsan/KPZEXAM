using System;
using System.Collections.Generic;

#nullable disable

namespace WEB.Models
{
    public partial class Comment
    {
        public string CommentText { get; set; }
        public int CommentId { get; set; }
        public int? FilmId { get; set; }
        public int? SubscriberId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}
