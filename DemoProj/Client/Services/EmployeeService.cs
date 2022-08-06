using DemoProj.Shared.Models;
using System.Net.Http.Json;

namespace DemoProj.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddEmployee(EmployeeDB employee)
        {
            if (employee.first_name != "" && employee.last_name != "")
            {
                await _httpClient.PutAsJsonAsync("employee", employee);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            await _httpClient.DeleteAsync($"employee/{id}");
        }

        public async Task<EmployeeDB?> GetEmployeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<EmployeeDB>($"employee/{id}");
        }

        public async Task<List<EmployeeDB>?> GetEmployeesByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeDB>>($"employee/search/{name}");
        }

        public async Task<List<EmployeeDB>?> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeDB>>("employee");
        }

        public async Task EditEmployee(int id, EmployeeDB employee)
        {
            if (employee.first_name != "" && employee.last_name != "")
            await _httpClient.PutAsJsonAsync($"employee/{id}", employee);
        }
    }
}
