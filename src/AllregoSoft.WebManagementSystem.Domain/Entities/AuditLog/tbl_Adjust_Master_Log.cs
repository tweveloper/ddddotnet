using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Adjust_Master_Log : IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        public long AmId { get; set; }

        // 변경내용 
        public string Msg { get; set; }

        // 수정자 
        public long Modid { get; set; }

        // 수정일 
        public DateTime Moddt { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}