using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Collections.Generic;

namespace Barcode_Sales.Terminals.DTOs
{
    public class DefinitionDto
    {
        private static IUnitTypeOperation unitTypeOperation = new UnitTypeManager();
        private static ITaxTypeOperation taxeOperation = new TaxTypeManager();

        private static readonly Lazy<Dictionary<int, string>> _units =
            new Lazy<Dictionary<int, string>>(() => unitTypeOperation.Initialize());

        private static readonly Lazy<Dictionary<int, (string Name, decimal VatPercent)>> _taxes =
            new Lazy<Dictionary<int, (string Name, decimal VatPercent)>>(() => taxeOperation.Initialize());

        public static string GetUnitName(int Id)
        {
            return _units.Value.TryGetValue(Id, out var name) ? name : null;
        }

        public static string GetTaxName(int Id)
        {
            return _taxes.Value.TryGetValue(Id, out var tax) ? tax.Name : null;
        }

        public static decimal GetVatPercent(int id)
        {
            return _taxes.Value.TryGetValue(id, out var tax) ? tax.VatPercent : 0;
        }
    }
}
