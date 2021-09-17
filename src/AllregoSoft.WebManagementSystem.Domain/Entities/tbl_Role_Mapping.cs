using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Role_Mapping : AuditableEntity, IHasDomainEvent
    {
        public long Id { get; set; }
        /// <summary>
        /// 역할고유번호
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Create
        /// </summary>
        public string C { get; set; }
        /// <summary>
        /// Read
        /// </summary>
        public string R { get; set; }
        /// <summary>
        /// Update
        /// </summary>
        public string U { get; set; }
        /// <summary>
        /// Delete
        /// </summary>
        public string D { get; set; }
        /// <summary>
        /// 특수권한1
        /// </summary>
        public string Auth1 { get; set; }
        /// <summary>
        /// 특수권한2
        /// </summary>
        public string Auth2 { get; set; }
        /// <summary>
        /// 메뉴고유번호
        /// </summary>
        public long SiteMapId { get; set; }

        [NotMapped]
        public string Path { get; set; }

        [ForeignKey("SiteMapId")]
        public virtual tbl_SiteMap SiteMap { get; set; }

        [ForeignKey("RoleId")]
        public virtual tbl_Role Role { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
