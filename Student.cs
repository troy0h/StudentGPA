using System;
using System.Data.SqlClient;

namespace StudentGPA
{
    class Student
    {
        string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNum { get; set; }

        public void CreateStudent(Student student)
        {
            Console.WriteLine("Creating new student...");

            bool idUnique = true;
            while (idUnique == true)
            {
                student.ID = SQL.ID(10);
                SqlCommand testID = new SqlCommand($"SELECT ID FROM Students WHERE ID = @ID;", SQL.conn);
                testID.Parameters.Add(new SqlParameter("@ID", student.ID));
                SQL.conn.Open();
                if (testID.ExecuteScalar() == null)
                {
                    idUnique = false;
                    SQL.conn.Close();
                }
            }

            SQL.conn.Open();
            SqlCommand newStudent = new SqlCommand($"INSERT INTO Students VALUES(@ID, @FirstName, @SurName, @DoB, @Email, @PhoneNumber);", SQL.conn);
            newStudent.Parameters.Add(new SqlParameter("@ID", student.ID));
            newStudent.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
            newStudent.Parameters.Add(new SqlParameter("@SurName", student.LastName));
            newStudent.Parameters.Add(new SqlParameter("@DoB", student.DoB));
            newStudent.Parameters.Add(new SqlParameter("@Email", student.Email));
            newStudent.Parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNum));
            newStudent.ExecuteNonQuery();
            SQL.conn.Close();
            Console.WriteLine($"Student {student.FirstName} {student.LastName} has been created.");
        }
    }
}
