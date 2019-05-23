using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part4;
using Part6;

namespace MaratonOOP1Console
{
    public delegate int ScreenIntHandler ();
    public delegate string ScreenStringHandler();
    public delegate void ScreenPrintHandler(string menu);
    
    class OperationSystem
    {
        public event ScreenIntHandler CatchSelected;
        public event ScreenStringHandler GetStringFromUser;
        public event ScreenPrintHandler PrintMenu;
        public event ScreenPrintHandler PrintSentence;
        

        public Classroom[] classrooms;
        public Class[] classes;

        public void AddClassroom(Classroom newclassroom)
        {
            if (classrooms == null)
            {
                classrooms = new Classroom[1];
                classrooms[0] = newclassroom;
            }
            else
            {
                
                if (!IsClassroomExist(newclassroom.code))
                {
                    Array.Resize<Classroom>(ref classrooms, classrooms.Length + 1);
                    classrooms[classrooms.Length - 1] = newclassroom;
                }
            }
        }
        public void AddClass(Class newclass)
        {
            if (classes == null)
            {
                classes = new Class[1];
                classes[0] = newclass;
            }
            else
            {
                bool exist = false;
                foreach (var item in classes)
                {
                    if (newclass.code == item.code)
                    {
                        exist = true;
                    }
                }
                if (exist == false)
                {
                    Array.Resize<Class>(ref classes, classes.Length + 1);
                    classes[classes.Length] = newclass;
                }
            }
        }


        public void OpenSystem()
        {
            PrintMenu("firstPage");
            GoSelectedOperation(CatchSelected());

        }
        private void GoSelectedOperation(int selected)
        {
            switch (selected)
            {
                case 1:
                    PrintMenu("selectLesson");
                    Lesson lesson = SelectLesson(CatchSelected());
                    CreateClassroom(lesson);
                    OpenSystem();
                    break;
                case 2:
                    PrintMenu("selectLesson");
                    lesson = SelectLesson(CatchSelected());
                    CreateClass(lesson);
                    OpenSystem();
                    break;
                case 3:
                    ShowClasses();
                    Class selectedClass = classes[CatchSelected() - 1];
                    PrintMenu("classOperationMenu");
                    GoSelectedClassOperation(CatchSelected(),selectedClass);
                    break;
            }
        }
        private Lesson SelectLesson(int selected)
        {
            Lesson lesson = (selected == (int)Lesson.SoftwareDevelopment)
                ? Lesson.SoftwareDevelopment : (selected == (int)Lesson.GraphicDesign)
                ? Lesson.GraphicDesign : Lesson.DatabaseAdministration;
            return lesson;
        }
        private void CreateClassroom(Lesson lesson)
        {
            int minCapacity = (lesson == Lesson.SoftwareDevelopment)
                ? 15 : (lesson == Lesson.GraphicDesign)
                ? 5 : (lesson == Lesson.DatabaseAdministration)
                ? 10 : 0;
            PrintSentence("Please enter classroom's name: ");
            string code = GetStringFromUser();
            PrintSentence("Please enter classroom's floor: ");
            int floor = CatchSelected();
            PrintSentence("Please enter classroom's capacity: ");
            int capacity = CatchSelected();

            
            if (minCapacity <= capacity && !IsClassroomExist(code))
            {
                Classroom classroom = new Classroom(code, capacity, floor);
                AddClassroom(classroom);

                PrintSentence(" Name:" + classroom.code + "\n Floor:" + classroom.Floor + "\n Capacity:" + classroom.Capacity);
                PrintSentence("Classroom is created.");
            }
            else
            {
                PrintSentence("Classroom couldn't created.");
            }
            GetStringFromUser();//Ekranı bekletmek için kullanıldı.
        }
        private void CreateClass(Lesson lesson)
        {
            Class newClass = new Class(lesson);
            AddClass(newClass);

            PrintSentence("Class' name:" + newClass.code);
            PrintSentence("Class' student amount:" + newClass.StudentsCount);
            PrintSentence("Is class ready to start:" + newClass.ReadyToStart);
            PrintSentence("Class' classroom:" + newClass.Classroom);
            GetStringFromUser();//Ekranı bekletmek için kullanıldı.
        }
        private void ShowClasses()
        {
            PrintSentence("************EXISTING CLASSES*************");
            foreach (var item in classes)
            {
                PrintSentence("- " + item.code + "\n Lesson:" + item.Lesson + "\n Classroom:" + item.Classroom + "\n Student Count:" + item.StudentsCount + "\n Ready to start:" + item.ReadyToStart);
                if (item.StartDate != DateTime.MinValue)
                   PrintSentence("\n StartDate: " + item.StartDate + "\n EndDate: " + item.EndDate + "\n");

            }
        }
        private bool IsClassroomExist(string code)
        {
            bool exist = false;
            if (classrooms != null)
            {
                foreach (var item in classrooms)
                {
                    if (code == item.code)
                        exist = true;
                }
            }
            return exist;
        }
        private void GoSelectedClassOperation(int operation,Class selectedClass)
        {
            switch (operation)
            {
                case 1:
                    CreateStudent(selectedClass);
                    OpenSystem();
                    break;
                case 2:
                    ShowStudents(selectedClass);
                    selectedClass.RemoveStudent(selectedClass.students[CatchSelected() - 1]);
                    OpenSystem();
                    break;
                case 3:
                    ShowClassrooms();
                    int selected = CatchSelected();
                    selectedClass.Classroom = (selectedClass.minCapacity <= classrooms[selected - 1].Capacity)
                        ? classrooms[selected - 1]
                        : null;
                    if (selectedClass.Classroom == null)
                        PrintSentence("Classroom's capacity is less than necessary.");
                    OpenSystem();
                    break;
                case 4:
                    string message = (selectedClass.ReadyToStart)
                        ? ("Course is started. End date is on " + selectedClass.EndDate.ToString())
                        : ("Class's capacity is not enough.");
                    selectedClass.StartClass();
                    PrintSentence(message);
                    GetStringFromUser();//Ekranı bekletmek için kullanıldı.
                    OpenSystem();
                    break;
            }
        }
        private void CreateStudent(Class selectedClass)
        {
            Student newstudent = new Student();

            PrintSentence("Firstname:");
            newstudent.FirstName = GetStringFromUser();
            PrintSentence("Lastname:");
            newstudent.LastName = GetStringFromUser();
            PrintSentence("DateOfBirth:");
            newstudent.DateOfBirth = GetStringFromUser();
            PrintSentence("Student number:");
            newstudent.StudentNumber = GetStringFromUser();

            selectedClass.AddStudent(newstudent);
            PrintSentence("Student added.");
            GetStringFromUser();//Ekranı bekletmek için kullanıldı.
        }
        private void ShowStudents(Class selectedClass)
        {
            foreach (var item in selectedClass.students)
            {
                PrintSentence(item.StudentNumber + " " + item.FirstName + " " + item.LastName);
            }
        }
        private void ShowClassrooms()
        {
            foreach (var item in classrooms)
            {
                PrintSentence(item.code + "capacity: " + item.Capacity);
            }
        }
    }
}
