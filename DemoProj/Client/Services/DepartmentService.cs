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

        public async Task<List<Department>?> GetDepartments()
        {
            return await _httpClient.GetFromJsonAsync<List<Department>?>("department");
        }

        public async Task<List<Department>?> GetDepartmentsByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<Department>>($"department/search/{name}");
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department?>($"department/{id}");
        }

        public async Task AddDepartment(Department department)
        {
            if (department.name != "")
            await _httpClient.PutAsJsonAsync("department", department);
        }

        public async Task DeleteDepartment(int id)
        {
            await _httpClient.DeleteAsync($"department/{id}");
        }

        public async Task EditDepartment(int id, Department department)
        {
            if (department.name != "")
            await _httpClient.PutAsJsonAsync($"department/{id}", department);
        }
    }
}
