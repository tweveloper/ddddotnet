using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Notice_Detail : AuditableEntity, IHasDomainEvent
    {
        public long Id { get; set; }

        // tbl_Notice id
        public long Nid { get; set; }

        public int? Depth { get; set; }

        // tbl_Notice_Detail 상위 답변 id
        public long? Ownid { get; set; }

        // 내용 
        public string Content { get; set; }

        // 삭제여부 
        public bool Isdelete { get; set; }

        // 첨부파일 FK 
        public long? Entitystorageid { get; set; }

        // Custom :고객 Scm :파트너( Brand, 알리어)
        public string Noticetype { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}