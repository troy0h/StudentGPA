using System;

namespace StudentGPA
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome");
            while (true)
            {
                Console.WriteLine("Enter an option");
                Console.WriteLine("(A) Create a student");
                Console.WriteLine("(B) Create a semester");
                Console.WriteLine("(C) Create a course");
                string option = Console.ReadLine();
                switch (option.ToUpper())
                {
                    case "A":
                        {
                            Console.Clear();
                            CreateStudent();
                            break;
                        }

                    case "B":
                        {
                            Console.Clear();
                            CreateSemester();
                            break;
                        }

                    case "C":
                        {
                            Console.Clear();
                            CreateCourse();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("That is not an option");
                            break;
                        }
                }
            }
        }

        static void CreateStudent()
        {
            Console.WriteLine("Create new student");

            Student student = new();

            bool firstNameLong = true;
            while (firstNameLong == true)
            {
                Console.WriteLine("Enter the student's first name: ");
                student.FirstName = Console.ReadLine();
                if (student.FirstName.Length > 50)
                {
                    Console.WriteLine("Student's first name too long!");
                }
                else
                {
                    firstNameLong = false;
                }
            }

            bool lastNameLong = true;
            while (lastNameLong == true)
            {
                Console.WriteLine("Enter the student's last name: ");
                student.LastName = Console.ReadLine();
                if (student.FirstName.Length > 50)
                {
                    Console.WriteLine("Student's last name too long!");
                }
                else
                {
                    lastNameLong = false;
                }
            }

            bool DoBValid = false;
            while (DoBValid == false)
            {
                Console.WriteLine("Enter the student's birth day (DD)");
                string DoBD = Console.ReadLine();
                Console.WriteLine("Enter the student's birth month (MM)");
                string DoBM = Console.ReadLine();
                Console.WriteLine("Enter the student's birth year (YYYY)");
                string DoBY = Console.ReadLine();
                
                string DoBParse = ($"{DoBD}/{DoBM}/{DoBY}");
                try
                {
                    student.DoB = DateTime.ParseExact(DoBParse, "dd/MM/yyyy", null);
                    Console.WriteLine(student.DoB.ToString());
                    DoBValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("That is not a valid date!");
                    DoBValid = false;
                }
            }
            Console.WriteLine("Enter the student's contact email address");
            student.Email = Console.ReadLine();

            Console.WriteLine("Enter the student's contact phone number");
            student.PhoneNum = Console.ReadLine();

            student.Create(student);
        }

        static void CreateSemester()
        {
            Semester semester = new();
            bool semesterLong = true;
            while (semesterLong == true)
            {
                Console.WriteLine("Please enter a name for the semester: ");
                semester.SemesterName = Console.ReadLine();
                if (semester.SemesterName.Length > 50)
                {
                    Console.WriteLine("That semester name is too long!");
                }
                else
                {
                    semesterLong = false;
                }
            }
            semester.Create(semester);
        }

        static void CreateCourse()
        {
            Courses course = new();

            course.Create(course);
        }
    }
}
