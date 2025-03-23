using Barcode_Sales.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barcode_Sales.Cache
{
    public class EnumsCache
    {
        public static readonly Dictionary<string,int> quantityType = Enum.GetValues(typeof(Enums.UnitTypes))
            .Cast<Enums.UnitTypes>()
            .ToDictionary(x=> x.ToString().ToLower(),x=> (int)x);


        public static readonly Dictionary<string, int> taxType = Enum.GetValues(typeof(Enums.NkaTaxType))
           .Cast<Enums.NkaTaxType>()
           .ToDictionary(x => x.ToString().ToLower(), x => (int)x);
    }
}
