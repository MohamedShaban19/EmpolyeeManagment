using Employee_Management.Models.Permissions;
public interface IUserPermissionRepository
{
    IEnumerable<Permission> GetPermissionsByUser(int userId);
    void AssignPermissionsToUser(int userId, List<int> permissionIds);
    bool HasPermission(int userId, string permissionName);
}
