using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        public string StudentNumber;
        public string Classroom;
        private decimal _examGrade1;
        private decimal _examGrade2;
        private decimal _examGrade3;
        private decimal _gradeAverage;
        private bool _isGraduared;

        public decimal ExamGrade1
        {
            get { return _examGrade1; }
            set
            {
                if (value >= 0 && value <= 100)
                    _examGrade1 = value;
            }
        }
        public decimal ExamGrade2
        {
            get { return _examGrade2; }
            set
            {
                if (value >= 0 && value <= 100)
                    _examGrade2 = value;
            }
        }
        public decimal ExamGrade3
        {
            get { return _examGrade3; }
            set
            {
                if (value >= 0 && value <= 100)
                    _examGrade3 = value;
            }
        }
        public decimal GradeAverage
        {
            get { return (ExamGrade1 * 30) / 100 + (ExamGrade2 * 30) / 100 + (ExamGrade3 * 40) / 100; }
            private set
            {
                _gradeAverage = value;
            }
        }
        public bool IsGraduated
        {
            get { return (ExamGrade3 >= 30 && GradeAverage >= 50) ? true : false; }
            private set
            {
                _isGraduared = value;
            }
        }

    }
}
