using System;
using System.Data.SqlClient;

namespace StudentGPA
{
    class Semester
    {
        string ID { get; set; }
        public string SemesterName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public void Create(Semester semester)
        {
            bool idUnique = true;
            while (idUnique == true)
            {
                semester.ID = SQL.ID(10);
                SqlCommand testID = new SqlCommand($"SELECT ID FROM Semester WHERE ID = @ID;", SQL.conn);
                testID.Parameters.Add(new SqlParameter("@ID", semester.ID));
                SQL.conn.Open();
                if (testID.ExecuteScalar() == null)
                {
                    idUnique = false;
                    SQL.conn.Close();
                }
            }

            semester.DateCreated = DateTime.Now;
            semester.DateModified = DateTime.Now;

            SQL.conn.Open();
            SqlCommand newSemester = new SqlCommand($"INSERT INTO Semester VALUES(@ID, @SemesterName, @DateCreated, @DateModified);", SQL.conn);
            newSemester.Parameters.Add(new SqlParameter("@ID", semester.ID));
            newSemester.Parameters.Add(new SqlParameter("@SemesterName", semester.SemesterName));
            newSemester.Parameters.Add(new SqlParameter("@DateCreated", semester.DateCreated));
            newSemester.Parameters.Add(new SqlParameter("@DateModified", semester.DateModified));
            newSemester.ExecuteNonQuery();
            SQL.conn.Close();
            Console.WriteLine($"Semester {semester.SemesterName} has been created");

        }
    }
}
