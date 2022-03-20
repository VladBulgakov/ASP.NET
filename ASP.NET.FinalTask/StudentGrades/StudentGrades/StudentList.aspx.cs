using StudentGradesDAL;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace StudentGrades
{
    public partial class StudentList : System.Web.UI.Page
    {
        StudentGradesContext studentGradesContext = new StudentGradesContext();
        private static string currentSortExpression = "LastName";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewStudents.DataSource = studentGradesContext.Students.SortBy(currentSortExpression).ToList<Student>();
                GridViewStudents.DataBind();
                LabelStudentStatus.Text = "Данные загружены";
            }
        }

        protected void GridViewStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                try
                {
                    Student newStudent = new Student();
                    newStudent.FirstName = (GridViewStudents.FooterRow.FindControl("TextBoxFirstNameFooter") as TextBox).Text.Trim();
                    newStudent.LastName = (GridViewStudents.FooterRow.FindControl("TextBoxLastNameFooter") as TextBox).Text.Trim();
                    newStudent.Patronymic = (GridViewStudents.FooterRow.FindControl("TextBoxPatronymicFooter") as TextBox).Text.Trim();
                    newStudent.BirthDate = DateTime.Parse((GridViewStudents.FooterRow.FindControl("TextBoxBirthDateFooter") as TextBox).Text.Trim());
                    studentGradesContext.Students.Add(newStudent);
                    studentGradesContext.SaveChanges();
                    GridViewStudents.DataSource = studentGradesContext.Students.SortBy(currentSortExpression).ToList<Student>();
                    GridViewStudents.DataBind();
                    LabelStudentStatus.Text = "Запись добавлена";
                }
                catch (Exception ex)
                {
                    Response.Write($"Ошибка!<br/>{ex.Message}");
                }
            }
        }

        protected void GridViewStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewStudents.EditIndex = e.NewEditIndex;
                GridViewStudents.DataSource = studentGradesContext.Students.SortBy(currentSortExpression).ToList<Student>();
                GridViewStudents.DataBind();
                LabelStudentStatus.Text = "Изменение записи";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewStudents.EditIndex = -1;
                GridViewStudents.DataSource = studentGradesContext.Students.SortBy(currentSortExpression).ToList<Student>();
                GridViewStudents.DataBind();
                LabelStudentStatus.Text = "Изменения отменены";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Student updStudent = new Student();
                updStudent = studentGradesContext.Students.Find(GridViewStudents.DataKeys[e.RowIndex].Value);
                updStudent.FirstName = (GridViewStudents.Rows[e.RowIndex].FindControl("TextBoxFirstName") as TextBox).Text.Trim();
                updStudent.LastName = (GridViewStudents.Rows[e.RowIndex].FindControl("TextBoxLastName") as TextBox).Text.Trim();
                updStudent.Patronymic = (GridViewStudents.Rows[e.RowIndex].FindControl("TextBoxPatronymic") as TextBox).Text.Trim();
                updStudent.BirthDate = DateTime.Parse((GridViewStudents.Rows[e.RowIndex].FindControl("TextBoxBirthDate") as TextBox).Text.Trim());
                studentGradesContext.SaveChanges();
                GridViewStudents.EditIndex = -1;
                GridViewStudents.DataSource = studentGradesContext.Students.SortBy(currentSortExpression).ToList<Student>();
                GridViewStudents.DataBind();
                LabelStudentStatus.Text = "Изменения сохранены";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewStudents_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                currentSortExpression = e.SortExpression;
                GridViewStudents.DataSource = studentGradesContext.Students.SortBy(currentSortExpression).ToList<Student>();
                GridViewStudents.DataBind();
                LabelStudentStatus.Text = $"Таблица отсортирована по параметру {e.SortExpression}";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Student delStudent = new Student();
                delStudent = studentGradesContext.Students.Find(GridViewStudents.DataKeys[e.RowIndex].Value);
                studentGradesContext.Students.Remove(delStudent);
                studentGradesContext.SaveChanges();
                GridViewStudents.EditIndex = -1;
                GridViewStudents.DataSource = studentGradesContext.Students.SortBy(currentSortExpression).ToList<Student>();
                GridViewStudents.DataBind();
                LabelStudentStatus.Text = "Запись удалена";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void StudentBirthDateValidator_Init(object sender, EventArgs e)
        {
            string maxDate = DateTime.Now.Year.ToString() + "/01/01";
            string minDate = "1980/01/01";
            ((RangeValidator)sender).MinimumValue = minDate;
            ((RangeValidator)sender).MaximumValue = maxDate;
        }
    }
}