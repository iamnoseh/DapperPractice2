using Model;
using Services;


StudentService studentService = new StudentService();
var students1 = studentService.GetAllStudents();
foreach (var s in students1)
{
    System.Console.WriteLine($"ID: {s.StudentId} || FirstName : {s.FirstName} || LastName {s.LastName} || Age: {s.Age} || Email: {s.Email} || Address: {s.Address} ");
}



System.Console.WriteLine("______________________________________");


// Student student = new Student()
// {

//     FirstName = "John",
//     LastName = "Doe",
//     Age = 20,
//     Email = "john.doe@example.com",
//     PhoneNumber = "1234567890",
//     Address = "123 Main St"
// };
// studentService.AddStudent(student);

// Student student = new Student()
// {
//     StudentId = 1,
//     FirstName = "Safar",
//     LastName = "Satorov",
//     Age = 20,
//     Email = "safar.doe@example.com",
//     PhoneNumber = "1234567890",
//     Address = "123 SSS St"
// };
// studentService.UpdateStudent(student);
System.Console.WriteLine("______________________________");
Student student2 = new Student();

student2 = studentService.GetStudentById(5);
System.Console.WriteLine(student2.StudentId +" || "+student2.FirstName +" || " + student2.LastName+" || " + student2.Age + " || " + student2.Email);

System.Console.WriteLine("______________________________");

studentService.DeleteStudent(5);




CourseService courseService = new CourseService();
Course course = new Course()
{
    Name = "Test",
    Description = "Basic Math course",
    CreateDate = DateTime.Now,
    GroupId = 1,
    MentorId = 1,
    StudentId = 1
};
courseService.AddCourse(course);

System.Console.WriteLine("_______________________");
Course course1 = new Course()
{
    Id = 1,
    Name = "Test2222222222",
    Description = "Basic Math course222222222222",
    CreateDate = DateTime.Now,
    GroupId = 1,
    MentorId = 2,
    StudentId = 1
};
courseService.UpdateCourse(course1);



System.Console.WriteLine("___________________________");

courseService.DeleteCourse(3);

System.Console.WriteLine("______________________________");

Course course2 = new Course();
course2 = courseService.GetCourseById(1);
System.Console.WriteLine($"ID : {course2.Id} || {course2.Name} || {course2.Description}");

System.Console.WriteLine("______________________________");
List<Course> courses = new List<Course>();
courses = courseService.GetAllCourses();
foreach (var c in courses)
{
    System.Console.WriteLine(c.Id + "||" + c.Name + " || " + c.Description + " || " +c.CreateDate);
}


