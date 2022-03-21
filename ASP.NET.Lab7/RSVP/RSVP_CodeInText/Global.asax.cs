using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace RSVP_CodeInText
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["numberOfVisits"] = 0;
        }

        void Session_Start()
        {
            Application["numberOfVisits"] = long.Parse(Application["numberOfVisits"].ToString()) + 1;
        }
    }
}