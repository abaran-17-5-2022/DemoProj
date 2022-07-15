using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>?> GetEmployees();

        Task<List<Employee>?> GetEmployeeByName(string name);

        Task AddEmployee(int id, Employee employee);

        Task DeleteEmployee(int id);
    }
}