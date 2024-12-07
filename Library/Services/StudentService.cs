using Interufaces;
using Model;
using Npgsql;
using Dapper;
namespace Services;


public class StudentService : IStudentService
{
    public void AddStudent(Student student)
    {
        try
        {
            string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string cmd = "INSERT INTO Students (First_Name, Last_Name, Age, Email, PhoneNumber, Address) VALUES ( @FirstName, @LastName, @Age, @Email, @PhoneNumber, @Address);";
            int effect = connection.Execute(cmd,student);
            if (effect != 0)
            {
                System.Console.WriteLine("Student inserted successfully");
            }
            else
            {
                System.Console.WriteLine("Student inserted failed");
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public void DeleteStudent(int id)
    {
         try
        {
            string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string cmd ="Delete from Students where StudentId=@Id";
            int effect = connection.Execute(cmd,new {id});
            if (effect != 0) 
            {
                System.Console.WriteLine("Student deleted!");
            }
            else
            {
                System.Console.WriteLine("Error deleting");
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public List<Student> GetAllStudents()
    {
         try
        {
             string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string cmd = "SELECT * FROM Students;";
            List<Student> student = connection.Query<Student>(cmd).ToList();
            return student;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public Student GetStudentById(int id)
    {
        try
        {
            string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string cmd = "SELECT * FROM Students where StudentId = @StudentId";
            Student student = connection.Query<Student>(cmd).FirstOrDefault();
            return student;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }     
    }

    public void UpdateStudent(Student student)
    {
         try
        {
            string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string cmd = @"
                UPDATE Students
                SET FirstName = @First_Name,
                    LastName = @Last_Name,
                    Age = @Age,
                    Email = @Email,
                    PhoneNumber = @PhoneNumber,
                    Address = @Address
                WHERE StudentId = @StudentId;";
            int effect = connection.Execute(cmd, new
            {
                student.FirstName,
                student.LastName,
                student.Age,
                student.Email,
                student.PhoneNumber,
                student.Address,
                student.StudentId
            });
            if (effect != 0)
            {
                System.Console.WriteLine("Student Updated successfully");
            }
            else
            {
                System.Console.WriteLine("Student Updated failed");
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }
}