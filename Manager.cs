using CB11_ProjectA_PartB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
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
        private static string queryStudentsPerCourse = "Select * from StudentsPerCourse";


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
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Success!!");
                Console.WriteLine();
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
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Success!!");
                Console.WriteLine();
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
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Success!!");
                Console.WriteLine();
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
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Success!!");
                Console.WriteLine();
            }

        }

        public void AddStudentsToCourses(Database db)
        {

            List<int> cr = db.GetCoursesID();
            List<int> st = db.GetStudentsID();
            bool flag = false;
            int st_number;
            int cr_number;

            //cr.ForEach(item => Console.WriteLine(item));
            //st.ForEach(item => Console.WriteLine(item));

            do
            {

                db.ShowStudents();
                st_number = Helper.GetNumberList(st, "the number that corresponds to the student you want to assign:");
                Console.WriteLine(st_number);

                db.ShowCourses();
                cr_number = Helper.GetNumberList(cr, "the number that corresponds to the course you want to assign the student you picked:");
                Console.WriteLine(cr_number);

                List<Students> st_list = db.Students.ToList();
                Students st_target = st_list[st_number];
                List<Courses> cr_list = st_target.Courses.ToList();

                foreach (var item in cr_list)
                {
                    if (item.CID == cr_number)
                    {
                        flag = true;
                        Console.WriteLine("Already exists!");
                        break;
                    }
                }

            } while (flag);

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryStudentsPerCourse, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "StudentsPerCourse");
                    SqlCommand cmd = new SqlCommand(@"insert into StudentsPerCourse(SID, CID) values (@SID, @CID)", conn);
                    cmd.Parameters.AddWithValue("@CID", cr_number);
                    cmd.Parameters.AddWithValue("@SID", st_number);
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.Dispose();
                    dtset.Dispose();
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Success!!");
                Console.WriteLine();
            }

        }



    }
}
