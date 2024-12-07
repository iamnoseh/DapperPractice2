using Model;

namespace Interufaces;


public interface IGroupService
{
    public void AddGroup(Group group);
    public void DeleteGroup(int id);
    public List<Group> GetAllGroups();
    public Group GetGroupById(int id);
    public void UpdateCourseGroup(Group group);
}