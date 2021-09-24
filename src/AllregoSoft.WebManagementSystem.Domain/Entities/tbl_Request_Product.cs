using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Request_Product : AuditableEntity, IHasDomainEvent
    {
        // 상품 고유키 
        public long Id { get; set; }

        // ScmMember Id 
        public long ScmId { get; set; }

        // 브랜드코드 
        public string Brandcd { get; set; }

        // 카테고리코드 
        public string Catecd { get; set; }

        // 상품명 
        public string Productnm { get; set; }

        // 노출여부 
        public string Dispfl { get; set; }

        // 판매여부 
        public string Sellfl { get; set; }

        // 원산지 
        public string Originnm { get; set; }

        // 과세 여부 
        public string Taxfl { get; set; }

        // 품절여부 
        public string Soldoutfl { get; set; }

        // 공급가 
        public decimal? Supplyprice { get; set; }

        // 판매 제한가 
        public decimal? Limitprice { get; set; }

        // 판매가 
        public decimal Brandsaleprice { get; set; }

        // 상품등록승인여부 
        public string Isapprove { get; set; }

        public string Isstock { get; set; }

        // 삭제여부 
        public string Delfl { get; set; }

        public int? Minordercnt { get; set; }

        public int? Maxordercnt { get; set; }

        // 상품 설명 
        public string Productdesc { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}