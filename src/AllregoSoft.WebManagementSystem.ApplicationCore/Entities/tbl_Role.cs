using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities
{
    public class tbl_Role : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 상태
        /// </summary>
        public string State { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<tbl_Role_Mapping> RoleMapping { get; set; }

        ///// <summary>
        ///// 등록자
        ///// </summary>
        //[Required]
        //public int RegMemId { get; set; }
        ///// <summary>
        ///// 등록일
        ///// </summary>
        //[Required]
        //public DateTime RegDate { get; set; }
        ///// <summary>
        ///// 수정자
        ///// </summary>
        //public int? ModMemId { get; set; }
        ///// <summary>
        ///// 수정일
        ///// </summary>
        //public DateTime? ModDate { get; set; }
    }
}
