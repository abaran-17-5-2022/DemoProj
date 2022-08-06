using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProj.Shared.Models
{
    public class EmployeeDB
    {
        public int id { get; set; }
        public string first_name { get; set; } = "";
        public string last_name { get; set; } = "";
        public string gender { get; set; } = "";
        public string email { get; set; } = "";
        public string phone_number { get; set; } = "";
        public int dept_id { get; set; }
        public int address_id { get; set; }
    }
}
