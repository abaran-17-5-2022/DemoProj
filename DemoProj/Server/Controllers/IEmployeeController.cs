using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProj.Server.Controllers;

public interface IEmployeeController
{
    Task<List<EmployeeDB>> GetAll();
    Task<List<EmployeeDB>> GetByFname(string name);
    Task<EmployeeDB> GetById(int id);
    void Add([FromBody] EmployeeDB employee);
    void Delete(int id);
    void Edit([FromBody] EmployeeDB employee, int id);
}