using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public string DateOfBirth;
        public string StudentNumber;
        private decimal _gradeAverage;
        private bool _isGraduared;
        private Decimal[] Exams;
        private decimal grade = 0;

        public void AddExamGrade(decimal examGrade)
        {
            if (Exams == null)
            {
                Exams = new decimal[1];
                Exams[0] =examGrade;
            }
            else if (Exams.Length >= 10 && _gradeAverage > 70)
            {
                throw new Exception("Student has already graduated!");
            }
            else
            {
                Array.Resize<Decimal>(ref Exams, Exams.Length + 1);
                Exams[Exams.Length - 1] = examGrade;
            }

            grade += examGrade;
            _gradeAverage = grade / (Exams.Length);
        }

        public decimal GradeAverage
        {
            get { return _gradeAverage; }
            private set
            {
                _gradeAverage = value;
            }
        }
        public bool IsGraduated
        {
            get { return (Exams.Length >= 10 && _gradeAverage > 70) ? true : false; }
            private set
            {
                _isGraduared = value;
            }
        }

    }
}
