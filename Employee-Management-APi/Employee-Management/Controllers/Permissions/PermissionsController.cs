using Employee_Management.Data.Permissions;
using Employee_Management.Models.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Policy = "AdminPolicy")]
[Route("api/[controller]")]
[ApiController]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionsUnitOfWork _unitOfWork;

    public PermissionsController(IPermissionsUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("All")]
    public IActionResult GetAllPermissions()
    {
        var permissions = _unitOfWork.Permissions.GetAll();
        return Ok(permissions);
    }

    [HttpGet("Role/{roleId}")]
    public IActionResult GetPermissionsByRole(int roleId)
    {
        var permissions = _unitOfWork.RolePermissions.GetPermissionsByRole(roleId);
        return Ok(permissions);
    }

    [HttpPost("Role/Assign")]
    public IActionResult AssignPermissionsToRole([FromBody] AssignRolePermissionsRequest request)
    {
        _unitOfWork.RolePermissions.AssignPermissionsToRole(request.RoleId, request.PermissionIds);
        _unitOfWork.Complete();
        return Ok("Permissions assigned to role.");
    }

    [HttpGet("User/{userId}")]
    public IActionResult GetPermissionsByUser(int userId)
    {
        var permissions = _unitOfWork.UserPermissions.GetPermissionsByUser(userId);
        return Ok(permissions);
    }

    [HttpPost("User/Assign")]
    public IActionResult AssignPermissionsToUser([FromBody] AssignUserPermissionsRequest request)
    {
        _unitOfWork.UserPermissions.AssignPermissionsToUser(request.UserId, request.PermissionIds);
        _unitOfWork.Complete();
        return Ok("Permissions assigned to user.");
    }
}
