using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Employee_Management.Models.Roles;
using Employee_Management.Models.User;
using Employee_Management.Data.Empolyees;
using Employee_Management.Data.Users;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserUnitOfWork _unitOfWork;

    public UsersController(IUserUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Authorize(Policy = "AdminPolicy")]
    [HttpPut("ChangeUserRole")]
    public IActionResult ChangeUserRole([FromBody] ChangeUserRoleRequest request)
    {
        var user = _unitOfWork.Users.GetById(request.UserId);
        if (user == null)
            return NotFound("User not found");

        var role = _unitOfWork.Roles.GetById(request.NewRoleId);
        if (role == null)
            return BadRequest("Invalid role");

        user.RoleId = request.NewRoleId;
        _unitOfWork.Complete();
        return Ok("User role updated successfully");
    }
}
