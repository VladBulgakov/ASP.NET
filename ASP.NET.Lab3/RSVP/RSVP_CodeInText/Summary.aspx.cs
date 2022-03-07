using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace RSVP
{
    public partial class Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetNoShowHtml()
        {
            StringBuilder htmlStr = new StringBuilder(); 
            var noShowData = ResponseRepository.GetRepository().GetAllResponses().Where(r => !r.WillAttend.Value); 
            foreach (var rsvp in noShowData)
            {
                htmlStr.Append(String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td>", rsvp.Name, rsvp.Email, rsvp.Phone));
            }
            return htmlStr.ToString();
        }
    }
}