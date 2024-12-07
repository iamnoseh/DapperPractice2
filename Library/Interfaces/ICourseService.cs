namespace Interufaces;
using Model;

public interface ICoursesService
{
    public void AddCourse(Course course);
    public List<Course> GetAllCourses();
    public Course GetCourseById(int id);
    public void UpdateCourse(Course course);
    public void DeleteCourse(int id);
}