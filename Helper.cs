using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB11_ProjectA_PartB
{
    class Helper
    {
        public static void Intro()
        {
            Console.WriteLine("Welcome to the project!");
            Console.WriteLine("for each option of the menu you will need to input the right number");
            Console.WriteLine("use latin alphabet for string, date format like this '01-01-2020'");
            Console.WriteLine();
        }

        public static int MainMenu()
        {
            Console.WriteLine("Actions:");
            Console.WriteLine("1. Add Data:");
            Console.WriteLine("2. Show Data:");
            Console.WriteLine("3. Assign Data:");
            Console.WriteLine("4. Exit App:");
            return MainMenuValidate();
        }

        public static int MainMenuValidate()
        {
            int x;
            string rd;
            do
            {
                Console.WriteLine("Type your number of choice.");
                rd = Console.ReadLine();
            } while (!int.TryParse(rd, out x) && x != 1 && x != 2 && x != 3 && x != 4);
            Console.WriteLine();
            return x;
        }

        public static int AddMenu()
        {
            Console.WriteLine("Actions:");
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Add Trainer");
            Console.WriteLine("4. Add Assignment");
            Console.WriteLine("5. Back to Main Menu");
            return Add_Assign_MenuValidate();
        }

        public static int Add_Assign_MenuValidate()
        {
            int x;
            string rd;
            do
            {
                Console.WriteLine("Type your number of choice.");
                rd = Console.ReadLine();
            } while (!int.TryParse(rd, out x) && x < 1 && x > 5);
            Console.WriteLine();
            return x;
        }

        public static int ShowMenu()
        {
            Console.WriteLine("Actions:");
            Console.WriteLine("1. Show Courses");
            Console.WriteLine("2. Show Students");
            Console.WriteLine("3. Show Trainers");
            Console.WriteLine("4. Show Assignments");
            Console.WriteLine("5. Show Students per Course");
            Console.WriteLine("6. Show Trainers Per Course");
            Console.WriteLine("7. Show Students assigned to more than one Course");
            Console.WriteLine("8. Show Assignments per Course");
            Console.WriteLine("9. Show Assignments per Student");
            Console.WriteLine("10. Show Assignments per Course per Student");
            Console.WriteLine("11. Show Student that need to submit an Assignment according to the input date");
            Console.WriteLine("12. Back to Main Menu");
            return ShowMenuValidate();
        }

        public static int ShowMenuValidate()
        {
            int x;
            string rd;
            do
            {
                Console.WriteLine("Type your number of choice.");
                rd = Console.ReadLine();
            } while (!int.TryParse(rd, out x) && x < 1 && x > 12);
            Console.WriteLine();
            return x;
        }

        public static int AssignMenu()
        {
            Console.WriteLine("Actions:");
            Console.WriteLine("1. Assign Student to Course");
            Console.WriteLine("2. Assign Trainer to Course");
            Console.WriteLine("3. Assign Assignment to Course");
            Console.WriteLine("4. Assign Assignment to Student");
            Console.WriteLine("5. Back to Main Menu");
            return Add_Assign_MenuValidate();
        }

        public static int VerifyExit()
        {
            Console.WriteLine("Are you sure you want to exit the app?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            return VerifyExitValidate();
        }

        public static int VerifyExitValidate()
        {
            int x;
            string rd;
            do
            {
                Console.WriteLine("Type your number of choice.");
                rd = Console.ReadLine();
            } while (!int.TryParse(rd, out x) && x != 1 && x != 2);
            Console.WriteLine();
            return x;
        }

        public static string GetString(string message)
        {
            string str;
            bool flag;
            do
            {
                Console.WriteLine($"Please type: {message}");
                str = Console.ReadLine().Trim();
                flag = (str != "" || str != " " || str.Count() > 50);
            } while (!flag);
            return str;
        }

        public static DateTime GetDate(string message)
        {
            string str;
            DateTime date;
            do
            {
                Console.WriteLine($"please type {message}");
                str = Console.ReadLine();
            } while (!DateTime.TryParse(str, out date));
            return date;

        }

    }
}
