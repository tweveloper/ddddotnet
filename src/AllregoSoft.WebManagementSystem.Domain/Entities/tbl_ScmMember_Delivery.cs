using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_ScmMember_Delivery : AuditableEntity, IHasDomainEvent
    {
        public long Id { get; set; }

        // scmmeber Id
        public long SMId { get; set; }

        // 0:출고지 1: 입고지
        public bool? DeliveryType { get; set; }

        public bool? IsDelete { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string AddressJi1 { get; set; }

        public string AddressJi2 { get; set; }

        // 우편번호 
        public string Post { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
