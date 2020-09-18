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
        private static string queryTrainersPerCourse = "Select * from TrainersPerCourse";
        private static string queryAssignmentsPerCourse = "Select * from AssignmentsPerCourse";
        private static string queryAssignmentsPerStudent = "Select * from AssignmentsPerStudent";

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
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    }
                    else
                    {
                        Console.WriteLine("Success!!");
                    }
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
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    }
                    else
                    {
                        Console.WriteLine("Success!!");
                    }
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
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    }
                    else
                    {
                        Console.WriteLine("Success!!");
                    }
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
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    }
                    else
                    {
                        Console.WriteLine("Success!!");
                    }
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

        public void AddStudentsToCourses(Database db)
        {
            List<int> cr = db.GetCoursesID();
            List<int> st = db.GetStudentsID();
            bool flag = false;
            int st_number;
            int cr_number;
            do
            {
                db.ShowStudents();
                st_number = Helper.GetNumberList(st, "the number that corresponds to the student you want to assign:");
                db.ShowCourses();
                cr_number = Helper.GetNumberList(cr, "the number that corresponds to the course you want to assign the student you picked:");
                List<Students> st_list = db.Students.ToList();
                Students st_target = st_list.Find(x => x.SID == st_number);
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
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    } else
                    {
                        Console.WriteLine("Success!!");
                    }
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

        public void AddTrainersToCourses(Database db)
        {
            List<int> cr = db.GetCoursesID();
            List<int> tr = db.GetTrainersID();
            bool flag = false;
            int tr_number;
            int cr_number;
            do
            {
                db.ShowTrainers();
                tr_number = Helper.GetNumberList(tr, "the number that corresponds to the trainer you want to assign:");
                db.ShowCourses();
                cr_number = Helper.GetNumberList(cr, "the number that corresponds to the course you want to assign the trainer you picked:");
                List<Trainers> tr_list = db.Trainers.ToList();
                Trainers tr_target = tr_list.Find(x => x.TID == tr_number);
                List<Courses> cr_list = tr_target.Courses.ToList();

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
                    SqlDataAdapter adapter = new SqlDataAdapter(queryTrainersPerCourse, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "TrainersPerCourse");
                    SqlCommand cmd = new SqlCommand(@"insert into TrainersPerCourse(CID, TID) values (@CID, @TID)", conn);
                    cmd.Parameters.AddWithValue("@CID", cr_number);
                    cmd.Parameters.AddWithValue("@TID", tr_number);
                    adapter.InsertCommand = cmd;
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    }
                    else
                    {
                        Console.WriteLine("Success!!");
                    }
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
        public void AddAssignmentsToCourses(Database db)
        {
            List<int> cr = db.GetCoursesID();
            List<int> ag = db.GetAssignmentsID();
            bool flag = false;
            int ag_number;
            int cr_number;
            do
            {
                db.ShowAssignments();
                ag_number = Helper.GetNumberList(ag, "the number that corresponds to the assignment you want to assign:");
                db.ShowCourses();
                cr_number = Helper.GetNumberList(cr, "the number that corresponds to the course you want to assign the student you picked:");
                List<Assignments> ag_list = db.Assignments.ToList();
                Assignments ag_target = ag_list.Find(x => x.AID == ag_number);
                List<Courses> cr_list = ag_target.Courses.ToList();

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
                    SqlDataAdapter adapter = new SqlDataAdapter(queryAssignmentsPerCourse, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "AssignmentsPerCourse");
                    SqlCommand cmd = new SqlCommand(@"insert into AssignmentsPerCourse(AID, CID) values (@AID, @CID)", conn);
                    cmd.Parameters.AddWithValue("@CID", cr_number);
                    cmd.Parameters.AddWithValue("@AID", ag_number);
                    adapter.InsertCommand = cmd;
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    }
                    else
                    {
                        Console.WriteLine("Success!!");
                    }
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
        public void AddAssignmentsToStudents(Database db)
        {
            List<int> st = db.GetStudentsID();
            List<int> ag = db.GetAssignmentsID();
            bool flag = false;
            int ag_number;
            int st_number;
            do
            {
                db.ShowAssignments();
                ag_number = Helper.GetNumberList(ag, "the number that corresponds to the assignment you want to assign:");
                db.ShowCourses();
                st_number = Helper.GetNumberList(st, "the number that corresponds to the student you want to assign the assignment you picked:");
                List<Assignments> ag_list = db.Assignments.ToList();
                Assignments ag_target = ag_list.Find(x => x.AID == ag_number);
                List<Students> st_list = ag_target.Students.ToList();

                foreach (var item in st_list)
                {
                    if (item.SID == st_number)
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
                    SqlDataAdapter adapter = new SqlDataAdapter(queryAssignmentsPerStudent, connstring);
                    DataSet dtset = new DataSet();
                    adapter.Fill(dtset, "AssignmentsPerStudent");
                    SqlCommand cmd = new SqlCommand(@"insert into AssignmentsPerStudent(SID, AID) values (@SID, @AID)", conn);
                    cmd.Parameters.AddWithValue("@SID", st_number);
                    cmd.Parameters.AddWithValue("@AID", ag_number);
                    adapter.InsertCommand = cmd;
                    int a = adapter.InsertCommand.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("Problem!");
                    }
                    else
                    {
                        Console.WriteLine("Success!!");
                    }
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
    }
}
