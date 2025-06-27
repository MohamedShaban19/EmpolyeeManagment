using Employee_Management.Models.User;
using System;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User GetById(int userId)
    {
        return _context.Users.Find(userId);
    }
    public User GetByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }
    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
