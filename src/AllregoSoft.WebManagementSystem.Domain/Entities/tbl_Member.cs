using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Member : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // 롤 고유키 
        public int? RoleId { get; set; }

        // 등급 
        public int? Grade { get; set; }

        // 인플루언서마스터Id 
        public long? InfId { get; set; }

        // 핸드폰 
        public string Hphone { get; set; }

        // 입금은행명 
        public string BankNm { get; set; }

        // 계좌번호 
        public string BankNum { get; set; }

        // 예금주 
        public string Depositor { get; set; }

        // 사용여부(Y,N,H{휴먼}) 
        public string UseYn { get; set; }

        // 암호화테이블Id 
        public int KeyId { get; set; }

        // 브랜드 상품 연동 시작일
        public string Start_Date { get; set; }

        // 브랜드 상품 연동 종료일
        public string End_Date { get; set; }

        // 상품 전송 기준 일자
        public int? PrdBaseDate { get; set; }

        // 쇼핑몰 이름 
        public string ShopName { get; set; }

        // 쇼핑몰 주소 
        public string ShopUrl { get; set; }

        public DateTime OrderSaveDt { get; set; }

        // ap서버 연동주소 
        public string IpAddr { get; set; }

        // 이니시스상점아이디 
        public string IniShopId { get; set; }


        [Required]
        [Description("Identity FK")]
        public string IdentityId { get; set; }

        [Description("역할")]
        [ForeignKey("RoleId")]
        public tbl_Role Role { get; set; }
        
        [ForeignKey("InfId")]
        public tbl_Influencer_Master Influencer { get; set; }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}