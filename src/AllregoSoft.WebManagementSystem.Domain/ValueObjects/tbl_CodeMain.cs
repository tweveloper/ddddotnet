using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_CodeMain : ValueObject
    {
        // 고유번호 
        public string Codecd { get; set; }

        // 제목 
        public string Subject { get; set; }

        // 사용여부 
        public string Useyn { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Codecd;
            yield return Subject;
            yield return Useyn;
        }
    }
}