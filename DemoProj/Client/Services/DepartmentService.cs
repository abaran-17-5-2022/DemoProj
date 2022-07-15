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
            return await _httpClient.GetFromJsonAsync<List<Department>?>($"department/{name}");
        }
    }
}
