using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StudentGradesDAL
{
    public class StudentFullNameDataModel
    {
        public int StudentId { get; set; }
        public string StudentFullName { get; set; }

        public StudentFullNameDataModel()
        { }

        public static List<StudentFullNameDataModel> GetStudentFullNameList(string sortExpression)
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            var query = from student in studentGradesContext.Students
                            select new
                            {
                                StudentId = student.StudentId,
                                StudentFullName = student.LastName + " " + student.FirstName + " " + student.Patronymic
                            };
            var queryList = query.SortBy(sortExpression).ToList();
            List<StudentFullNameDataModel> nameList = new List<StudentFullNameDataModel>();
            foreach (var a in queryList)
            {
                StudentFullNameDataModel studentFullNameDataModel = new StudentFullNameDataModel();
                studentFullNameDataModel.StudentId = a.StudentId;
                studentFullNameDataModel.StudentFullName = a.StudentFullName;
                nameList.Add(studentFullNameDataModel);
            }
            return nameList;
        }
    }
}
