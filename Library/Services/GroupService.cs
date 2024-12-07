namespace Services;
using Model;
using Interufaces;
using Npgsql;
using Dapper;
using System.Collections.Generic;

public class GroupService : IGroupService
{
    public void AddGroup(Group group)
    {
           try
        {
        string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        string cmd = "Insert into Groups(Name, Description,MentorId,StudentId) values( @Name, @Description, @MentorId,@StudentId);";
        connection.Execute(cmd,group);
        System.Console.WriteLine("Groupi nav Dokhil karda shud!");
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

    public void DeleteGroup(int id)
    {
        try
        {
        string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        string cmd = "Delete from Groups where id = @id";
        connection.Execute(cmd,new {id = id});
        System.Console.WriteLine($"Group bo ID - i {id} az ruykhat nest karda shud!");
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

    public List<Group> GetAllGroups()
    {
                 try
        {
        string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        string cmd = "Select * from Groups ;";
        List<Group> groups  = connection.Query<Group>(cmd).ToList();
        return groups;
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

    public Group GetGroupById(int id)
    {
        try
        {
            string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string cmd = "Select * from Groups where id = @id;";
            Group group = connection.Query(cmd).FirstOrDefault();
            return group;
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

    public void UpdateCourseGroup(Group group)
    {
        try
        {
        string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        string cmd = "Update Groups set Name = @Name, Description = @Description,MentorId = @MentorId,StudentId = @StudentId where id = @id";
        int effect = connection.Execute(cmd,group);
        if (effect != 0)
            {
                System.Console.WriteLine("Groupi az ruykhat shod!");
            }
        else
            {
                System.Console.WriteLine("Error : Group Updaet nashud!");
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





