//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KPZEXAM.Models
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Review
    {
        public string ReviewText { get; set; }
        public int ReviewID { get; set; }
        public Nullable<int> FilmID { get; set; }
        public Nullable<int> SubscriberID { get; set; }
    
        public virtual Film Film { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}
