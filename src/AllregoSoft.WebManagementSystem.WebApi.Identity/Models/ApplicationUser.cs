using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        public string Account { get; set; }
    }
}
