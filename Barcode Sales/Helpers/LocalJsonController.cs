using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Helpers
{
    public static class LocalJsonController
    {
        private static readonly string JsonFilePath = $"{Application.StartupPath}\\controller.json";

        public static RootObject ReadJsonData()
        {
            if (!File.Exists(JsonFilePath))
            {
                return new RootObject
                {
                    Controller = new List<JsonController>()
                };
            }


                // JSON dosyasını okuyarak veriyi geri döndür
                string json = File.ReadAllText(JsonFilePath);
                return JsonConvert.DeserializeObject<RootObject>(json);
        }

        public static void WriteJsonData(RootObject data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(JsonFilePath, json);
        }

        public static void AddOrUpdateCompany(JsonController newCompany)
        {
            // JSON dosyasındaki mevcut veriyi okuyun
            RootObject jsonData = ReadJsonData();

            // Eğer aynı Voen ile bir şirket varsa güncelle, yoksa yeni ekle
            var existingCompany = jsonData.Controller.Find(c => c.Voen == newCompany.Voen);
            if (existingCompany != null)
            {
                existingCompany.CompanyName = newCompany.CompanyName;
                existingCompany.ContractNo = newCompany.ContractNo;
                existingCompany.RegistrationDate = newCompany.RegistrationDate;
                existingCompany.LogoImage = newCompany.LogoImage;
            }
            else
            {
                jsonData.Controller.Add(newCompany);
            }

            // JSON dosyasına güncellenmiş veriyi yazın
            WriteJsonData(jsonData);
        }
    }

    public class JsonController
    {
        public string CompanyName { get; set; }
        public string Voen { get; set; }
        public string ContractNo { get; set; }
        public string RegistrationDate { get; set; }
        public byte[] LogoImage { get; set; }
    }

    public class RootObject
    {
        public List<JsonController> Controller { get; set; }
    }
}
