using DemoProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProj.Server.Controllers;

public interface IDepartmentController
{
    Task<List<DepartmentDB>> GetAll();
    Task<List<DepartmentDB>> GetByName(string name);
    Task<DepartmentDB> GetById(int id);
    void Add([FromBody] DepartmentDB department);
    void Delete(int id);
    void Edit([FromBody] DepartmentDB department, int id);
}