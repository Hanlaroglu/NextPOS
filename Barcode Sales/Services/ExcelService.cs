using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Services
{
    public class ExcelService
    {
        public List<string> GetSheetNames(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                return reader.AsDataSet()
                            .Tables
                            .Cast<DataTable>()
                            .Select(t => t.TableName)
                            .ToList();
            }
        }

        public DataTable GetSheetData(string filePath, string sheetName)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                return result.Tables[sheetName];

            }
        }
    }
}
