using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProj.Shared.Models
{
    public class EmployeeDetails
    {
        public EmployeeDB employee { get; set; } = new();
        public DepartmentDB department { get; set; } = new();
        public AddressDB address { get; set; } = new();
    }
}
