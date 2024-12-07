namespace Model;

public class Group 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int StudentId { get; set; }
    public int MentorId { get; set; }
}