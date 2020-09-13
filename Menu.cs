using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB11_ProjectA_PartB.Entities;

namespace CB11_ProjectA_PartB
{
    class Menu
    {

        public static void Init() {

            
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
                    do
                    {
                        ThirdTier(firstTierChoice, secondTierChoice, out back);
                    } while (back == 0);
                } while (exit == 2);

            } while (exit == 2);

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
                exit = Helper.VerifyExitValidate();
        }

        private static void ThirdTier(int firstTierChoice, int secondTierChoice, out int back)
        {
            if (firstTierChoice == 1) // 1 = Add Data
                SecondTierAction_Add(secondTierChoice, out back);
            else if (firstTierChoice == 2) // 2 = Show Data
                SecondTierAction_Show(secondTierChoice, out back);
            else  // 3 = Assign Data
                SecondTierAction_Assign(secondTierChoice, out back);
        }

        private static void SecondTierAction_Add(int secondTierChoice, out int back)
        {
            Manager manager = new Manager(); // to initialize manager class which includes database management
            back = 0; // default value to make the loop of the tier again, true for all the choises except the last one
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
                back = 1;
        }

        private static void SecondTierAction_Show(int secondTierChoice, out int back)
        {
            Manager manager = new Manager(); // to initialize manager class which includes database management
            back = 0;
            if (secondTierChoice == 1)
            {

            }
            else if (secondTierChoice == 2)
            {

            }
            else if (secondTierChoice == 3)
            {

            }
            else if (secondTierChoice == 4)
            {

            }
            else if (secondTierChoice == 5)
            {

            }
            else if (secondTierChoice == 6)
            {

            }
            else if (secondTierChoice == 7)
            {

            }
            else if (secondTierChoice == 8)
            {

            }
            else if (secondTierChoice == 9)
            {

            }
            else if (secondTierChoice == 10)
            {

            }
            else if (secondTierChoice == 11)
            {

            }
            else
                back = 1;
        }

        private static void SecondTierAction_Assign(int secondTierChoice, out int back)
        {
            Manager manager = new Manager(); // to initialize manager class which includes database management
            back = 0;
            if (secondTierChoice == 1)
            {

            }
            else if (secondTierChoice == 2)
            {

            }
            else if (secondTierChoice == 3)
            {

            }
            else if (secondTierChoice == 4)
            {

            }
            else
                back = 1;
        }

    }
}
