using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditApplicationMVC.Models
{
    public class Credit
    {
        public virtual int CreditId { get; set; }
        public virtual string CreditName { get; set; }
        public virtual int Period { get; set; } 
        public virtual int Amount { get; set; }
        public virtual int Percent { get; set; }
    }
}