using Employee_Management.Models.AuditLog;
public class AuditService : IAuditService
{
    private readonly AppDbContext _context;

    public AuditService(AppDbContext context)
    {
        _context = context;
    }

    public void Log(string actionType, string entityName, string entityId, string performedBy, string details = null)
    {
        var log = new AuditLog
        {
            ActionType = actionType,
            EntityName = entityName,
            EntityId = entityId,
            PerformedBy = performedBy,
            Timestamp = DateTime.UtcNow,
            Details = details
        };

        _context.AuditLogs.Add(log);
        _context.SaveChanges();
    }

    public IEnumerable<AuditLog> GetAllLogs()
    {
        return _context.AuditLogs.OrderByDescending(l => l.Timestamp).ToList();
    }
}
