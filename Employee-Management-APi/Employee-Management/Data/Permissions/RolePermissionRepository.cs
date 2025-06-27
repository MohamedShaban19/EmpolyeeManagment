using Employee_Management.Models.Permissions;
public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly AppDbContext _context;

    public RolePermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Permission> GetPermissionsByRole(int roleId)
    {
        var permissionIds = _context.RolePermissions
            .Where(rp => rp.RoleId == roleId)
            .Select(rp => rp.PermissionId)
            .ToList();

        return _context.Permissions
            .Where(p => permissionIds.Contains(p.PermissionId))
            .ToList();
    }

    public void AssignPermissionsToRole(int roleId, List<int> permissionIds)
    {
        var existing = _context.RolePermissions.Where(rp => rp.RoleId == roleId);
        _context.RolePermissions.RemoveRange(existing);

        var newAssignments = permissionIds.Select(pid => new RolePermission
        {
            RoleId = roleId,
            PermissionId = pid
        }).ToList();

        _context.RolePermissions.AddRange(newAssignments);
    }

    public bool HasPermission(int roleId, string permissionName)
    {
        return (from rp in _context.RolePermissions
                join p in _context.Permissions on rp.PermissionId equals p.PermissionId
                where rp.RoleId == roleId && p.PermissionName == permissionName
                select p).Any();
    }
}
