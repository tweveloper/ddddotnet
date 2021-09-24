using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_CodeDetail : ValueObject
    {
        // CodeMain 고유번호 
        public string Codecd { get; set; }

        // 고유번호 
        public long Seq { get; set; }

        // 내용 
        public string Subject { get; set; }

        // 삭제여부 
        public string Delyn { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Codecd;
            yield return Seq;
            yield return Subject;
            yield return Delyn;
        }

    }
}