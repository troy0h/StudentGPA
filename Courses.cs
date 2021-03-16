using System;
using System.Data.SqlClient;

namespace StudentGPA
{
    class Courses
    {
        string ID { get; set; }
        public string CourseName { get; set; }
        public string Year { get; set; }
        public string SemesterID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public void Create(Courses course)
        {
            bool idUnique = true;
            while (idUnique == true)
            {
                course.ID = SQL.ID(10);
                SqlCommand testID = new SqlCommand($"SELECT ID FROM Course WHERE ID = @ID;", SQL.conn);
                testID.Parameters.Add(new SqlParameter("@ID", course.ID));
                SQL.conn.Open();
                if (testID.ExecuteScalar() == null)
                {
                    idUnique = false;
                    SQL.conn.Close();
                }
            }



        }
    }
}
