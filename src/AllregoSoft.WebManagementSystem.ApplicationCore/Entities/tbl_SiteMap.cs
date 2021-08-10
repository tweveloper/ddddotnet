using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities
{
    public class tbl_SiteMap : BaseEntity, IAggregateRoot
    {

        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 상위고유번호
        /// </summary>
        public long Parent { get; set; }
        /// <summary>
        /// 차수
        /// </summary>
        public int Depth { get; set; }
        /// <summary>
        /// 순서
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 경로
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 설명
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 활성화
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// 상태
        /// </summary>
        public string State { get; set; }
        //[Display(Name = "등록자"), Required]
        //public int RegMemId { get; set; }
        //[Display(Name = "등록일"), Required]
        //public DateTime RegDate { get; set; }
        //[Display(Name = "수정자")]
        //public int? ModMemId { get; set; }
        //[Display(Name = "수정일")]
        //public DateTime? ModDate { get; set; }
    }
}
