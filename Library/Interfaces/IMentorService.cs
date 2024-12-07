using Model;

namespace Interufaces;

public interface IMentorService
{
    public void AddMentor(Mentor mentor);
    public void UpdateMentor(Mentor mentor);
    public void DeleteMentor(int id);
    public Mentor GetMentorById(int id);
    public List<Mentor> GetAllMentors();
}