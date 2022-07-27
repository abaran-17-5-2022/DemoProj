using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProj.Server.Controllers;

public interface IDepartmentController
{
    Task<List<Department>> GetAll();
    Task<List<Department>> GetByName(string name);
    Task<Department> GetById(int id);
    void Add([FromBody] Department department);
    void Delete(int id);
    void Edit([FromBody] Department department, int id);
}