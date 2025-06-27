using Employee_Management.Data.Empolyees;
using Employee_Management.Models.Empolyee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employee_Management.Controllers.Empolyees
{
    [Authorize]
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;


        public EmployeesController(IEmpUnitOfWork unitOfWork, IAuditService auditService)
        {
            _unitOfWork = unitOfWork;
            _auditService = auditService;

        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll(
            [FromQuery] string? name,
            [FromQuery] string? position,
            [FromQuery] decimal? minSalary,
            [FromQuery] decimal? maxSalary,
            [FromQuery] bool expand = false)
        {
            var employees = _unitOfWork.Employees.GetFiltered(name, position, minSalary, maxSalary);

            if (expand)
            {
                var result = employees.Select(e => new
                {
                    e.Id,
                    e.EmployeeCode,
                    e.FirstName,
                    e.LastName,
                    e.Position,
                    SalaryInfo = new
                    {
                        e.Salary,
                        e.Currency
                    }
                });

                return Ok(result);
            }

            return Ok(employees);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        [Authorize]
        [HttpPost("Add")]
        public IActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_unitOfWork.Employees.ExistsByCode(employee.EmployeeCode))
                return BadRequest($"Employee Code '{employee.EmployeeCode}' already exists.");

            employee.IsActive = true;
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Commit();
            _auditService.Log("Create", "Employee", employee.EmployeeCode.ToString(), User.Identity.Name);


            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("Update")]
        public IActionResult Update(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _unitOfWork.Employees.GetById(employee.Id);
            if (existing == null)
                return NotFound();

            if (existing.EmployeeCode != employee.EmployeeCode)
                return BadRequest("Employee Code cannot be changed.");

            _unitOfWork.Employees.Update(employee);
            _unitOfWork.Commit();
            _auditService.Log("Update", "Employee", employee.EmployeeCode.ToString(), User.Identity.Name);

            return NoContent();
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
                return NotFound();

            if (employee.IsActive)
                return BadRequest($"Cannot delete active employee '{employee.EmployeeCode}'.");

            _unitOfWork.Employees.Delete(employee);
            _unitOfWork.Commit();
            _auditService.Log("Delete", "Employee", employee.EmployeeCode.ToString(), User.Identity.Name);

            return NoContent();
        }
    }
}
