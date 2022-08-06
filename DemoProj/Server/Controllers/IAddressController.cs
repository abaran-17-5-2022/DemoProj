using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProj.Server.Controllers;

public interface IAddressController
{
    void Add([FromBody] AddressDB address);
    void Delete(int id);
    void Edit([FromBody] AddressDB address, int id);
    Task<List<AddressDB>> GetAll();
    Task<AddressDB> GetById(int id);
    Task<List<AddressDB>> GetByName(string name);
}