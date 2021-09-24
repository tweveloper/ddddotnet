using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_AllregoLicense_Log : IHasDomainEvent
    {
        public long Id { get; set; }

        public long AlId { get; set; }

        public string Msg { get; set; }

        public long Modid { get; set; }

        public DateTime Moddt { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}