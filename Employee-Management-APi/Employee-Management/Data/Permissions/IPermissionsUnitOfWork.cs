namespace Employee_Management.Data.Permissions
{
    public interface IPermissionsUnitOfWork
    {
        IRolePermissionRepository RolePermissions { get; }
        IUserPermissionRepository UserPermissions { get; }
        IPermissionRepository Permissions { get; }
        int Complete();
    }
}
