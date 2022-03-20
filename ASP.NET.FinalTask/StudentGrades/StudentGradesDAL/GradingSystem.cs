using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesDAL
{
    public enum GradingSystem
    {
        VeryGood = 5,
        Good = 4,
        Satisfactorily = 3,
        Bad = 2
    }

    public static class GradingSystemClass
    {
        public static List<int> GetGradesListINT()
        {
            List<int> grades = Enum.GetValues(typeof(GradingSystem))
                            .Cast<int>()
                            .ToList();
            return grades;
        }

        public static List<GradingSystem> GetGradesListGS()
        {
            List<GradingSystem> grades = Enum.GetValues(typeof(GradingSystem))
                            .Cast<GradingSystem>()
                            .ToList();
            return grades;
        }
    }
}
