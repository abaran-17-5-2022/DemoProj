using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>?> GetDepartments();
        Task<List<Department>?> GetDepartmentsByName(string name);
    }
}