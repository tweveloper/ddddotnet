using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Request_Product_Option : AuditableEntity, IHasDomainEvent
    {
        // 옵션 고유번호 
        public long Id { get; set; }

        public string Brandcd { get; set; }

        public long RpId { get; set; }

        public string Optval1 { get; set; }

        public string Optval2 { get; set; }

        public string Optval3 { get; set; }

        public string Optval4 { get; set; }

        public string Optval5 { get; set; }

        // 옵션금액 
        public decimal? Optprice { get; set; }

        // 판매 제한가 
        public decimal? Optlimitprice { get; set; }

        // 옵션공급가 
        public decimal? Optsupplyprice { get; set; }

        // 재고수량 
        public int Stock { get; set; }


        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}