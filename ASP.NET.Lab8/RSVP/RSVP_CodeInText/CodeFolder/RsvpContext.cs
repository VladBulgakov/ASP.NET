using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RSVP
{
    public class RsvpContext:DbContext
    {
        public RsvpContext() : base("SeminarDB")
        { }
        public DbSet<GuestResponse> GuestResponses { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}