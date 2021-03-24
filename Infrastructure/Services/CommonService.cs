using GovernmentSystem.Application.Interfaces;
using System;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CommonService : ICommonService
    {
        public string GenerateUniqueIdentifier()
        {
            var identifier = "";

            var userCNP = $"{new Random().Next(0, 10)}" +
                $"{new Random().Next(0, 10)}{new Random().Next(0, 10)}{new Random().Next(0, 10)}" +
                $"{new Random().Next(0, 10)}{new Random().Next(0, 10)}";

            return identifier;
        }
    }
}
