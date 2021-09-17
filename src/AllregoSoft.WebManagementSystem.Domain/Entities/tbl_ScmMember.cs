using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_ScmMember : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // 공급사아이디 
        public string ScmId { get; set; }

        // 롤 고유키 
        public int? RoleId { get; set; }

        // 등급 
        public int? Grade { get; set; }

        // Request_Partner Id 
        public long? RPId { get; set; }

        // 성명 
        public string Name { get; set; }

        // 핸드폰 
        public string Hphone { get; set; }

        // 사용여부 
        public string UseYn { get; set; }

        // 암호화테이블Id 
        public int KeyId { get; set; }

        public int? Point { get; set; }

        public int? Mileage { get; set; }
        [ForeignKey("RoleId")]
        public tbl_Role Role { get; set; }
        /// <summary>
        /// 인증정보 FK
        /// </summary>
        public string IdentityId { get; set; }
        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
