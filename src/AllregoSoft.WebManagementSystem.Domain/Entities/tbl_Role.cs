using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllregoSoft.WebManagementSystem.Domain.Entities
{
    public class tbl_Role
    {
        public long Id { get; set; }
        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 상태
        /// </summary>
        public string State { get; set; }

        //[InverseProperty("Role")]
        //public virtual ICollection<tbl_Role_Mapping> RoleMapping { get; set; }

        //[InverseProperty("Role")]
        //public virtual ICollection<tbl_Member> Member { get; set; }
    }
}
