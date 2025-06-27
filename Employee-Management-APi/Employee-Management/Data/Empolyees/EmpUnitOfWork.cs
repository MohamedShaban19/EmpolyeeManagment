using Employee_Management.Models.Empolyee;

namespace Employee_Management.Data.Empolyees
{
    public class EmpUnitOfWork : IEmpUnitOfWork
    {
        private readonly AppDbContext _context;
        public EmpUnitOfWork(AppDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
        }

        public IEmployeeRepository Employees { get; }

        public void Commit() => _context.SaveChanges();
    }
}
