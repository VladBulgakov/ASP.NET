using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradesDAL;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentGradesContext studentGradesContext = new StudentGradesContext();
            List<int> gradesList = GradingSystemClass.GetGradesListINT();

            //Таблица с оценками
            try
            {
                var gradeListQuery = from stud in studentGradesContext.Students
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
                var gradeList = gradeListQuery.ToList();
                foreach (var rec in gradeList)
                {
                    Console.WriteLine($"{rec.StudentGradeId} {rec.GradeDate} {rec.StudentFullName} {rec.CourseName} {rec.Grade} {rec.Comment}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            //Список полных имен
            try
            {
                var nameQuery = from stud in studentGradesContext.Students
                                select new
                                {
                                    StudentId = stud.StudentId,
                                    StudentFullName = stud.LastName + " " + stud.FirstName + " " + stud.Patronymic,
                                };
                var nameList = nameQuery.ToList();
                foreach (var rec in nameList)
                {
                    Console.WriteLine($"{rec.StudentId} {rec.StudentFullName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.ReadKey();
        }

        static void InitDB()
        {
            Student student1 = new Student();
            student1.FirstName = "Влад";
            student1.LastName = "Булгаков";
            student1.Patronymic = "Сергеевич";
            student1.BirthDate = DateTime.Today;
            Student student2 = new Student();
            student2.FirstName = "Сергей";
            student2.LastName = "Дубов";
            student2.Patronymic = "Андреевич";
            student2.BirthDate = DateTime.Today;
            Course course1 = new Course();
            course1.CourseName = "Математика";
            course1.CourseDescription = "Курс по математике";
            course1.CourseTime = 10;
            Course course2 = new Course();
            course2.CourseName = "Русский язык";
            course2.CourseDescription = "Курс русского языка";
            course2.CourseTime = 20;

            StudentGrade sg1 = new StudentGrade();
            sg1.Student = student1;
            sg1.Course = course1;
            sg1.Grade = 5;
            sg1.GradeDate = DateTime.Today;
            StudentGrade sg2 = new StudentGrade();
            sg2.Student = student1;
            sg2.Course = course1;
            sg2.Grade = 4;
            sg2.GradeDate = DateTime.Today;
            StudentGrade sg3 = new StudentGrade();
            sg3.Student = student1;
            sg3.Course = course2;
            sg3.Grade = 3;
            sg3.GradeDate = DateTime.Today;

            /*try
            {
                StudentGradesContext context = new StudentGradesContext();
                context.Students.Add(student1);
                context.Students.Add(student2);
                context.Courses.Add(course1);
                context.Courses.Add(course2);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!\n" + ex.Message);
            }*/
            StudentGradesContext context = new StudentGradesContext();
            context.Students.Add(student1);
            context.Students.Add(student2);
            context.Courses.Add(course1);
            context.Courses.Add(course2);
            context.StudentGrades.Add(sg1);
            context.StudentGrades.Add(sg2);
            context.StudentGrades.Add(sg3);
            context.SaveChanges();
            Console.WriteLine("Inited");
            Console.ReadKey();
        }
    }
}
