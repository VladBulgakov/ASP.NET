using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradesDAL;

namespace TestApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            var query = from studGrade in studentGradesContext.StudentGrades
                        join stud in studentGradesContext.Students on studGrade.Student.StudentId equals stud.StudentId
                        join course in studentGradesContext.Courses on studGrade.Course.CourseId equals course.CourseId
                        group studGrade by studGrade.Student into studGroup
                        select studGroup;
            //var queryList = query.ToList();
            foreach (var gr in query)
            {
                double res = gr.Average(a => a.Grade);
                StudentGrade thisGrade = gr.FirstOrDefault();
                Student std = thisGrade.Student;
                Console.WriteLine($"{std.LastName} Оценка:{res}");
            }

            Console.ReadKey();
        }
    }
}
