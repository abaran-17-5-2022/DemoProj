using Dapper;
using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

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
    public async Task<List<EmployeeDB>> GetAll()
    {
        var sql = @"[dbo].[allemployees]";
        var connection = new SqlConnection(connectionString);

        var temp = (await connection.QueryAsync<EmployeeDB>(sql, commandType: CommandType.StoredProcedure)).ToList();
        if (temp.Count > 0) return temp;
        return new List<EmployeeDB>
        {
            new() { first_name = "No Data Found" }
        };
    }

    [HttpGet("search/{name}")]
    public async Task<List<EmployeeDB>> GetByFname(string name)
    {
        var sql = @$"[dbo].[employeebyname]";
        var connection = new SqlConnection(connectionString);
        var temp = (await connection.QueryAsync<EmployeeDB>(sql, new { name = name}, commandType: CommandType.StoredProcedure)).ToList();
        if (temp.Count > 0) return temp;
        return new List<EmployeeDB>
        {
            new() { first_name = "No Data Found" }
        };
    }

    [HttpGet("{Id:int}")]
    public async Task<EmployeeDB> GetById(int id)
    {
        var sql = @$"[dbo].[employeebyid]";
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstOrDefaultAsync<EmployeeDB>(sql, new { id = id }, commandType: CommandType.StoredProcedure);
    }

    [HttpPut]
    public async void Add([FromBody] EmployeeDB employee)
    {
        var sql = $@"[dbo].[addemployee]";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql, employee, commandType: CommandType.StoredProcedure);
    }

    [HttpDelete("{Id:int}")]
    public async void Delete(int id)
    {
        var sql = @$"[dbo].[deleteemployee]";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql, new { id = id }, commandType: CommandType.StoredProcedure);
    }

    [HttpPut("{Id:int}")]
    public async void Edit([FromBody] EmployeeDB employee, int id)
    {
        var sql = @$"[dbo].[editemployee]";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql, employee, commandType: CommandType.StoredProcedure);
    }
}