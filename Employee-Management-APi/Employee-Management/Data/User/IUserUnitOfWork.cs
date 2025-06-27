namespace Employee_Management.Data.Users;

public interface IUserUnitOfWork
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    int Complete();
}
