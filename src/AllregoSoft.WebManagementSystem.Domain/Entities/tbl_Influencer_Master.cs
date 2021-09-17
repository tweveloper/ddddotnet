using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Influencer_Master : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // 성명 
        public string InfluencerNm { get; set; }

        // 전화번호 
        public string Hp { get; set; }

        // 이메일 
        public string Email { get; set; }

        // 인스타주소 
        public string InStarUrl { get; set; }

        // 페이스북주소 
        public string FaceBookUrl { get; set; }

        // 블로그 주소 
        public string BlogUrl { get; set; }

        // 유튜브 
        public string YoutubeUrl { get; set; }

        // 관심사 
        public string Interest { get; set; }

        // 지역 
        public string Area { get; set; }

        // 인플루언서 등급 
        public int InfluencerLv { get; set; }

        // 몰이름 
        public string MallNm { get; set; }

        // 은행명 
        public string BankNm { get; set; }

        // 계좌번호 
        public string BankNum { get; set; }

        // 예금주명 
        public string Depositor { get; set; }

        // 생년월일 
        public string Birth { get; set; }

        // 메모 
        public string Memo { get; set; }

        // 사용여부 
        public string UseYn { get; set; }

        // 팔로우 수 
        public int FollowCnt { get; set; }

        // 이웃 수 
        public int? NeighborCnt { get; set; }

        // 구독자 수 
        public int? SubscriberCnt { get; set; }

        // 카페맴버 수 
        public int? CafeMemberCnt { get; set; }

        // 암호화테이블Id 
        public int? KeyId { get; set; }

        // 추천인인플루언서Id 
        public long? CommenderId { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
