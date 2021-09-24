using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Product : AuditableEntity, IHasDomainEvent
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

        // 상품코드 
        public string Productcd { get; set; }

        // 과세 여부 
        public string Taxfl { get; set; }

        // 품절여부 
        public string Soldoutfl { get; set; }

        // 매입가 
        public decimal? Costprice { get; set; }

        // 공급가 
        public decimal? Supplyprice { get; set; }

        // 판매 제한가 
        public decimal? Limitprice { get; set; }

        // 판매가 
        public decimal? Saleprice { get; set; }

        // Request_Product Id
        public long RpId { get; set; }

        // 재고사용여부 재고 수량 차감 상품: Y, 무제한 상품 N
        public string Isstock { get; set; }

        public string Keyword { get; set; }

        // 상품 설명 
        public string Productdesc { get; set; }

        // 삭제여부 
        public string Delfl { get; set; }

        // 최소구매수량 
        public int Minordercnt { get; set; }

        // 최대구매수량 
        public int Maxordercnt { get; set; }

        // 할인전판매가(가라금액) 
        public decimal? Lieprice { get; set; }

        // 인플루언서 무료배송 그룹 상품가
        public decimal? Freegrpprice { get; set; }

        // 인플루언서 그룹 상품가
        public decimal? Infprice { get; set; }

        // 배송비정책번호 
        public int? Dlvno { get; set; }

        // 작성자 
        public long Regid { get; set; }

        // 작성일 
        public DateTime Regdt { get; set; }

        // 브랜드판매가 
        public decimal Brandsaleprice { get; set; }

        // 문화비 공제 여부 
        public string Culturefl { get; set; }

        public string Kcmarkinfo { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}