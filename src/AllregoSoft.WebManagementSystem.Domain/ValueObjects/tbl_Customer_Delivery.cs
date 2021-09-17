using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Customer_Delivery : ValueObject
    {
        // 고유번호 
        public long Id { get; private set; }

        // 주소명칭 집주소,회사주소 자주쓰는주소
        public string Subject { get; private set; }

        public string Address1 { get; private set; }

        public string Address2 { get; private set; }

        // 지번주소 
        public string AddressJi1 { get; private set; }

        // 지번상세주소 
        public string AddressJi2 { get; private set; }

        // 노출순번 
        public int? Seq { get; private set; }

        // tbl_Customer Id
        public long C_Id { get; private set; }

        // 우편번호 
        public string Post { get; private set; }

        // 자주쓰는 주소 
        public bool? IsCheck { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Subject;
            yield return Address1;
            yield return Address2;
            yield return AddressJi1;
            yield return AddressJi2;
            yield return Seq;
            yield return C_Id;
            yield return Post;
            yield return IsCheck;
        }
    }
}
