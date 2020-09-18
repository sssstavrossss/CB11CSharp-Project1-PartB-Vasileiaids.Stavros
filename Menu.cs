using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB11_ProjectA_PartB.Entities;

namespace CB11_ProjectA_PartB
{
    class Menu
    {

        public static void Init() {
            Database db = new Database(); // initializing database entity
            int firstTierChoice; // first tier menu input choice
            int secondTierChoice; // second tier menu input choice
            int exit; // variable to determine if user wants to exit
            int back = 1; // variable to determine if user wants to move to lower tier menu
            Helper.Intro();
            do
            {
                firstTierChoice = Helper.MainMenu();

                do
                {
                    SecondTier(firstTierChoice, out secondTierChoice, out exit);
                    ThirdTier(firstTierChoice, secondTierChoice, out back, db);
                } while (back == 1);
            } while (exit == 2);
            Console.WriteLine("Bye bye!");
            Console.WriteLine();
        }

        private static void SecondTier(int firstTierChoice, out int secondTierChoice, out int exit)
        {
            secondTierChoice = 5; // just a value because otherwise it gived me error :(
            exit = 2; //default value so that loop will happen again if user picks to stay

            if (firstTierChoice == 1) // 1 = Add Data
                secondTierChoice = Helper.AddMenu();
            else if (firstTierChoice == 2) // 2 = Show Data
                secondTierChoice = Helper.ShowMenu();
            else if (firstTierChoice == 3) // 3 = Assign Data
                secondTierChoice = Helper.AssignMenu();
            else if (firstTierChoice == 4) // 4 = Exit
                exit = Helper.VerifyExit();
        }

        private static void ThirdTier(int firstTierChoice, int secondTierChoice, out int back, Database db)
        {
            if (firstTierChoice == 1) // 1 = Add Data
                SecondTierAction_Add(secondTierChoice, out back);
            else if (firstTierChoice == 2) // 2 = Show Data
                SecondTierAction_Show(secondTierChoice, out back, db);
            else  // 3 = Assign Data
                SecondTierAction_Assign(secondTierChoice, out back, db);
        }

        private static void SecondTierAction_Add(int secondTierChoice, out int back)
        {
            Manager manager = new Manager(); // to initialize manager class which includes database inserts
            back = 1; // default value to make the loop of the tier again, true for all the choises except the last one
            if (secondTierChoice == 1) // Add Course
            {
                Courses cr = new Courses(); // to initialize and create an entity, then pass it to manager to insert it to db
                cr.CreateCourse();
                manager.AddCourse(cr);
            }
            else if (secondTierChoice == 2) // Add Student
            {
                Students st = new Students();
                st.CreateStudent();
                manager.AddStudent(st);
            }
            else if (secondTierChoice == 3) // Add Trainer
            {
                Trainers tr = new Trainers();
                tr.CreateTrainer();
                manager.AddTrainer(tr);
            }
            else if (secondTierChoice == 4) // Add Assignment
            {
                Assignments ag = new Assignments();
                ag.CreateAssignment();
                manager.AddAssignment(ag);
            }
            else
                back = 0;
        }

        private static void SecondTierAction_Show(int secondTierChoice, out int back, Database db)
        {
            back = 1;
            if (secondTierChoice == 1) // Show Courses
                db.ShowCourses();
            else if (secondTierChoice == 2) // Show Students
                db.ShowStudents();
            else if (secondTierChoice == 3) // Show Trainers
                db.ShowTrainers();
            else if (secondTierChoice == 4) // Show Assignments
                db.ShowAssignments();
            else if (secondTierChoice == 5) // Show Students Per Course
                db.ShowStudentsPerCourse();
            else if (secondTierChoice == 6) // Show Trainers per Course
                db.ShowTrainersPerCourse();
            else if (secondTierChoice == 7) // Show Students > 1 Courses
                db.ShowStudentPerManyCourses();
            else if (secondTierChoice == 8) // Show Assignments per Course
                db.ShowAssignmentsPerCourse();
            else if (secondTierChoice == 9) // Show Assignments per Student
                db.ShowAssignmentsPerStudent();
            else if (secondTierChoice == 10) // Show Assignments Per Course Per Student
                db.ShowAssignmentsPerCoursePerStudent();
            else if (secondTierChoice == 11)
            { // Show Student Submit
                DateTime date = Helper.GetDate("the date you want to check:");
                db.ShowStudentSubmit(date);
            }
            else
                back = 0;
        }

        private static void SecondTierAction_Assign(int secondTierChoice, out int back, Database db)
        {
            Manager manager = new Manager(); // to initialize manager class which includes database inserts
            back = 1;
            if (secondTierChoice == 1) // 1. Assign Student to Course
                manager.AddStudentsToCourses(db);
            else if (secondTierChoice == 2) // 2. Assign Trainer to Course
                manager.AddTrainersToCourses(db);
            else if (secondTierChoice == 3) // 3. Assign Assignment to Course
                manager.AddAssignmentsToCourses(db);
            else if (secondTierChoice == 4) // 4. Assign Assignment to Student
                manager.AddAssignmentsToStudents(db);
            else
                back = 0;
        }

    }
}
