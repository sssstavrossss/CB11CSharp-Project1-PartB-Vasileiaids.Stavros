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
        private static string query = "Select * from Courses";
        public void AddCourse(Courses cr)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connstring);
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


    }
}
