using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.ValueObjects
{
    public class tbl_Brand_Log : ValueObject
    {
        // 고유번호 
        public long Id { get; private set; }

        // 브랜드코드 
        public string BrandCd { get; private set; }

        // 변경 내용 
        public string Msg { get; private set; }

        // 수정자 
        public long ModId { get; private set; }

        // 수정일 
        public DateTime ModDt { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return BrandCd;
            yield return Msg;
            yield return ModId;
            yield return ModDt;
        }
    }
}
