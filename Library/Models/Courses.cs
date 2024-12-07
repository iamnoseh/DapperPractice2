namespace Model;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreateDate { get; set;}
    public int GroupId { get; set; }
    public int MentorId { get; set; }
    public int StudentId { get; set; }
}