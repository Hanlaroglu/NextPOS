using Licence.Helpers.Services;
using System;

namespace Licence.Helpers.Implementations
{
    public class LocalDateTimeService : IDateTimeService
    {
        public DateTime Current => DateTime.UtcNow.AddHours(4);
        public string CurrentString => DateTime.UtcNow.AddHours(4).ToString("dd.MM.yyyy");
    }
}