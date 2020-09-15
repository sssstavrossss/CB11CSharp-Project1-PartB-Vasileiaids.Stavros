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
            List<Type> type = new List<Type> { typeof(Int32), typeof(Int32?), typeof(String), typeof(DateTime), typeof(DateTime?), };
            Courses cr = new Courses();
            Type mytype = cr.GetType();
            PropertyInfo[] pr = cr.GetType().GetProperties();
            FieldInfo[] field = mytype.GetFields();
            string msg = "";
            for (int i = 0; i < pr.Length; i++)
            {
                if (type.Contains(pr[i].PropertyType))
                    msg += "@" + pr[i].Name + " ";
                //Console.WriteLine(pr[i].Name + " " + pr[i].PropertyType.Name);
            }
            Console.WriteLine(msg);
            //Console.WriteLine("CB11 | Project 1 | Part B | Vasileiadis Stavros");
            //Console.WriteLine();
            //Menu.Init();

        }
    }
}
