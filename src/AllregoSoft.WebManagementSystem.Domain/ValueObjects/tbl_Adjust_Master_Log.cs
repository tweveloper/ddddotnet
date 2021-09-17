using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.ValueObjects
{
    public class tbl_Adjust_Master_Log : ValueObject
    {
        // 고유번호 
        public long Id { get; private set; }

        public long AM_Id { get; private set; }

        // 변경내용 
        public string Msg { get; private set; }

        // 수정자 
        public long ModId { get; private set; }

        // 수정일 
        public DateTime ModDt { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return AM_Id;
            yield return Msg;
            yield return ModId;
            yield return ModDt;
        }
    }
}
