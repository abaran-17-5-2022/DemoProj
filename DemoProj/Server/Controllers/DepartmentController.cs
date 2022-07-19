using Dapper;
using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
    public List<Department> GetAll()
    {
        var sql = @"SELECT * FROM department";
        var connection = new SqlConnection(connectionString);

        var temp = connection.Query<Department>(sql).ToList();
        if (temp.Count > 0) return temp;
        return new List<Department>
        {
            new() { name = "No Data Found" }
        };                                                                                                
    }                                                                                                     
                                                                                                          
    [HttpGet("{name}")]                                                                                   
    public List<Department> GetByName(string name)                                                        
    {                                                                                                     
        var sql = @$"SELECT * FROM department WHERE name LIKE '%{name}%'";                                
        var connection = new SqlConnection(connectionString);                                             
        var temp = connection.Query<Department>(sql).ToList();                                            
        if (temp.Count > 0) return temp;                                                                  
        return new List<Department>                                                                       
        {                                                                                                 
            new() { name = "No Data Found" }                                                              
        };                                                                                                
    }

    [HttpGet("{Id:int}")]
    public async Task<Department> GetById(int id)
    {
        var sql = @$"SELECT * FROM department WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstOrDefaultAsync<Department>(sql);
    }

    [HttpPut]
    public void Add([FromBody] Department department)
    {
        var sql = @$"INSERT INTO department (Id, name) VALUES ({department.id}, '{department.name}')";
        var connection = new SqlConnection(connectionString);
        connection.Execute(sql);
    }

    [HttpDelete("{Id:int}")]
    public void Delete(int id)
    {
        var sql = @$"DELETE FROM department WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        connection.Execute(sql);
    }

    [HttpPut("{Id:int}")]
    public void Edit([FromBody] Department department, int id)
    {
        var sql = @$"UPDATE department SET name = '{department.name}' WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        connection.Execute(sql);
    }
}