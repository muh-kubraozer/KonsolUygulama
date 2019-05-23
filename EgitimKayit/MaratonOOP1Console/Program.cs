using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonOOP1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationSystem screen = new OperationSystem();
            screen.CatchSelected += new ScreenIntHandler(catch_selected);
            screen.GetStringFromUser += new ScreenStringHandler(get_string_from_user);
            screen.PrintMenu += new ScreenPrintHandler(print_menu);
            screen.PrintSentence += new ScreenPrintHandler(print_sentence);

            screen.OpenSystem();
        }
        public static int catch_selected()
        {
            int selected = Int32.Parse(Console.ReadLine());
            return selected;
        }
        private static string get_string_from_user()
        {
            string value = Console.ReadLine();
            return value;
        }
        public static void print_menu(string menu)
        {
            switch (menu)
            {
                case "firstPage":
                    Console.Clear();
                    Console.WriteLine("*********REGISTRATION AUTOMATION**********");
                    Console.WriteLine("     1- Create a new classroom");
                    Console.WriteLine("     2- Create a new class");
                    Console.WriteLine("     3- Choose existing class");
                    break;
                case "selectLesson":
                    Console.Clear();
                    Console.WriteLine("************LESSONS***********");
                    Console.WriteLine("     1- Software Development");
                    Console.WriteLine("     2- Graphic Design");
                    Console.WriteLine("     3- Database Administration");
                    break;
                case "classOperationMenu":
                    Console.Clear();
                    Console.WriteLine("************CLASS' MENU***********");
                    Console.WriteLine("     1- Add new student");
                    Console.WriteLine("     2- Remove exist student");
                    Console.WriteLine("     3- Give Classroom");
                    Console.WriteLine("     4- Start Course");
                    break;
            }

        }
        private static void print_sentence(string sentence)
        {
            Console.WriteLine(sentence);
        }
    }
}
