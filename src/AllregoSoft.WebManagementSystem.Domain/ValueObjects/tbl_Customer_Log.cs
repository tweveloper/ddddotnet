using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Domain.ValueObjects
{
    public class tbl_Customer_Log : ValueObject
    {
        public long Id { get; private set; }

        // tbl_Customer Id
        public long C_Id { get; private set; }

        // 변경내용 
        public string Msg { get; private set; }

        // 수정자 
        public long ModId { get; private set; }

        // 수정일 
        public DateTime ModDt { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return C_Id;
            yield return Msg;
            yield return ModId;
            yield return ModDt;
        }
    }
}
