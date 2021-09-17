using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Brand : AuditableEntity, IHasDomainEvent
    {
        // 브랜드코드 
        public string BrandCd { get; set; }

        // 브랜드명 
        public string BrandNm { get; set; }

        public string isDisp { get; set; }

        // 공급사 Id 
        public long SupId { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
