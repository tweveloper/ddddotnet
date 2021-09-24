using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_PaymentList : AuditableEntity, IHasDomainEvent
    {
        public long Id { get; set; }

        public string Subject { get; set; }

        // 무통장 
        public bool Nonepassbook { get; set; }

        // 신용카드 
        public bool Creditcard { get; set; }

        // 계좌이체 
        public bool Accounttransfer { get; set; }

        // 휴대폰 
        public bool Hppay { get; set; }

        // 카카오페이 
        public bool Kakaopay { get; set; }

        // 네이버페이 
        public bool Naverpay { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}