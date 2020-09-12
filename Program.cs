using CB11_ProjectA_PartB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB11_ProjectA_PartB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            List<Students> studentList = db.Students.ToList();
            foreach (Students st in studentList)
            {
                Console.WriteLine(st.firstName);
                foreach (Courses crs in st.Courses)
                {
                    Console.WriteLine(crs.title);
                }
            }
        }
    }
}
