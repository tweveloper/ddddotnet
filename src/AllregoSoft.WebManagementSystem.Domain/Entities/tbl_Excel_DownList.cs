using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Excel_DownList : AuditableEntity, IHasDomainEvent
    {
        public long Id { get; set; }

        // 화면 id 
        public long Viewid { get; set; }

        // Scm, Member
        public string Memtype { get; set; }

        public long Userid { get; set; }

        public string Excel { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}