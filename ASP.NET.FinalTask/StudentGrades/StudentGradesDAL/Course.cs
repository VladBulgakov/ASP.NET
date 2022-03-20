using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesDAL
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int? CourseTime { get; set; }

        public virtual List<StudentGrade> StudentGrades { get; set; }

        public Course() 
        {
            StudentGrades = new List<StudentGrade>();
        }
    }
}
