namespace Employee_Management.Models.Roles
{
    public class ChangeUserRoleRequest
    {
        public int UserId { get; set; }
        public int NewRoleId { get; set; }
    }
}
