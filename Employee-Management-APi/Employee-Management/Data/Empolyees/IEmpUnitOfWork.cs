namespace Employee_Management.Data.Empolyees
{
    public interface IEmpUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        void Commit();
    }
}
