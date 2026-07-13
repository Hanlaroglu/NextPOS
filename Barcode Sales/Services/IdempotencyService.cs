using System;
using System.Collections.Concurrent;
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Services
{
    public static class IdempotencyService
    {
        private static readonly ConcurrentDictionary<IdempotencyOperation, Guid> _keys = new ConcurrentDictionary<IdempotencyOperation, Guid>();

        public static Guid GetOrCreate(IdempotencyOperation operation)
        {
            return _keys.GetOrAdd(operation, _ => Guid.NewGuid());
        }

        public static void Complete(IdempotencyOperation operation)
        {
            _keys.TryRemove(operation, out _);
        }

        /* Kullanımı
         *
         *  var key = IdempotencyService.GetOrCreate(IdempotencyOperation.PosSale);

            await _terminalApi.SendAsync(request, key);

            IdempotencyService.Complete(IdempotencyOperation.PosSale);
         *
         *
         */
    }
}
