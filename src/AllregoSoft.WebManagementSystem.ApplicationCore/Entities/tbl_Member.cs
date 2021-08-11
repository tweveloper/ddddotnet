using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities
{
    public partial class tbl_Member : BaseEntity, IAggregateRoot
    {
        public tbl_Member()
        {
            //Role = new HashSet<tbl_Role>();
        }

        /// <summary>
        /// 계정
        /// </summary>
        [Required]
        [Description("계정")]
        public string Account { get; set; }
        /// <summary>
        /// 패스워드
        /// </summary>
        [Description("패스워드")]
        public string Password { get; set; }
        /// <summary>
        /// 이름
        /// </summary>
        [Required]
        [Description("이름")]
        public string Name { get; set; }
        /// <summary>
        /// 핸드폰
        /// </summary>
        [Description("핸드폰")]
        public string HP { get; set; }
        /// <summary>
        /// 핸드폰 수신여부
        /// </summary>
        [Description("핸드폰 수신여부")]
        public string smsFl { get; set; }
        /// <summary>
        /// 이메일
        /// </summary>
        [Description("이메일")]
        public string Email { get; set; }
        /// <summary>
        /// 이메일 수신여부
        /// </summary>
        [Description("이메일 수신여부")]
        public string maillingFl { get; set; }
        /// <summary>
        /// 사용여부
        /// </summary>
        [Required]
        [Description("사용여부")]
        public string UseYN { get; set; }
        /// <summary>
        /// 역할고유번호
        /// </summary>
        [Description("역할고유번호(FK)")]
        public long? RoleId { get; set; }
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

        [InverseProperty("Member")]
        [ForeignKey("RoleId")]
        public virtual tbl_Role Role { get; set; }
    }
}