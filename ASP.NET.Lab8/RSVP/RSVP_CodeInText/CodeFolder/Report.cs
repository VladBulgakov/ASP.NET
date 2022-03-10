using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RSVP
{
    public class Report
    {
        public int ReportId { get; set; }
        public string NameReport { get; set; }
        public string Annotation { get; set; }
        public GuestResponse GuestRes { get; set; }
        public Report() { }
        public Report(string title, string annot)
        {
            NameReport = title;
            Annotation = annot;
        }
    }
}