using Model;

namespace Interufaces;


public interface IStudentService
{
    public void AddStudent(Student student);
    public void UpdateStudent(Student student);
    public void DeleteStudent(int id);
    public Student GetStudentById(int id);
    public List<Student> GetAllStudents();
}