
namespace Employee_Management.Models.AuditLog;

public class AuditLog
{
    public int AuditLogId { get; set; }
    public string? ActionType { get; set; }    
    public string? EntityName { get; set; }    
    public string? EntityId { get; set; }      
    public string? PerformedBy { get; set; }  
    public DateTime? Timestamp { get; set; }
    public string? Details { get; set; }     
}
