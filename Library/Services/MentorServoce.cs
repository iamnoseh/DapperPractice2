using Interufaces;
using Model;
using Npgsql;
using Dapper;
using DapperContexts;
namespace Services;


public class MentorService : IMentorService
{
    private readonly  DapperContext context;
    public MentorService()
    {
        context = new DapperContext();
    }
    public void AddMentor(Mentor mentor)
    {
        try
        {
           string cmd = "INSERT INTO Mentor (FirstName, LastName,Age,Email,Phonenumber,Address) values(@First_Name,@Last_Name,Age = @Age,@Email, = @Phonenumber,@Address)" ;
            int effect = context.GetConnection().Execute(cmd,mentor);
            if (effect != 0)
            {
                System.Console.WriteLine("Mentor inserted successfully");
            }
            else
            {
                System.Console.WriteLine("Mentor inserted failed");
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

    public void DeleteMentor(int id)
    {
        try
        {
             string cmd ="Delete from Mentor where MentorId=@Id";
            int effect = context.GetConnection().Execute(cmd,new {id});
            if (effect != 0) 
            {
                System.Console.WriteLine("Mentor deleted!");
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

    public List<Mentor> GetAllMentors()
    {
        try
        {
             string cmd = "SELECT * FROM Mentors";
            List<Mentor> mentors = context.GetConnection().Query<Mentor>(cmd).ToList();
            return mentors;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public Mentor GetMentorById(int id)
    {
        try
        {
            string cmd = "SELECT * FROM Mentors where MentorId = @id";
            Mentor mentor = context.GetConnection().Query<Mentor>(cmd).FirstOrDefault();;
            return mentor;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }     
    }

    public void UpdateMentor(Mentor mentor)
    {
        try
        {
             string cmd = "Update Mentor set FirstName = @First_Name,LastName = @Last_Name,Age = @Age,Email = @Email,Phonenumber = @Phonenumber,Address = @Address where MentorId = @Id" ;
            int effect = context.GetConnection().Execute(cmd,mentor);
            if (effect != 0)
            {
                System.Console.WriteLine("Mentor Updated successfully");
            }
            else
            {
                System.Console.WriteLine("Mentor Updated failed");
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