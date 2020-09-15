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
        private static string query = "Select * from";
        private static string quety2 = $@"insert into {1}(title, stream, type, startDate, endDate)
                    values (@title, @stream, @type, @startDate, @endDate)";

        public void Add<T>(T obj)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    

                    //insert course to database
                    method1(conn, (Courses)(object)obj);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        private void method1(SqlConnection conn, Courses cr)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryCourses, connstring);
            DataSet dtset = new DataSet();
            adapter.Fill(dtset, "Courses");
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

        }
        public void ShowCourses()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(queryCourses, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    Database db = new Database();
                    List<Courses> coursesList = db.Courses.ToList();
                    foreach (Courses st in coursesList)
                    {
                        Console.WriteLine(st.title);
                        foreach (Students crs in st.Students)
                        {
                            Console.WriteLine(crs.firstName);
                        }
                    }

                    

                    //show course from database
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            int CID = Convert.ToInt32(rdr["CID"]);
                            string title = Convert.ToString(rdr["title"]);
                            string type = Convert.ToString(rdr["type"]);
                            string stream = Convert.ToString(rdr["stream"]);
                            DateTime startDate = Convert.ToDateTime(rdr["startDate"]);
                            DateTime endDate = Convert.ToDateTime(rdr["endDate"]);
                            Console.WriteLine($"{CID}, Title: {title}, Type: {type}, Stream: {stream}, Start Date: {startDate}, End Date: {endDate}");
                        }
                    }
                    else
                        Console.WriteLine("No Courses in the Database yet!!");
                    
                    conn.Close();
                    Console.WriteLine();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void ShowStudents()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(queryStudents, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //show students from database
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            int SID = Convert.ToInt32(rdr["SID"]);
                            string firstName = Convert.ToString(rdr["firstName"]);
                            string lastName = Convert.ToString(rdr["lastName"]);
                            DateTime dateOfBirth = Convert.ToDateTime(rdr["dateOfBirth"]);
                            int tuitionFees = Convert.ToInt32(rdr["tuitionFees"]);
                            Console.WriteLine($"{SID}, First Name: {firstName}, Last Name: {lastName}, Birth Date: {dateOfBirth}, Tuition Fees: {tuitionFees}");
                        }
                    }
                    else
                        Console.WriteLine("No Students in the Database yet!!");

                    conn.Close();
                    Console.WriteLine();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void ShowTrainers()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(queryTrainers, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //show trainers from database
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            int TID = Convert.ToInt32(rdr["TID"]);
                            string firstName = Convert.ToString(rdr["firstName"]);
                            string lastName = Convert.ToString(rdr["lastName"]);
                            string subject = Convert.ToString(rdr["subject"]);
                            Console.WriteLine($"{TID}, First Name: {firstName}, Last Name: {lastName}, Subject: {subject}");
                        }
                    }
                    else
                        Console.WriteLine("No Trainers in the Database yet!!");

                    conn.Close();
                    Console.WriteLine();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void ShowAssignments()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(queryAssignments, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //show assignments from database
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            int AID = Convert.ToInt32(rdr["AID"]);
                            string title = Convert.ToString(rdr["title"]);
                            string description = Convert.ToString(rdr["description"]);
                            DateTime subDateTime = Convert.ToDateTime(rdr["subDateTime"]);
                            int oralMark = Convert.ToInt32(rdr["oralMark"]);
                            int totalMark = Convert.ToInt32(rdr["totalMark"]);
                            Console.WriteLine($"{AID}, Title: {title}, Description: {description}, Sub date: {subDateTime}, Oral Mark: {oralMark}, Total Mark {totalMark}");
                        }
                    }
                    else
                        Console.WriteLine("No Courses in the Database yet!!");

                    conn.Close();
                    Console.WriteLine();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
