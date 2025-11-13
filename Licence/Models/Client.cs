using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Models
{
    public class Client
    {
        public bool IsActive { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string Voen { get; set; }
        public string CompanyCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        public string TerminalModel { get; set; }
        public string TerminalSerialNumber { get; set; }
        public string Version { get; set; }
        public DateTime LicenceExpireDate { get; set; }
        public string Message { get; set; } = null;
    }
}
