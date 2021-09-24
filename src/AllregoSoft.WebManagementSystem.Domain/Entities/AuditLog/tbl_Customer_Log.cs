using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Customer_Log : IHasDomainEvent
    {
        public long Id { get; set; }

        // tbl_Customer Id
        public long CId { get; set; }

        // 변경내용 
        public string Msg { get; set; }

        // 수정자 
        public long Modid { get; set; }

        // 수정일 
        public DateTime Moddt { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}