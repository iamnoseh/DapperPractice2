using Interufaces;
using Model;
using Npgsql;
using Dapper;
using DapperContexts;
namespace Services;


public class StudentService : IStudentService
{
        private readonly DapperContext context;
    public StudentService()
    {
        context = new DapperContext();
    }
    public void AddStudent(Student student)
    {
        try
        {
            string cmd = "INSERT INTO Students (First_Name, Last_Name, Age, Email, PhoneNumber, Address) VALUES ( @FirstName, @LastName, @Age, @Email, @PhoneNumber, @Address);";
            int effect = context.GetConnection().Execute(cmd,student);
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
             string cmd ="Delete from Students where StudentId=@Id";
            int effect = context.GetConnection().Execute(cmd,new {id});
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
            string cmd = "SELECT * FROM Students;";
            List<Student> student = context.GetConnection().Query<Student>(cmd).ToList();
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
            string cmd = "SELECT * FROM Students where StudentId = @StudentId";
            Student student = context.GetConnection().Query<Student>(cmd).FirstOrDefault();
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
             string cmd = @"
                UPDATE Students
                SET FirstName = @First_Name,
                    LastName = @Last_Name,
                    Age = @Age,
                    Email = @Email,
                    PhoneNumber = @PhoneNumber,
                    Address = @Address
                WHERE StudentId = @StudentId;";
            int effect = context.GetConnection().Execute(cmd, new
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