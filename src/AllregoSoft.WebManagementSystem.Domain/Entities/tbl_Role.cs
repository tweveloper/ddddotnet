using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Role : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 상태
        /// </summary>
        public string State { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
