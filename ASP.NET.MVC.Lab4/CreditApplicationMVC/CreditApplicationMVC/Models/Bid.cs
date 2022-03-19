using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditApplicationMVC.Models
{
    public class Bid
    {
        public virtual int BidId { get; set; }
        public virtual string PersonName { get; set; }
        public virtual string CreditName { get; set; } 
        public virtual DateTime bidDate { get; set; }
    }
}