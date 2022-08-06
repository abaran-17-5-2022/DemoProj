using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDB>?> GetEmployees();

        Task<List<EmployeeDB>?> GetEmployeesByName(string name);

        Task<EmployeeDB?> GetEmployeeById(int id);

        Task AddEmployee(EmployeeDB employee);

        Task DeleteEmployee(int id);

        Task EditEmployee(int id, EmployeeDB employee);
    }
}