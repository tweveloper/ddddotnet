using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.ValueObjects
{
    // APISERVICE 
    public class r2o_Cafe24_Code : ValueObject
    {
        // 고유번호 
        public int CODE_NO { get; private set; }

        public string CODE { get; private set; }

        public string STATE { get; private set; }

        // 몰 아이디
        public string MALL_ID { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CODE;
            yield return CODE_NO;
            yield return STATE;
            yield return MALL_ID;
        }
    }
}
