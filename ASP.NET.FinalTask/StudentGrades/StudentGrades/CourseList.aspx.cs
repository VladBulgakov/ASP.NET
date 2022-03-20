using StudentGradesDAL;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace StudentGrades
{
    public partial class CourseList : System.Web.UI.Page
    {
        StudentGradesContext studentGradesContext = new StudentGradesContext();
        private static string currentSortExpression = "CourseName";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewCourses.DataSource = studentGradesContext.Courses.SortBy(currentSortExpression).ToList<Course>();
                GridViewCourses.DataBind();
                LabelCourseStatus.Text = "Данные загружены";
            }
        }

        protected void GridViewCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                try
                {
                    Course newCourse = new Course();
                    newCourse.CourseName = (GridViewCourses.FooterRow.FindControl("TextBoxCourseNameFooter") as TextBox).Text.Trim();
                    newCourse.CourseDescription = (GridViewCourses.FooterRow.FindControl("TextBoxCourseDescriptionFooter") as TextBox).Text.Trim();
                    string stringToConvert = (GridViewCourses.FooterRow.FindControl("TextBoxCourseTimeFooter") as TextBox).Text.Trim();
                    int tempVal = 0;
                    newCourse.CourseTime = Int32.TryParse(stringToConvert, out tempVal) ? Int32.Parse(stringToConvert) : (int?)null;
                    studentGradesContext.Courses.Add(newCourse);
                    studentGradesContext.SaveChanges();
                    GridViewCourses.DataSource = studentGradesContext.Courses.SortBy(currentSortExpression).ToList<Course>();
                    GridViewCourses.DataBind();
                    LabelCourseStatus.Text = "Запись добавлена";
                }
                catch (Exception ex)
                {
                    Response.Write($"Ошибка!<br/>{ex.Message}");
                }
            }
        }

        protected void GridViewCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewCourses.EditIndex = e.NewEditIndex;
                GridViewCourses.DataSource = studentGradesContext.Courses.SortBy(currentSortExpression).ToList<Course>();
                GridViewCourses.DataBind();
                LabelCourseStatus.Text = "Изменение записи";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewCourses.EditIndex = -1;
                GridViewCourses.DataSource = studentGradesContext.Courses.SortBy(currentSortExpression).ToList<Course>();
                GridViewCourses.DataBind();
                LabelCourseStatus.Text = "Изменения отменены";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Course updCourse = new Course();
                updCourse = studentGradesContext.Courses.Find(GridViewCourses.DataKeys[e.RowIndex].Value);
                updCourse.CourseName = (GridViewCourses.Rows[e.RowIndex].FindControl("TextBoxCourseName") as TextBox).Text.Trim();
                updCourse.CourseDescription = (GridViewCourses.Rows[e.RowIndex].FindControl("TextBoxCourseDescription") as TextBox).Text.Trim();
                string stringToConvert = (GridViewCourses.Rows[e.RowIndex].FindControl("TextBoxCourseTime") as TextBox).Text.Trim();
                int tempVal = 0;
                updCourse.CourseTime = Int32.TryParse(stringToConvert, out tempVal) ? Int32.Parse(stringToConvert) : (int?)null;
                studentGradesContext.SaveChanges();
                GridViewCourses.EditIndex = -1;
                GridViewCourses.DataSource = studentGradesContext.Courses.SortBy(currentSortExpression).ToList<Course>();
                GridViewCourses.DataBind();
                LabelCourseStatus.Text = "Изменения сохранены";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewCourses_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                currentSortExpression = e.SortExpression;
                GridViewCourses.DataSource = studentGradesContext.Courses.SortBy(currentSortExpression).ToList<Course>();
                GridViewCourses.DataBind();
                LabelCourseStatus.Text = $"Таблица отсортирована по параметру {e.SortExpression}";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Course delCourse = new Course();
                delCourse = studentGradesContext.Courses.Find(GridViewCourses.DataKeys[e.RowIndex].Value);
                studentGradesContext.Courses.Remove(delCourse);
                studentGradesContext.SaveChanges();
                GridViewCourses.EditIndex = -1;
                GridViewCourses.DataSource = studentGradesContext.Courses.SortBy(currentSortExpression).ToList<Course>();
                GridViewCourses.DataBind();
                LabelCourseStatus.Text = "Запись удалена";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }
    }
}