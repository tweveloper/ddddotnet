using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using System;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
