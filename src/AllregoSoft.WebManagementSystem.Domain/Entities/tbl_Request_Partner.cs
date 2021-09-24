using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public partial class tbl_Request_Partner : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // scm 요청 아이디 
        public string Scmid { get; set; }

        // scm 요청 비번 
        public string Scmpw { get; set; }

        // 공급사 
        public string Supplynm { get; set; }

        // 업태 
        public string Businessnm { get; set; }

        // 사업자번호 
        public string Businessnum { get; set; }

        // 종목 
        public string Events { get; set; }

        // 대표명 
        public string Name { get; set; }

        // 전화번호 
        public string Telephone { get; set; }

        // 입금은행명 
        public string Banknm { get; set; }

        // 계좌번호 
        public string Banknum { get; set; }

        // 예금주 
        public string Depositor { get; set; }

        // 도로명주소 
        public string Address1 { get; set; }

        // 도로명상세주소 
        public string Address2 { get; set; }

        // 지번주소 
        public string Addressji1 { get; set; }

        // 지번상세주소 
        public string Addressji2 { get; set; }

        // 사용여부 
        public string Useyn { get; set; }

        // 암호화테이블Id 
        public int Keyid { get; set; }

        // 업체  담당자 
        public string Supplypersonnm { get; set; }

        // 담당자 email 
        public string Supplypersonmail { get; set; }

        // 담당자 연락처 
        public string Supplypersonhp { get; set; }

        // 등록일 
        public DateTime Regdt { get; set; }

        // CdnUrl 
        public string Cdnurl1 { get; set; }

        public string Cdnurl2 { get; set; }

        // 우편번호 
        public string Post { get; set; }

        // 입점타입 0 알리어 1 입점
        public bool Isjoin { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}