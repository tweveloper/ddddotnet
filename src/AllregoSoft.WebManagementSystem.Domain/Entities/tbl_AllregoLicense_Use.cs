using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_AllregoLicense_Use : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        public long AlId { get; set; }

        // 시작일 
        public string StartDate { get; set; }

        // 종료일 
        public string EndDate { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}