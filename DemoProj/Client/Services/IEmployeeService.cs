using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>?> GetEmployees();

        Task<List<Employee>?> GetEmployeeByName(string name);

        Task<Employee?> GetEmployeeById(int id);

        Task AddEmployee(int id, Employee employee);

        Task DeleteEmployee(int id);

        Task EditEmployee(int id, Employee employee);
    }
}