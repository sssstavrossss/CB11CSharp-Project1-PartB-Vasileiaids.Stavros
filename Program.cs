using CB11_ProjectA_PartB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CB11_ProjectA_PartB
{
    class Program
    {
        static void Main(string[] args)
        {


            Courses cr = new Courses();
            Type mytype = cr.GetType();
            FieldInfo[] field = mytype.GetFields();
            for (int i = 0; i < field.Length; i++)
            {
                // Determine whether or not each field is a special name.
                if (field[i].IsSpecialName)
                {
                    Console.WriteLine("The field {0} has a SpecialName attribute.",
                        field[i].Name);
                }
            }

        }
    }
}
