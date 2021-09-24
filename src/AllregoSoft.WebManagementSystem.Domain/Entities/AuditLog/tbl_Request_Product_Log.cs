using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Request_Product_Log : IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // tbl_Product_Image Id
        public long RpId { get; set; }

        public string Msg { get; set; }

        public long Modid { get; set; }

        public DateTime Moddt { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}