using Employee_Management.Data.Permissions;
namespace Employee_Management.Data.Empolyees
{
    public class PermissionsUnitOfWork : IPermissionsUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPermissionRepository Permissions { get; }
        public IRolePermissionRepository RolePermissions { get; }
        public IUserPermissionRepository UserPermissions { get; }

        public PermissionsUnitOfWork(AppDbContext context)
        {
            _context = context;
            Permissions = new PermissionRepository(_context);
            RolePermissions = new RolePermissionRepository(_context);
            UserPermissions = new UserPermissionRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
