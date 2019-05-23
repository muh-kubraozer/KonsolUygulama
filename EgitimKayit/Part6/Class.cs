using Part4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part6
{
    public class Class
    {
        public Lesson Lesson { get; }
        public string code { get; private set; }
        public Classroom Classroom;
        public Student Student;
        public bool ReadyToStart { get { return (this.Classroom != null && this.StudentsCount >= this.Classroom.Capacity*70/100) ? true : false;} }
        public int minCapacity;

        public Student[] students;
        private int _studentsCount;
        public int StudentsCount
        {
            get { return _studentsCount; }
            private set { _studentsCount = value; }
        }

        //Properties for Part6_ConsoleApp project.
        public DateTime StartDate { get; private set; }
        private DateTime _endDate;
        public DateTime EndDate { get { return StartDate.AddDays(30); } private set { _endDate = value; } }
        
        public Class(Lesson lesson)
        {
            this.Lesson = lesson;
            this.code = CreateCode();
            Student[] students = new Student[0];
            StudentsCount = 0;
        }

        //Methods for Part6_ConsoleApp project.
        public void StartClass()
        {
            if (ReadyToStart)
            {
                StartDate = DateTime.Today;
            }
        }
        public void TerminateClass()
        {
            EndDate = DateTime.Today;
        }

        public void AddStudent(Student newStudent)
        {
            bool exist = false;
            if (students == null)
            {
                students = new Student[1];
                students[0] = newStudent;
                StudentsCount++;
            }
            else if (StudentsCount < Classroom.Capacity)
            {
                foreach (var item in students)//Is newStudents already exist?
                {
                    if (newStudent.StudentNumber == item.StudentNumber)
                        exist = true;
                }
                if (!exist)
                {
                    Student[] tempstudents = students;
                    Array.Resize<Student>(ref students, students.Length + 1);
                    students = tempstudents;
                    students[students.Length - 1] = newStudent;
                    StudentsCount++;
                }
                
            }
        }
        public void RemoveStudent(Student student)
        {
            if(students != null)
            {
                int index = -1;
                Student[] tempstudents = students;
                Array.Resize<Student>(ref students, students.Length - 1);
                for (int i=0; i< students.Length;i++)
                {
                    if (student.StudentNumber == students[i].StudentNumber)
                    {
                        index = i;

                    }
                    if (index == -1)
                    {
                        students[i] = tempstudents[i];
                    }
                    else if (index != -1)
                    {
                        students[i] = tempstudents[i + 1];
                    }
                    
                }
                StudentsCount--;
            }
        }
        private string CreateCode()
        {
            string lessonCode = "";
            if (Lesson == Lesson.SoftwareDevelopment)
            {
                minCapacity = 15;
                lessonCode = "sd";
            }
            else if (Lesson == Lesson.GraphicDesign)
            {
                minCapacity = 5;
                lessonCode = "gd";
            }
            else if (Lesson == Lesson.DatabaseAdministration)
            {
                minCapacity = 10;
                lessonCode = "da";
            }

            Random rnd = new Random();
            int numberCode = rnd.Next(100000, 999999);

            return string.Format("{0}{1}",lessonCode, numberCode);
        }
    } 
}
