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

        public async Task AddEmployee(int id, Employee employee)
        {
            if (employee.Fname != "" && employee.Lname != "")
            {
                employee.Id = id;
                await _httpClient.PutAsJsonAsync("employee", employee);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            await _httpClient.DeleteAsync($"employee/{id}");
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"employee/{id}");
        }

        public async Task<List<Employee>?> GetEmployeeByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>($"employee/{name}");
        }

        public async Task<List<Employee>?> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("employee");
        }

        public async Task EditEmployee(int id, Employee employee)
        {
            if (employee.Fname != "" && employee.Lname != "")
            await _httpClient.PutAsJsonAsync($"employee/{id}", employee);
        }
    }
}
