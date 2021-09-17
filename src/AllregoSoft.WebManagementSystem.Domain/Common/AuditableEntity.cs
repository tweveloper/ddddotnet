using System;

namespace AllregoSoft.WebManagementSystem.Domain.Common
{
    public abstract class AuditableEntity
    {
        // 등록인id 
        public long RegId { get; set; }

        // 등록일 
        public DateTime RegDt { get; set; }

        // 수정인id 
        public long? ModId { get; set; }

        // 수정일 
        public DateTime? ModDt { get; set; }
    }
}
