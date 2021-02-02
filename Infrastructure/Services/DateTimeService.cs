using GovernmentSystem.Application.Common.Interfaces;
using System;

namespace GovernmentSystem.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
