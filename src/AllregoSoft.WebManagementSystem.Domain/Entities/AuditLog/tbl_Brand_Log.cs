using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Brand_Log : IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // 브랜드코드 
        public string Brandcd { get; set; }

        // 변경 내용 
        public string Msg { get; set; }

        // 수정인id 
        public long Modid { get; set; }

        // 수정일 
        public DateTime Moddt { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}