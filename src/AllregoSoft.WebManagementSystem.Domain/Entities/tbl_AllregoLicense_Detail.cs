using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_AllregoLicense_Detail : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // tbl_AllregoLicense id
        public long AlId { get; set; }

        // 해당코드 카테고리코드,브랜드코드 등등
        public string Mappingcd { get; set; }

        // Cate :카테고리 사용권 ,Brand: 브랜드사용권
        public string Ischeck { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}