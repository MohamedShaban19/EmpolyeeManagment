using Employee_Management.Models.AuditLog;

public interface IAuditService
{
    void Log(string actionType, string entityName, string entityId, string performedBy, string details = null);
    IEnumerable<AuditLog> GetAllLogs();
}
