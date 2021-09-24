using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_AllregoLicense_Use_Log : IHasDomainEvent
    {
        public long Id { get; set; }

        public long AlId { get; set; }

        public long AluId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public DateTime Regdt { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}