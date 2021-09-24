using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Notice : AuditableEntity, IHasDomainEvent
    {
        public long Id { get; set; }

        // tbl_codeDetail 공지사항 종류 ( 1대1답변 , 전체 공지사항,브랜드 공지사항 등등)
        public string Isnotice { get; set; }

        public string Brandcd { get; set; }

        // 제목 
        public string Subject { get; set; }

        // 조회수 
        public int Readcount { get; set; }

        // 상단고정 
        public bool Istop { get; set; }

        // 노출여부 
        public bool Isdisplay { get; set; }

        // 삭제여부 
        public bool Isdelete { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}