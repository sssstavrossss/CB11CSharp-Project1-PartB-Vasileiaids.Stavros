using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB11_ProjectA_PartB
{
    class Menu
    {

        public static void Init() {

            int choice;
            int exit = 2;

            Helper.Intro();

            do
            {
                choice = Helper.MainMenu();
                Console.WriteLine("success");

            } while (exit == 2);

        }

    }
}
