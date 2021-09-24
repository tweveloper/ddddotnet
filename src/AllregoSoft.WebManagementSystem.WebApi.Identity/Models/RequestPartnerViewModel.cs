using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Models
{
    public class RequestPartnerViewModel
    {
        // scm 요청 아이디 
        public string ScmId { get; set; }

        // 공급사 
        public string supplyNm { get; set; }

        // 업태 
        public string BusinessNm { get; set; }

        // 사업자번호 
        public string BusinessNum { get; set; }

        // 종목 
        public string Events { get; set; }

        // 대표명 
        public string Name { get; set; }

        // 전화번호 
        public string Telephone { get; set; }

        // 입금은행명 
        public string BankNm { get; set; }

        // 계좌번호 
        public string BankNum { get; set; }

        // 예금주 
        public string Depositor { get; set; }

        // 도로명주소 
        public string Address1 { get; set; }

        // 도로명상세주소 
        public string Address2 { get; set; }

        // 지번주소 
        public string AddressJi1 { get; set; }

        // 지번상세주소 
        public string AddressJi2 { get; set; }

        // 업체  담당자 
        public string SupplyPersonNm { get; set; }

        // 담당자 email 
        public string SupplyPersonMail { get; set; }

        // 담당자 연락처 
        public string SupplyPersonHP { get; set; }

        // 우편번호 
        public string Post { get; set; }

        // 입점타입 0 알리어 1 입점
        public bool isJoin { get; set; }
    }
}
