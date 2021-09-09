using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Member : AuditableEntity
    {
        public long Id { get; set; }
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
        
        [Required]
        [Description("Identity FK")]
        public Guid IdentityId { get; set; }

        [Description("역할")]
        public List<tbl_Role> Roles { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
