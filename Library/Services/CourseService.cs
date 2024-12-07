namespace Services;
using DapperContext;
using Model;
using Interufaces;
using Npgsql;
using Dapper;
using System.Collections.Generic;

public class CourseService : ICoursesService
{
    private readonly DapperContext context;
    public CourseService()
    {
        context = new DapperContext();
    }
    public void AddCourse(Course course)
    {
        try
        {
        string cmd = "Insert into Courses(Name, Description,CreateDate,GroupId,MentorId,StudentId) values(@Name, @Description,@CreateDate, @GroupId,@MentorId,@StudentId);";
        connection.Execute(cmd,course);
        System.Console.WriteLine("Course Dokhil karda shud!");
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

    public void DeleteCourse(int id)
    {
                try
        {
        string cmd = "Delete from Courses where id = @id";
        connection.Execute(cmd,new {id = id});
        System.Console.WriteLine($"Course bo ID - i {id} az ruykhat nest karda shud!");
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
    

    public List<Course> GetAllCourses()
    {
        try
        {
        string cmd = "Select * from Courses ;";
        List<Course> courses  = connection.Query<Course>(cmd).ToList();
        return courses;
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

    public Course GetCourseById(int id)
    {
        try
        {
        string cmd = "Select * from Courses where id = @id";
        var course  = connection.Query<Course>(cmd,new {id = id});
        return course.SingleOrDefault();
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

    public void UpdateCourse(Course course)
    {
        try
        {
        string cmd = "Update Courses set Name = @Name, Description = @Description,CreateDate = @CreateDate, GroupId = @GroupId,MentorId = @MentorId,StudentId = @StudentId where id = @id";
        connection.Execute(cmd,course);
        System.Console.WriteLine("Course Update shud!");
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

