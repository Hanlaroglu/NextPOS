namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class BaseRequest<T> where T: class
    {
        public T requestData { get; set; }

        public static BaseRequest<T> Create(T data)
        {
            return new BaseRequest<T>
            {
                requestData = data
            };
        }
    }
}