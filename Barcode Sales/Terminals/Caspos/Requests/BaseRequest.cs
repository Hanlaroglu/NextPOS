namespace Barcode_Sales.Terminals.Caspos.Requests
{
    public class BaseRequest<T> where T: class
    {
        public T data { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public static BaseRequest<T> Create(T data)
        {
            return new BaseRequest<T>
            {
                data = data,
                username = "username",
                password = "password"
            };
        }
    }
}
