using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProj.Shared.Models
{
    public class DepartmentDetails
    {
        public DepartmentDB department { get; set; } = new();
        public AddressDB address { get; set; } = new();
    }
}
