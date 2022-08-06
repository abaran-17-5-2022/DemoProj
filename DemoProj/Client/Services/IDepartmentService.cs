using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDB>?> GetDepartments();
        Task<DepartmentDB?> GetDepartmentById(int id);
        Task<List<DepartmentDB>?> GetDepartmentsByName(string name);
        Task AddDepartment(DepartmentDB department);
        Task DeleteDepartment(int id);
        Task EditDepartment(int id, DepartmentDB department);
    }
}