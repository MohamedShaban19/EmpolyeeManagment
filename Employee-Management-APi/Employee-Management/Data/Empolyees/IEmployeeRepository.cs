using Employee_Management.Models.Empolyee;
using System.Collections.Generic;

namespace Employee_Management.Data.Empolyees
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        bool ExistsByCode(string employeeCode);
        IEnumerable<Employee> GetFiltered(string name, string position, decimal? minSalary, decimal? maxSalary);
    }
}
