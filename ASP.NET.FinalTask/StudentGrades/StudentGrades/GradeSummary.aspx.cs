using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentGradesDAL;

namespace StudentGrades
{
    public partial class GradeSummary : System.Web.UI.Page
    {
        StudentGradesContext studentGradesContext = new StudentGradesContext();
        private static string currentSortExpression = "StudentFullName";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListCourseName.DataSource = CourseNameListDataModel.GetCourseNameList("CourseName");
                DropDownListCourseName.DataBind();
                LabelGradeSummaryStatus.Text = "Данные загружены";
            }
            GridViewGradesSummary.DataSource = StudentGradeSummaryDataModel.GetStudentGradeSummaryList(studentGradesContext.Courses.Find(Int32.Parse(DropDownListCourseName.SelectedValue)), currentSortExpression);
            GridViewGradesSummary.DataBind();
        }

        protected void GridViewGradesSummary_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                currentSortExpression = e.SortExpression;
                GridViewGradesSummary.DataSource = StudentGradeSummaryDataModel.GetStudentGradeSummaryList(studentGradesContext.Courses.Find(Int32.Parse(DropDownListCourseName.SelectedValue)), currentSortExpression);
                GridViewGradesSummary.DataBind();
                LabelGradeSummaryStatus.Text = $"Таблица отсортирована по параметру {e.SortExpression}";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }
    }
}