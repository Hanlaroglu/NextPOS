namespace Barcode_Sales.DTOs
{
    public class CustomerDto : Customer
    {
        public string GroupName { get; set; }
        public string UserNameSurname { get; set; }
        public string StatusText
        {
            get { return Status.GetValueOrDefault() ? "Aktiv" : "Deaktiv"; }
        }
    }
}
