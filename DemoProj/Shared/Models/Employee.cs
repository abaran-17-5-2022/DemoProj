namespace DemoProj.Shared.Models;

public class Employee
{
    public int Id { get; set; }
    public string Fname { get; set; } = "";
    public string Lname { get; set; } = "";
    public int DeptId { get; set; }
    public int AddressId { get; set; }
}