using System;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System.Collections.Generic;

namespace Barcode_Sales.DTOs
{
    public static class DefinitionDto
    {
        private static IUnitTypeOperation unitTypeOperation = new UnitTypeManager();
        private static ITaxTypeOperation taxeOperation = new TaxTypeManager();

        private static readonly Lazy<Dictionary<int, string>> _units =
            new Lazy<Dictionary<int, string>>(() => unitTypeOperation.Initialize());

        private static readonly Lazy<Dictionary<int, string>> _taxes =
            new Lazy<Dictionary<int, string>>(() => taxeOperation.Initialize());


        public static string GetUnitName(int Id)
        {
            return _units.Value.TryGetValue(Id, out var name) ? name : null;
        }

        public static string GetTaxName(int Id)
        {
            return _taxes.Value.TryGetValue(Id, out var name) ? name : null;
        }
    }
}
