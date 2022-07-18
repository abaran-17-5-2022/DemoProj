using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>?> GetDepartments();
        Task<Department?> GetDepartmentById(int id);
        Task<List<Department>?> GetDepartmentsByName(string name);
        Task AddDepartment(Department department);
        Task DeleteDepartment(int id);
        Task EditDepartment(int id, Department department);
    }
}