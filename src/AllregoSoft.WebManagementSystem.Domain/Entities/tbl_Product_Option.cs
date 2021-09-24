using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Product_Option : AuditableEntity, IHasDomainEvent
    {
        // 상품코드 
        public string Productcd { get; set; }

        // 옵션코드 
        public string Optioncd { get; set; }

        // Request_Product_Option Id
        public long? RpId { get; set; }

        public long? RpoId { get; set; }

        // 재고수량 
        public int? Stock { get; set; }

        public string Optval1 { get; set; }

        public string Optval2 { get; set; }

        public string Optval3 { get; set; }

        public string Optval4 { get; set; }

        public string Optval5 { get; set; }

        // 옵션노출여부 
        public string Optviewfl { get; set; }

        // 옵션판매여부 
        public string Optsellfl { get; set; }

        // 옵션품절여부 
        public string Optsoldoutfl { get; set; }

        // 옵션공급가 
        public decimal? Optsupplyprice { get; set; }

        // 고유번호 
        public long Id { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}