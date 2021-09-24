using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Mileage_Log : IHasDomainEvent
    {

        public long Id { get; set; }

        public int? Mileage { get; set; }

        // 사유 
        public string Msg { get; set; }

        // 지급,차감 
        public bool Isplus { get; set; }

        public long? Orderid { get; set; }

        public long? Orderdetailid { get; set; }

        public long Regid { get; set; }

        public DateTime Regdt { get; set; }

        // 사용자 구분 Custom, Scm
        public string Noticetype { get; set; }

        // 해당 적용 사용자 Id
        public long Memid { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}