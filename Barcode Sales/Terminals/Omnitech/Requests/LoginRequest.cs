using Barcode_Sales.Terminals.Omnitech.Models;

namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class LoginRequest 
    {
        public CheckData checkData { get; set; } = new CheckData { check_type = Enums.OmnitechCheckType.Login };
        public string name { get; set; } = "SuperApi";
        public string password { get; set; } = "123";
    }
}
