using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public  class tbl_SiteMap : AuditableEntity
    {
        public long Id { get; set; }
        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 상위고유번호
        /// </summary>
        public long Parent { get; set; }
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
    }
}
