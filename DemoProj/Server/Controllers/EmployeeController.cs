using Dapper;
using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DemoProj.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : IEmployeeController
{
    private readonly string connectionString;

    public EmployeeController(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DemoProject");
    }

    [HttpGet]
    public async Task<List<Employee>> GetAll()
    {
        var sql = @"SELECT * FROM employee";
        var connection = new SqlConnection(connectionString);

        var temp = (await connection.QueryAsync<Employee>(sql)).ToList();
        if (temp.Count > 0) return temp;
        return new List<Employee>
        {
            new() { Fname = "No Data Found" }
        };
    }

    [HttpGet("search/{name}")]
    public async Task<List<Employee>> GetByFname(string name)
    {
        var sql = @$"SELECT * FROM employee WHERE Fname LIKE '%{name}%' or Lname LIKE '%{name}%'";
        var connection = new SqlConnection(connectionString);
        var temp = (await connection.QueryAsync<Employee>(sql)).ToList();
        if (temp.Count > 0) return temp;
        return new List<Employee>
        {
            new() { Fname = "No Data Found" }
        };
    }

    [HttpGet("{Id:int}")]
    public async Task<Employee> GetById(int id)
    {
        var sql = @$"SELECT * FROM employee WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstOrDefaultAsync<Employee>(sql);
    }

    [HttpPut]
    public async void Add([FromBody] Employee employee)
    {
        var sql =
            @$"INSERT INTO employee (Id, Fname, Lname, DeptId, AddressId) VALUES ({employee.Id}, '{employee.Fname}', '{employee.Lname}', {employee.DeptId}, {employee.AddressId})";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql);
    }

    [HttpDelete("{Id:int}")]
    public async void Delete(int id)
    {
        var sql = @$"DELETE FROM employee WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql);
    }

    [HttpPut("{Id:int}")]
    public async void Edit([FromBody] Employee employee, int id)
    {
        var sql =
            @$"UPDATE employee SET Fname = '{employee.Fname}', Lname = '{employee.Lname}', DeptId = {employee.DeptId}, AddressId = {employee.AddressId} WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql);
    }
}