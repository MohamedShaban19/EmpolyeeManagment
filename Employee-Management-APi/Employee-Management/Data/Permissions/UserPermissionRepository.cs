using Employee_Management.Models.Permissions;
public class UserPermissionRepository : IUserPermissionRepository
{
    private readonly AppDbContext _context;

    public UserPermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Permission> GetPermissionsByUser(int userId)
    {
        var permissionIds = _context.UserPermissions
            .Where(up => up.UserId == userId)
            .Select(up => up.PermissionId)
            .ToList();

        return _context.Permissions
            .Where(p => permissionIds.Contains(p.PermissionId))
            .ToList();
    }

    public void AssignPermissionsToUser(int userId, List<int> permissionIds)
    {
        var existing = _context.UserPermissions.Where(up => up.UserId == userId);
        _context.UserPermissions.RemoveRange(existing);

        var newAssignments = permissionIds.Select(pid => new UserPermission
        {
            UserId = userId,
            PermissionId = pid
        }).ToList();

        _context.UserPermissions.AddRange(newAssignments);
    }

    public bool HasPermission(int userId, string permissionName)
    {
        return (from up in _context.UserPermissions
                join p in _context.Permissions on up.PermissionId equals p.PermissionId
                where up.UserId == userId && p.PermissionName == permissionName
                select p).Any();
    }
}
