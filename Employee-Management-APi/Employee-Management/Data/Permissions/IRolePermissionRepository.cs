using Employee_Management.Models.Permissions;

public interface IRolePermissionRepository
{
    IEnumerable<Permission> GetPermissionsByRole(int roleId);
    void AssignPermissionsToRole(int roleId, List<int> permissionIds);
    bool HasPermission(int roleId, string permissionName);
}
