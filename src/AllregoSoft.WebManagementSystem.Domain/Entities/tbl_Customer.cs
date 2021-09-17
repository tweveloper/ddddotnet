using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Customer : AuditableEntity, IHasDomainEvent
    {
        public long Id { get; set; }

        public string CustomId { get; set; }

        // 암호( 암호화) 
        public string CustomPw { get; set; }

        // 암호화테이블Id 
        public int KeyId { get; set; }

        // 성명 
        public string Name { get; set; }

        // 생일 
        public string Birth { get; set; }

        // 핸드폰번호 
        public string Hphone { get; set; }

        public string Email { get; set; }

        // tbl_Member id
        public long? M_Id { get; set; }

        // 사용여부(Y,N,H{휴먼}) 
        public string UseYn { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
