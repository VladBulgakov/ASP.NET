using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StudentGradesDAL
{
    public class StudentGradeTableDataModel
    {
        public int StudentGradeId { get; set; }
        public DateTime? GradeDate { get; set; }
        public string StudentFullName { get; set; }
        public string CourseName { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }

        public StudentGradeTableDataModel()
        { }

        public static List<StudentGradeTableDataModel> GetStudentGradeList(string sortExpression)
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            var query = from stud in studentGradesContext.Students
                        join studGrade in studentGradesContext.StudentGrades on stud.StudentId equals studGrade.Student.StudentId
                        join course in studentGradesContext.Courses on studGrade.Course.CourseId equals course.CourseId
                        select new
                        {
                            StudentGradeId = studGrade.StudentGradeId,
                            GradeDate = studGrade.GradeDate,
                            StudentFullName = stud.LastName + " " + stud.FirstName + " " + stud.Patronymic,
                            CourseName = course.CourseName,
                            Grade = studGrade.Grade,
                            Comment = studGrade.Comment
                        };
            var queryList = query.SortBy(sortExpression).ToList();
            List<StudentGradeTableDataModel> gradeList = new List<StudentGradeTableDataModel>();
            foreach (var a in queryList)
            {
                StudentGradeTableDataModel studentGradeTableDataModel = new StudentGradeTableDataModel();
                studentGradeTableDataModel.StudentGradeId = a.StudentGradeId;
                studentGradeTableDataModel.GradeDate = a.GradeDate;
                studentGradeTableDataModel.StudentFullName = a.StudentFullName;
                studentGradeTableDataModel.CourseName = a.CourseName;
                studentGradeTableDataModel.Grade = a.Grade;
                studentGradeTableDataModel.Comment = a.Comment;
                gradeList.Add(studentGradeTableDataModel);
            }
            return gradeList;
        }
    }
}
