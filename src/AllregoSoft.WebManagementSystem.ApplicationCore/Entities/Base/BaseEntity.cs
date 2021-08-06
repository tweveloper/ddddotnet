using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        [Description("고유번호(PK)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; protected set; }
        /// <summary>
        /// 등록자
        /// </summary>
        [Required]
        public virtual long RegMemId { get; set; }
        /// <summary>
        /// 등록일
        /// </summary>
        [Required]
        public virtual DateTime RegDate { get; set; }
        /// <summary>
        /// 수정자
        /// </summary>
        public virtual int? ModMemId { get; set; }
        /// <summary>
        /// 수정일
        /// </summary>
        public virtual DateTime? ModDate { get; set; }
    }
}
