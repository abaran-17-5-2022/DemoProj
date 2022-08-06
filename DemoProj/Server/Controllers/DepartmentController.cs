using Dapper;
using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoProj.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : IDepartmentController
{
    private readonly string connectionString;

    public DepartmentController(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DemoProject");
    }

    [HttpGet]
    public async Task<List<DepartmentDB>> GetAll()
    {
        var sql = @"SELECT * FROM departmentnew";
        var connection = new SqlConnection(connectionString);

        var temp = (await connection.QueryAsync<DepartmentDB>(sql)).ToList();
        if (temp.Count > 0) return temp;
        return new List<DepartmentDB>
        {
            new() { dept_name = "No Data Found" }
        };
    }

    [HttpGet("search/{name}")]
    public async Task<List<DepartmentDB>> GetByName(string name)
    {
        var sql = @$"SELECT * FROM departmentnew WHERE dept_name LIKE '%{name}%'";
        var connection = new SqlConnection(connectionString);
        var temp = (await connection.QueryAsync<DepartmentDB>(sql)).ToList();
        if (temp.Count > 0) return temp;
        return new List<DepartmentDB>
        {
            new() { dept_name = "No Data Found" }
        };
    }

    [HttpGet("{Id:int}")]
    public async Task<DepartmentDB> GetById(int id)
    {
        var sql = @$"SELECT * FROM departmentnew WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstOrDefaultAsync<DepartmentDB>(sql);
    }

    [HttpPut]
    public async void Add([FromBody] DepartmentDB department)
    {
        var sql = @$"[dbo].[adddepartment]";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql, department, commandType: CommandType.StoredProcedure);
    }

    [HttpDelete("{Id:int}")]
    public async void Delete(int id)
    {
        var sql = @$"DELETE FROM departmentnew WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql);
    }

    [HttpPut("{Id:int}")]
    public async void Edit([FromBody] DepartmentDB department, int id)
    {
        var sql = @$"[dbo].[editdepartment]";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql, department, commandType: CommandType.StoredProcedure);
    }
}
