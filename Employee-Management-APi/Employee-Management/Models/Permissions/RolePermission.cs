using Employee_Management.Models.Roles;

namespace Employee_Management.Models.Permissions
{
    public class RolePermission
    {
        public int? RolePermissionId { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }

}
