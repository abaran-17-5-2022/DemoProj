using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProj.Server.Controllers;

public interface IAddressController
{
    void Add([FromBody] Address address);
    void Delete(int id);
    void Edit([FromBody] Address address, int id);
    Task<List<Address>> GetAll();
    Task<Address> GetById(int id);
    Task<List<Address>> GetByName(string name);
}