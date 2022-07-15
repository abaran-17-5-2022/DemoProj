using Dapper;
using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DemoProj.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : IAddressController
{
    private readonly string connectionString =
        "Data Source=DESKTOP-CT6VF8I;Initial Catalog=DemoProject;Integrated Security=True;TrustServerCertificate=True";

    [HttpGet]
    public List<Address> GetAll()
    {
        var sql = @"SELECT * FROM address";
        var connection = new SqlConnection(connectionString);

        var temp = connection.Query<Address>(sql).ToList();
        if (temp.Count > 0) return temp;
        return new List<Address>
        {
            new() { address = "No Data Found" }
        };
    }

    [HttpGet("{name}")]
    public List<Address> GetByName(string name)
    {
        var sql = @$"SELECT * FROM address WHERE address LIKE '%{name}%'";
        var connection = new SqlConnection(connectionString);
        var temp = connection.Query<Address>(sql).ToList();
        if (temp.Count > 0) return temp;
        return new List<Address>
        {
            new() { address = "No Data Found" }
        };
    }

    [HttpGet("{Id:int}")]
    public async Task<Address> GetById(int id)
    {
        var sql = @$"SELECT * FROM address WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstOrDefaultAsync<Address>(sql);
    }

    [HttpPut]
    public void Add([FromBody] Address address)
    {
        var sql = @$"INSERT INTO address (Id, address) VALUES ({address.id}, '{address.address}')";
        var connection = new SqlConnection(connectionString);
        connection.Execute(sql);
    }

    [HttpDelete("{Id:int}")]
    public void Delete(int id)
    {
        var sql = @$"DELETE FROM address WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        connection.Execute(sql);
    }

    [HttpPut("{Id:int}")]
    public void Edit([FromBody] Address address, int id)
    {
        var sql = @$"UPDATE address SET address = '{address.address}' WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        connection.Execute(sql);
    }
}