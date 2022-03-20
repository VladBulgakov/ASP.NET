using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentGradesDAL;

namespace StudentGrades
{
    public partial class BestWorstStudents : System.Web.UI.Page
    {
        StudentGradesContext studentGradesContext = new StudentGradesContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewBestList.DataSource = StudentsStatisticsDataModel.GetBestFiveStudentList();
                GridViewBestList.DataBind();
                GridViewWorstList.DataSource = StudentsStatisticsDataModel.GetWorstFiveStudentList();
                GridViewWorstList.DataBind();
                LabelBestWorstStatus.Text = "Данные загружены";
            }
        }
    }
}