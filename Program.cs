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
                Console.WriteLine("(C)reate a student");
                string option = Console.ReadLine();
                switch (option.ToUpper())
                {
                    case "C":
                        {
                            Console.Clear();
                            CreateStudent();
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

            Console.WriteLine("Enter the student's first name: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the student's last name: ");
            student.LastName = Console.ReadLine();

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

            student.CreateStudent(student);
        }
    }
}
