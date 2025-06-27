using Employee_Management.Data.Users;

public class UserUnitOfWork : IUserUnitOfWork
{
    private readonly AppDbContext _context;
    public IUserRepository Users { get; }
    public IRoleRepository Roles { get; }

    public UserUnitOfWork(AppDbContext context, IUserRepository users, IRoleRepository roles)
    {
        _context = context;
        Users = users;
        Roles = roles;
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }
}
