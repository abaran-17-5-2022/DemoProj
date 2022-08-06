using Dapper;
using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DemoProj.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : IAddressController
{
    private readonly string connectionString;

    public AddressController(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DemoProject");
    }

    [HttpGet]
    public async Task<List<AddressDB>> GetAll()
    {
        var sql = @"SELECT * FROM addressnew";
        var connection = new SqlConnection(connectionString);

        var temp = (await connection.QueryAsync<AddressDB>(sql)).ToList();
        if (temp.Count > 0) return temp;
        return new List<AddressDB>
        {
            new() { state = "No Data Found" }
        };
    }

    [HttpGet("search/{name}")]
    public async Task<List<AddressDB>> GetByName(string name)
    {
        var sql = @$"SELECT * FROM addressnew WHERE street + state + country LIKE '%{name}%'";
        var connection = new SqlConnection(connectionString);
        var temp = (await connection.QueryAsync<AddressDB>(sql)).ToList();
        if (temp.Count > 0) return temp;
        return new List<AddressDB>
        {
            new() { state = "No Data Found" }
        };
    }

    [HttpGet("{Id:int}")]
    public async Task<AddressDB> GetById(int id)
    {
        var sql = @$"SELECT * FROM addressnew WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        return await connection.QueryFirstOrDefaultAsync<AddressDB>(sql);
    }

    [HttpPut]
    public async void Add([FromBody] AddressDB address)
    {
        var sql = @$"INSERT INTO addressnew (street, state, country) VALUES ('{address.street}', '{address.state}', '{address.country}')";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql);
    }

    [HttpDelete("{Id:int}")]
    public async void Delete(int id)
    {
        var sql = @$"DELETE FROM addressnew WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql);
    }

    [HttpPut("{Id:int}")]
    public async void Edit([FromBody] AddressDB address, int id)
    {
        var sql = @$"UPDATE addressnew SET 
        street = '{address.street}',
        state = '{address.state}',
        country = '{address.country}' WHERE Id = {id}";
        var connection = new SqlConnection(connectionString);
        await connection.ExecuteAsync(sql);
    }
}