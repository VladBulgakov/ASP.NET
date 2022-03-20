using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StudentGradesDAL
{
    public class CourseNameListDataModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public CourseNameListDataModel()
        { }

        public static List<CourseNameListDataModel> GetCourseNameList(string sortExpression)
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            var query = from course in studentGradesContext.Courses
                        select new
                        {
                            CourseId = course.CourseId,
                            CourseName = course.CourseName
                        };
            var queryList = query.SortBy(sortExpression).ToList();
            List<CourseNameListDataModel> courseList = new List<CourseNameListDataModel>();
            foreach (var a in queryList)
            {
                CourseNameListDataModel courseNameListDataModel = new CourseNameListDataModel();
                courseNameListDataModel.CourseId = a.CourseId;
                courseNameListDataModel.CourseName = a.CourseName;
                courseList.Add(courseNameListDataModel);
            }
            return courseList;
        }
    }
}
