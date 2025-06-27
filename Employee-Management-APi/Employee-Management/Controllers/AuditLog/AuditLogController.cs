using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers.AuditLog
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditLogsController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllLogs()
        {
            var logs = _auditService.GetAllLogs();
            return Ok(logs);
        }
    }

}
