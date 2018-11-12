using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            // Get number of students that is 20 %
            var threshold = (int)Math.Ceiling(Students.Count * 0.20);


            var grades = Students.OrderByDescending(student => student.AverageGrade).Select(student => student.AverageGrade).ToList();

            if(grades[threshold-1] <= averageGrade)
            {
                return base.GetLetterGrade(averageGrade)
            }
            else if (grades[(threshold*2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(threshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(threshold * 4) - 1] <= averageGrade)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
