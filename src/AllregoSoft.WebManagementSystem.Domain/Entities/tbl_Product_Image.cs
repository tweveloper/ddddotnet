using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Product_Image : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // Main,Thumbnail
        public string Subject { get; set; }

        // Request_Product id
        public long RpId { get; set; }

        // tbl_Product Id
        public long? Productid { get; set; }

        // cdn 주소 
        public string Cdnurl { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}