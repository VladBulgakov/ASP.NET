using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesDAL
{
    public class StudentGrade
    {
        public int StudentGradeId { get; set; }
        public DateTime? GradeDate { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        //Отношение 1 к многим - оценка относится к одному студенту и курсу, но студент может иметь несколько оценок, и один курс может иметь несколько оценок от разных студентов
        [Required]
        public Student Student { get; set; }
        [Required]
        public Course Course { get; set; }

        public StudentGrade() { }
    }
}
