using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_AllregoLicense : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // 사용권 이름 
        public string Subject { get; set; }

        // 사용일 30, 90
        public int Usedate { get; set; }

        // 삭제여부 
        public bool Isdelete { get; set; }

        // Cate :카테고리 사용권 ,Brand: 브랜드사용권
        public string Ischeck { get; set; }

        // 판매가 
        public decimal Price { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}