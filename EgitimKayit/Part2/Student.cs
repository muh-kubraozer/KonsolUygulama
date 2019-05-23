using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    public class Student
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _studentNumber;
        private string _classroom;
        private int _gradeAverage;
        private bool _isGraduated;

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }
        public string StudentNumber { get { return _studentNumber; } set { _studentNumber = value; } }
        public string Classroom { get { return _classroom; } set { _classroom = value; } }
        public int GradeAverage { get { return _gradeAverage; } set { _gradeAverage = value; } }
        public bool IsGraduated { get { return _isGraduated; } set { _isGraduated = value; } }

    }
}
