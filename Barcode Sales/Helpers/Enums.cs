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
            CASPOS,
            OMNITECH,
            AZSMART,
            NBA,
            DATAPAY,
            ONECLICK,
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

        public enum PosChangeType
        {
            PriceChange,
            Discount,
            Quantity,
            Deposit,
            Withdraw
        }

        public enum PosReturnType
        {
            MoneyBack, //Qaytarma
            Rollback //Ləğv etmə
        }

        public enum ProductType
        {
            [Description("Məhsul")]
            Product = 1,
            [Description("Xidmət")]
            Service
        }

        public enum Week
        {
            [Description("Bazar Ertəsi")]
            Monday,
            [Description("Çərşənbə axşamı")]
            Tuesday,
            [Description("Çərşənbə")]
            Wednesday,
            [Description("Cümə Axşamı")]
            Thursday,
            [Description("Cümə")]
            Friday,
            [Description("Şənbə")]
            Saturday,
            [Description("Bazar")]
            Sunday
        }

        public enum Month
        {
            [Description("Yanvar")]
            January = 1,
            [Description("Fevral")]
            February,
            [Description("Mart")]
            March,
            [Description("Aprel")]
            April,
            [Description("May")]
            May,
            [Description("İyun")]
            June,
            [Description("İyul")]
            July,
            [Description("Avqust")]
            August,
            [Description("Sentyabr")]
            September,
            [Description("Oktyabr")]
            Octember,
            [Description("Noyabr")]
            November,
            [Description("Dekabr")]
            December,
        }
    }
}
