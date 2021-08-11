using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities
{
    public class tbl_Role_Mapping : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 역할고유번호
        /// </summary>
        public long RoleId { get; set; }
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

        [InverseProperty("SiteMapping")]
        [ForeignKey("SiteMapId")]
        public virtual tbl_SiteMap SiteMap { get; set; }

        [InverseProperty("RoleMapping")]
        [ForeignKey("RoleId")]
        public virtual tbl_Role Role { get; set; }

        //[Display(Name = "등록자"), Required]
        //public int RegMemId { get; set; }
        //[Display(Name = "등록일시"), Required]
        //public DateTime RegDate { get; set; }
    }
}
