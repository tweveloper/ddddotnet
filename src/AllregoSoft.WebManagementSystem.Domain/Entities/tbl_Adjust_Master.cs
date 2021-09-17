using AllregoSoft.WebManagementSystem.Domain.Common;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    // 정산 관련 테이블
    public class tbl_Adjust_Master : AuditableEntity, IHasDomainEvent
    {
        // 고유번호 
        public long Id { get; set; }

        // 공급사번호 
        public long Scm_Id { get; set; }

        // 브랜드코드 
        public string BrandCd { get; set; }

        // 정산주기 15 : 보름 정산 30: 월말 정산
        public string AdjustCheck { get; set; }

        // 정산기준 2 : 배송출고일 기준 1: 구매확정일 기준
        public string AdjustStandard { get; set; }

        // 정산서보내는 날짜 
        public int AdjustSendDt { get; set; }

        // 브랜드담당자 해당 담당자 scm 만 정산화면에서 볼수 있도록
        public string BrandAgentId { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
