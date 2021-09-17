using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Domain.ValueObjects
{
    public class tbl_Member_Log : ValueObject
    {
        // 고유번호 
        public long Id { get; private set; }

        // Member Id 
        public long MemId { get; private set; }

        // 변경내용 
        public string Msg { get; private set; }

        // 수정자 
        public long ModId { get; private set; }

        // 수정일 
        public DateTime ModDt { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return MemId;
            yield return Msg;
            yield return ModId;
            yield return ModDt;
        }
    }
}
