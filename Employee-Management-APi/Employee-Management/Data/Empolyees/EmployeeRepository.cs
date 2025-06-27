using Employee_Management.Models.Empolyee;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Data.Empolyees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() => _context.Employees.ToList();

        public Employee GetById(int id) => _context.Employees.Find(id);

        public void Add(Employee employee) => _context.Employees.Add(employee);

        public void Update(Employee employee)
        {
            var existing = _context.Employees.Find(employee.Id);
            if (existing != null)
            {
                employee.EmployeeCode = existing.EmployeeCode;

                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Position = employee.Position;
                existing.Salary = employee.Salary;
                existing.Currency = employee.Currency;
                existing.IsActive = employee.IsActive;

                _context.Employees.Update(existing);
            }
        }

        public void Delete(Employee employee)
        {
            var existing = _context.Employees.Find(employee.Id);
            if (existing != null)
                _context.Employees.Remove(existing);
        }

        public bool ExistsByCode(string employeeCode)
            => _context.Employees.Any(e => e.EmployeeCode == employeeCode);

        public IEnumerable<Employee> GetFiltered(string name, string position, decimal? minSalary, decimal? maxSalary)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(e =>
                    e.FirstName.Contains(name) ||
                    e.LastName.Contains(name));

            if (!string.IsNullOrWhiteSpace(position))
                query = query.Where(e =>
                    e.Position != null && e.Position.Equals(position));

            if (minSalary.HasValue)
                query = query.Where(e => e.Salary >= minSalary.Value);

            if (maxSalary.HasValue)
                query = query.Where(e => e.Salary <= maxSalary.Value);

            return query.ToList();
        }
    }
}
