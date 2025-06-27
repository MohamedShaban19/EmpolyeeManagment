using Employee_Management.Models.Permissions;
public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _context;

    public PermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Permission> GetAll()
    {
        return _context.Permissions.ToList();
    }

    public Permission GetById(int permissionId)
    {
        return _context.Permissions.Find(permissionId);
    }

    public void Add(Permission permission)
    {
        _context.Permissions.Add(permission);
    }

    public void Remove(Permission permission)
    {
        _context.Permissions.Remove(permission);
    }
}
