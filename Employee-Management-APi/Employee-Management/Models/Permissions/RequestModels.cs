namespace Employee_Management.Models.Permissions
{
    public class AssignRolePermissionsRequest
    {
        public int RoleId { get; set; }
        public List<int> PermissionIds { get; set; }
    }

    public class AssignUserPermissionsRequest
    {
        public int UserId { get; set; }
        public List<int> PermissionIds { get; set; }
    }


}
