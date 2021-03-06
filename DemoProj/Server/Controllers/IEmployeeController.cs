using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProj.Server.Controllers;

public interface IEmployeeController
{
    List<Employee> GetAll();
    List<Employee> GetByFname(string name);
    Task<Employee> GetById(int id);
    void Add([FromBody] Employee employee);
    void Delete(int id);
    void Edit([FromBody] Employee employee, int id);
}