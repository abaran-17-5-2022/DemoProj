using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProj.Shared.Models
{
    public class DepartmentDB
    {
        public int id { get; set; }
        public string dept_name { get; set; } = "";
        public string dept_phone { get; set; } = "";
        public string company_name { get; set; } = "";
        public string company_phone { get; set; } = "";
        public int address_id { get; set; }
    }
}
