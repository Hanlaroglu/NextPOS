using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Barcode_Sales.Helpers
{
    public static class EnumExtensions
    {
        private static readonly Dictionary<Enum, string> _cache = new Dictionary<Enum, string>();

        public static string GetDescriptionCached(this Enum value)
        {
            if (_cache.TryGetValue(value, out var desc))
                return desc;

            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();

            desc = attr?.Description ?? value.ToString();
            _cache[value] = desc;

            return desc;
        }

        /// <summary>
        /// Enumların desctriptionlarında yazılan yazıları geri string olaraq qaytarır
        /// </summary>
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
