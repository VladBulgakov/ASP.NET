using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StudentGradesDAL
{
    public class StudentGradeSummaryDataModel
    {
        public int StudentId { get; set; }
        public string StudentFullName { get; set; }
        public int StudentGradeSumm { get; set; }
        public double StudentAverageGrade { get; set; }

        public StudentGradeSummaryDataModel()
        { }

        public static List<StudentGradeSummaryDataModel> GetStudentGradeSummaryList(Course requiredCourse, string sortExpression)
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            var query = from studGrade in studentGradesContext.StudentGrades
                        where studGrade.Course.CourseId == requiredCourse.CourseId
                        group studGrade by studGrade.Student into gradeGroup
                        select gradeGroup;
            var queryList = query.ToList();
            List<StudentGradeSummaryDataModel> gradeSummaryList = new List<StudentGradeSummaryDataModel>();
            foreach (var gradeGroup in queryList)
            {
                StudentGradeSummaryDataModel currentStudent = new StudentGradeSummaryDataModel();
                currentStudent.StudentGradeSumm = gradeGroup.Sum(a => a.Grade);
                currentStudent.StudentAverageGrade = Math.Round(gradeGroup.Average(a => a.Grade), 3);
                Student thisStudent = gradeGroup.FirstOrDefault().Student;
                currentStudent.StudentFullName = thisStudent.LastName + " " + thisStudent.FirstName + " " + thisStudent.Patronymic;
                currentStudent.StudentId = thisStudent.StudentId;
                gradeSummaryList.Add(currentStudent);
            }
            var gradeSummaryListSorted = gradeSummaryList.AsQueryable().SortBy(sortExpression).ToList();
            return gradeSummaryListSorted;
        }
    }
}
