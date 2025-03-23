using System;
using System.ComponentModel;
using System.Reflection;

namespace Barcode_Sales.Helpers
{
    public static class Enums
    {
        /// <summary>
        /// Enumların desctriptionlarında yazılan yazıları geri string olaraq qaytarır
        /// </summary>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public enum TaxTypes
        {
            [Description("18% ƏDV")]
            EighteenPercent = 18,
            [Description("8% ƏDV")]
            EightPercent = 8,
            [Description("2% ƏDV")]
            TwoPercent = 2,
            [Description("0% - ( ƏDV-DƏN AZAD )")]
            ZeroPercent = 0,
            [Description("TİCARƏT ƏLAVƏSİ - 18%")]
            TradeSupplement = 2_18,
        }

        public enum NkaTaxType
        {
            [Description("18% ƏDV")]
            Vat18 = 1,
            [Description("TİCARƏT ƏLAVƏSİ - 18%")]
            TradeSupplement = 2,
            [Description("0% - ( ƏDV-DƏN AZAD )")]
            VatFree = 3,
            [Description("0% - ( ƏDV-DƏN AZAD )")]
            Vat0 = 5,
            [Description("2% ƏDV")]
            Sv2 = 6,
            [Description("8% ƏDV")]
            Sv8 = 7,
        }

        public enum UnitTypes
        {
            [Description("Ədəd")]
            Quantity,
            [Description("Kq")]
            Kq,
            [Description("Litr")]
            Litr,
            [Description("Metr")]
            Metr,
            [Description("Kv. Metr")]
            KvMeter,
            [Description("Kub. Metr")]
            CubeMeter,
        }

        public enum PayTypes
        {
            [Description("Nağd")]
            Cash,
            [Description("Kart")]
            Card,
            [Description("Nağd & Kart")]
            CashCard,
            [Description("Nisyə")]
            Free,
            [Description("Bank")]
            Bank,
        }

        public enum Weekdays
        {
            BazarErtəsi,
            ÇərşənbəAxşamı,
            Çərşənbə,
            CüməAxşamı,
            Cümə,
            Şənbə,
            Bazar
        }

        public enum MessageTitle
        {
            Mesaj,
            Xəbərdarlıq,
            Xəta,
            Bildiriş
        }

        public enum Operation
        {
            [Description("ƏLAVƏ ET")]
            Add,
            [Description("DÜZƏLİŞ ET")]
            Edit,
            [Description("ƏTRAFLI BAXIŞ")]
            Show,
            [Description("YADDA SAXLA")]
            Save,
            [Description("SİL")]
            Delete,
            [Description("YENİLƏ")]
            Refresh,
            [Description("BAĞLA")]
            Close,
            [Description("DEAKTİV ET")]
            Block,
            [Description("AKTİV ET")]
            Active,
            [Description("ÖDƏNİŞ ET")]
            Pay
        }

        public enum KassaOperator
        {
            SUNMI,
            OMNITECH,
            AZSMART,
            NBA,
            TIANYU,
            DATAPAY,
            ONECLİCK,
            XPRINTER
        }

        public enum BankTerminal
        {
            [Description("KAPİTAL BANK")]
            KapitalBank,
            [Description("PAŞA BANK")]
            PashaBank,
            [Description("ABB BANK")]
            AbbBank, 
            [Description("UNİBANK")]
            UniBank,
        }

        public enum PriceChangeOperation
        {
            PriceChange,
            Discount
        }
    }
}
