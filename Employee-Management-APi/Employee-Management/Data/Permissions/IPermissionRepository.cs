using Employee_Management.Models.Permissions;
public interface IPermissionRepository
{
    IEnumerable<Permission> GetAll();
    Permission GetById(int permissionId);
    void Add(Permission permission);
    void Remove(Permission permission);
}
