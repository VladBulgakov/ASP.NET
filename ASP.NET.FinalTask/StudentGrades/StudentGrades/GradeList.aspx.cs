using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentGradesDAL;

namespace StudentGrades
{
    public partial class GradeList : System.Web.UI.Page
    {
        StudentGradesContext studentGradesContext = new StudentGradesContext();
        private static string currentSortExpression = "GradeDate";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGradesTable();
                FillGradesTableFooter();
            }
        }

        protected void GridViewGrades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                try
                {
                    StudentGrade newStudentGrade = new StudentGrade();
                    newStudentGrade.GradeDate = DateTime.Parse((GridViewGrades.FooterRow.FindControl("TextBoxGradeDateFooter") as TextBox).Text.Trim());
                    newStudentGrade.Student = studentGradesContext.Students.Find(Int32.Parse((GridViewGrades.FooterRow.FindControl("DropDownListNameFooter") as DropDownList).SelectedValue));
                    newStudentGrade.Course = studentGradesContext.Courses.Find(Int32.Parse((GridViewGrades.FooterRow.FindControl("DropDownListCourseNameFooter") as DropDownList).SelectedValue));
                    newStudentGrade.Grade = Int32.Parse((GridViewGrades.FooterRow.FindControl("DropDownListGradeFooter") as DropDownList).SelectedItem.Value);
                    newStudentGrade.Comment = (GridViewGrades.FooterRow.FindControl("TextBoxCommentFooter") as TextBox).Text.Trim();
                    studentGradesContext.StudentGrades.Add(newStudentGrade);
                    studentGradesContext.SaveChanges();
                    FillGradesTable();
                    FillGradesTableFooter();
                    LabelGradeStatus.Text = "Запись добавлена";
                }
                catch (Exception ex)
                {
                    Response.Write($"Ошибка!<br/>{ex.Message}");
                }
            }
        }

        protected void GridViewGrades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewGrades.EditIndex = e.NewEditIndex;
                FillGradesTable();
                FillGradesTableFooter();
                FillGradesTableEditRow(e.NewEditIndex);
                LabelGradeStatus.Text = "Изменение записи";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewGrades_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewGrades.EditIndex = -1;
                FillGradesTable();
                FillGradesTableFooter();
                LabelGradeStatus.Text = "Изменения отменены";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewGrades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                StudentGrade editStudentGrade = new StudentGrade();
                editStudentGrade = studentGradesContext.StudentGrades.Find(GridViewGrades.DataKeys[e.RowIndex].Value);
                editStudentGrade.GradeDate = DateTime.Parse((GridViewGrades.Rows[e.RowIndex].FindControl("TextBoxGradeDate") as TextBox).Text.Trim());
                editStudentGrade.Student = studentGradesContext.Students.Find(Int32.Parse((GridViewGrades.Rows[e.RowIndex].FindControl("DropDownListName") as DropDownList).SelectedValue));
                editStudentGrade.Course = studentGradesContext.Courses.Find(Int32.Parse((GridViewGrades.Rows[e.RowIndex].FindControl("DropDownListCourseName") as DropDownList).SelectedValue));
                editStudentGrade.Grade = Int32.Parse((GridViewGrades.Rows[e.RowIndex].FindControl("DropDownListGrade") as DropDownList).SelectedItem.Value);
                editStudentGrade.Comment = (GridViewGrades.Rows[e.RowIndex].FindControl("TextBoxComment") as TextBox).Text.Trim();
                studentGradesContext.SaveChanges();
                GridViewGrades.EditIndex = -1;
                FillGradesTable();
                FillGradesTableFooter();
                LabelGradeStatus.Text = "Изменения сохранены";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewGrades_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                currentSortExpression = e.SortExpression;
                FillGradesTable();
                FillGradesTableFooter();
                LabelGradeStatus.Text = $"Таблица отсортирована по параметру {e.SortExpression}";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        protected void GridViewGrades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                StudentGrade delStudentGrade = new StudentGrade();
                delStudentGrade = studentGradesContext.StudentGrades.Find(GridViewGrades.DataKeys[e.RowIndex].Value);
                studentGradesContext.StudentGrades.Remove(delStudentGrade);
                studentGradesContext.SaveChanges();
                GridViewGrades.EditIndex = -1;
                FillGradesTable();
                FillGradesTableFooter();
                LabelGradeStatus.Text = "Запись удалена";
            }
            catch (Exception ex)
            {
                Response.Write($"Ошибка!<br/>{ex.Message}");
            }
        }

        public void FillGradesTable()
        {
            GridViewGrades.DataSource = StudentGradeTableDataModel.GetStudentGradeList(currentSortExpression);
            GridViewGrades.DataBind();
            LabelGradeStatus.Text = "Данные загружены";
        }

        public void FillGradesTableFooter()
        {
            (GridViewGrades.FooterRow.FindControl("DropDownListNameFooter") as DropDownList).DataSource = StudentFullNameDataModel.GetStudentFullNameList("StudentFullName");
            (GridViewGrades.FooterRow.FindControl("DropDownListNameFooter") as DropDownList).DataBind();

            (GridViewGrades.FooterRow.FindControl("DropDownListCourseNameFooter") as DropDownList).DataSource = CourseNameListDataModel.GetCourseNameList("CourseName");
            (GridViewGrades.FooterRow.FindControl("DropDownListCourseNameFooter") as DropDownList).DataBind();

            (GridViewGrades.FooterRow.FindControl("DropDownListGradeFooter") as DropDownList).DataSource = GradingSystemClass.GetGradesListINT();
            (GridViewGrades.FooterRow.FindControl("DropDownListGradeFooter") as DropDownList).DataBind();
        }

        public void FillGradesTableEditRow(int rowIndex)
        {
            (GridViewGrades.Rows[rowIndex].FindControl("DropDownListName") as DropDownList).DataSource = StudentFullNameDataModel.GetStudentFullNameList("StudentFullName");
            (GridViewGrades.Rows[rowIndex].FindControl("DropDownListName") as DropDownList).DataBind();

            (GridViewGrades.Rows[rowIndex].FindControl("DropDownListCourseName") as DropDownList).DataSource = CourseNameListDataModel.GetCourseNameList("CourseName");
            (GridViewGrades.Rows[rowIndex].FindControl("DropDownListCourseName") as DropDownList).DataBind();

            (GridViewGrades.Rows[rowIndex].FindControl("DropDownListGrade") as DropDownList).DataSource = GradingSystemClass.GetGradesListINT();
            (GridViewGrades.Rows[rowIndex].FindControl("DropDownListGrade") as DropDownList).DataBind();
        }
    }
}