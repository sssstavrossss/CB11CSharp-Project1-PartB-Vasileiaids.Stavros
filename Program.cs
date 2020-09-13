using CB11_ProjectA_PartB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB11_ProjectA_PartB
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("CB11 | Project 1 | Part B | Vasileiadis Stavros");
            Console.WriteLine();
            Menu.Init();

            //Database db = new Database();
            //List<Students> studentList = db.Students.ToList();
            //foreach (Students st in studentList)
            //{
            //    Console.WriteLine(st.firstName);
            //    foreach (Courses crs in st.Courses)
            //    {
            //        Console.WriteLine(crs.title);
            //    }
            //}

            //Console.WriteLine("1");

            //string connstring = "Data Source=localhost;Initial Catalog=CB11-Project1;Integrated Security=SSPI;";
            //string query = "Select * from Students";

            //try
            //{
            //    Console.WriteLine("2");
            //    using (SqlConnection conn = new SqlConnection(connstring))
            //    {
            //        Console.WriteLine("3");
            //        conn.Open();
            //        Console.WriteLine("10");
            //        SqlDataAdapter adapter = new SqlDataAdapter(query, connstring);
            //        Console.WriteLine("11");
            //        DataSet dtset = new DataSet();
            //        Console.WriteLine("12");
            //        adapter.Fill(dtset, "Students");
            //        Console.WriteLine("9");

            //        //insert
            //        SqlCommand cmd = new SqlCommand(@"insert into Students(firstName, lastName, dateOfBirth, tuitionFees)
            //        values (@firstName, @lastName, @dateOfBirth, @tuitionFees)", conn);
            //        cmd.Parameters.AddWithValue("@firstName", "stavros");
            //        cmd.Parameters.AddWithValue("@lastName", "vasileiadis");
            //        cmd.Parameters.AddWithValue("@dateOfBirth", DateTime.Now.Date);
            //        cmd.Parameters.AddWithValue("@tuitionfees", 2000);
            //        adapter.InsertCommand = cmd;
            //        adapter.InsertCommand.ExecuteNonQuery();
            //        Console.WriteLine("4");
            //        ////update
            //        //cmd = new SqlCommand(@"update Customers
            //        //set fullname = @fullname, age =@age
            //        //where cust_id = @cust_id", conn);
            //        //cmd.Parameters.AddWithValue("@cust_id", 25);
            //        //cmd.Parameters.AddWithValue("@fullname", "Kapoios2");
            //        //cmd.Parameters.AddWithValue("@age", 35);
            //        //adapter.UpdateCommand = cmd;
            //        //adapter.UpdateCommand.ExecuteNonQuery();

            //        ////delete
            //        //cmd = new SqlCommand(@"delete from Customers
            //        //where cust_id = @cust_id", conn);
            //        //cmd.Parameters.AddWithValue("@cust_id", 25);
            //        //adapter.DeleteCommand = cmd;
            //        //adapter.DeleteCommand.ExecuteNonQuery();
            //        ////adapter.Update(dtset, "Customers");
            //        Console.WriteLine("6");
            //        adapter.Dispose();
            //        dtset.Dispose();
            //        Console.WriteLine("7");
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //Console.WriteLine("8");
        }
    }
}
