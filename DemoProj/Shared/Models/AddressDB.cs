using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProj.Shared.Models
{
    public class AddressDB
    {
        public int id { get; set; }
        public string street { get; set; } = "";
        public string state { get; set; } = "";
        public string country { get; set; } = "";
    }
}
