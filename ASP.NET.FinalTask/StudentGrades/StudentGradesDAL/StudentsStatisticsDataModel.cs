using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StudentGradesDAL
{
    public class StudentsStatisticsDataModel
    {
        public int StudentId { get; set; }
        public string StudentFullName { get; set; }
        public double StudentAverageGrade { get; set; }

        public StudentsStatisticsDataModel()
        { }

        public static List<StudentsStatisticsDataModel> GetBestFiveStudentList()
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            var query = from studGrade in studentGradesContext.StudentGrades
                        group studGrade by studGrade.Student into gradeGroup
                        orderby gradeGroup.Average(a => a.Grade) descending
                        select gradeGroup;
            var queryList = query.ToList().Take(5);
            List<StudentsStatisticsDataModel> bestList = new List<StudentsStatisticsDataModel>();
            foreach (var gradeGroup in queryList)
            {
                StudentsStatisticsDataModel currentStudent = new StudentsStatisticsDataModel();
                currentStudent.StudentAverageGrade = Math.Round(gradeGroup.Average(a => a.Grade),3);
                Student thisStudent = gradeGroup.FirstOrDefault().Student;
                currentStudent.StudentFullName = thisStudent.LastName + " " + thisStudent.FirstName + " " + thisStudent.Patronymic;
                currentStudent.StudentId = thisStudent.StudentId;
                bestList.Add(currentStudent);
            }
            return bestList;
        }

        public static List<StudentsStatisticsDataModel> GetWorstFiveStudentList()
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            var query = from studGrade in studentGradesContext.StudentGrades
                        group studGrade by studGrade.Student into gradeGroup
                        orderby gradeGroup.Average(a => a.Grade) ascending
                        select gradeGroup;
            var queryList = query.ToList().Take(5);
            List<StudentsStatisticsDataModel> worstList = new List<StudentsStatisticsDataModel>();
            foreach (var gradeGroup in queryList)
            {
                StudentsStatisticsDataModel currentStudent = new StudentsStatisticsDataModel();
                currentStudent.StudentAverageGrade = Math.Round(gradeGroup.Average(a => a.Grade),3);
                Student thisStudent = gradeGroup.FirstOrDefault().Student;
                currentStudent.StudentFullName = thisStudent.LastName + " " + thisStudent.FirstName + " " + thisStudent.Patronymic;
                currentStudent.StudentId = thisStudent.StudentId;
                worstList.Add(currentStudent);
            }
            return worstList;
        }
    }
}
