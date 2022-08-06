using DemoProj.Shared.Models;
using System.Net.Http.Json;

namespace DemoProj.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepartmentDB>?> GetDepartments()
        {
            return await _httpClient.GetFromJsonAsync<List<DepartmentDB>?>("department");
        }

        public async Task<List<DepartmentDB>?> GetDepartmentsByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<DepartmentDB>>($"department/search/{name}");
        }

        public async Task<DepartmentDB?> GetDepartmentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<DepartmentDB?>($"department/{id}");
        }

        public async Task AddDepartment(DepartmentDB department)
        {
            if (department.dept_name != "")
            await _httpClient.PutAsJsonAsync("department", department);
        }

        public async Task DeleteDepartment(int id)
        {
            await _httpClient.DeleteAsync($"department/{id}");
        }

        public async Task EditDepartment(int id, DepartmentDB department)
        {
            if (department.dept_name != "")
            await _httpClient.PutAsJsonAsync($"department/{id}", department);
        }
    }
}
