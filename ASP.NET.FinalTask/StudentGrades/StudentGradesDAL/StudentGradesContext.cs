using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentGradesDAL
{
    public class StudentGradesContext:DbContext
    {
        public StudentGradesContext() : base("name = StudentGradesDB")
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
    }
}
