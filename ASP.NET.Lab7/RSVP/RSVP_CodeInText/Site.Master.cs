using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RSVP_CodeInText
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long numberOfVisits = 0;
            if (Application["numberOfVisits"] != null) 
            {
                numberOfVisits = long.Parse(Application["numberOfVisits"].ToString()); 
            }
            VisitorLiteral.Text = "Число посещений: " + numberOfVisits.ToString();
        }
    }
}