using Employee_Management.Models.User;

public interface IUserRepository
{
    User GetById(int userId);
    User GetByUsername(string username);

    void Add(User user);
    void Save();
}