using System;
using System.ComponentModel.DataAnnotations;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities
{
    public class tbl_MemberToken
    {
        [Key]
        public string Token { get; set; }
        public long MemberId { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
