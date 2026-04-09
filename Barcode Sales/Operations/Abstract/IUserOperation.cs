using System;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IUserOperation:IBaseOperation<User>
    {
        Tuple<bool, User, string> Authentication(string username, string password, bool saveMe = false);
    }
}