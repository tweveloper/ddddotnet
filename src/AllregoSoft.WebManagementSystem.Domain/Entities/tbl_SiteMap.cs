using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public  class tbl_SiteMap : AuditableEntity, IHasDomainEvent
    {
        public tbl_SiteMap()
        {
            Clicked = false;
        }

        public long Id { get; set; }
        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 상위고유번호
        /// </summary>
        public long? Parent { get; set; }
        /// <summary>
        /// 차수
        /// </summary>
        public int Depth { get; set; }
        /// <summary>
        /// 순서
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 경로
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 설명
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 활성화
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// 상태
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 클릭된 사이트맵 위치 저장용
        /// </summary>
        [NotMapped]
        public bool Clicked { get; set; }
        [NotMapped]
        public long RoleId { get; set; }

        [ForeignKey("Parent")]
        public virtual tbl_SiteMap ParentMap { get; set; }
        public virtual IList<tbl_SiteMap> ChildMaps { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
