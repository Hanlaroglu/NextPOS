using Licence.Helpers.Services;
using System;

namespace Licence.Helpers.Implementations
{
    public class GuidGeneratorService: IGuidKeyService
    {
        public Guid Current => Guid.NewGuid();
        public string CurrentString => Guid.NewGuid().ToString();
    }
}