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
    class Manager
    {

        private static string connstring = "Data Source=localhost;Initial Catalog=CB11-Project1;Integrated Security=SSPI;";
        private static string queryCourses = "Select * from Courses";
        private static string queryStudents = "Select * from Students";
        private static string queryAssignments = "Select * from Assignments";
        private static string queryTrainers = "Select * from Trainers";
        public void AddCourse(Courses cr)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryCourses, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "Courses");

                    //insert course to database
                    SqlCommand cmd = new SqlCommand(@"insert into Courses(title, stream, type, startDate, endDate)
                    values (@title, @stream, @type, @startDate, @endDate)", conn);
                    cmd.Parameters.AddWithValue("@title", cr.title);
                    cmd.Parameters.AddWithValue("@type", cr.type);
                    cmd.Parameters.AddWithValue("@stream", cr.stream);
                    cmd.Parameters.AddWithValue("@startDate", cr.startDate);
                    cmd.Parameters.AddWithValue("@endDate", cr.endDate);
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.Dispose();
                    dtset.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void AddStudent(Students st)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryStudents, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "Students");

                    //insert student to database
                    SqlCommand cmd = new SqlCommand(@"insert into Students(firstName, lastName, dateOfBirth, tuitionFees)
                    values (@firstName, @lastName, @dateOfBirth, @tuitionFees)", conn);
                    cmd.Parameters.AddWithValue("@firstName", st.firstName);
                    cmd.Parameters.AddWithValue("@lastName", st.lastName);
                    cmd.Parameters.AddWithValue("@dateOfBirth", st.dateOfBirth);
                    cmd.Parameters.AddWithValue("@tuitionFees", st.tuitionFees);
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.Dispose();
                    dtset.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void AddAssignment(Assignments ag)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryAssignments, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "Assignments");

                    //insert assignment to database
                    SqlCommand cmd = new SqlCommand(@"insert into Assignments(title, description, subDateTime, oralMark, totalMark)
                    values (@title, @description, @subDateTime, @oralMark, @totalMark)", conn);
                    cmd.Parameters.AddWithValue("@title", ag.title);
                    cmd.Parameters.AddWithValue("@description", ag.description);
                    cmd.Parameters.AddWithValue("@subDateTime", ag.subDateTime);
                    cmd.Parameters.AddWithValue("@oralMark", ag.oralMark);
                    cmd.Parameters.AddWithValue("@totalMark", ag.totalMark);
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.Dispose();
                    dtset.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void AddTrainer(Trainers tr)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryTrainers, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "Trainers");

                    //insert trainer to database
                    SqlCommand cmd = new SqlCommand(@"insert into Trainers(firstName, lastName, subject)
                    values (@firstName, @lastName, @subject, @startDate, @endDate)", conn);
                    cmd.Parameters.AddWithValue("@firstName", tr.firstName);
                    cmd.Parameters.AddWithValue("@lastName", tr.lastName);
                    cmd.Parameters.AddWithValue("@subject", tr.subject);
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.Dispose();
                    dtset.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }


    }
}
