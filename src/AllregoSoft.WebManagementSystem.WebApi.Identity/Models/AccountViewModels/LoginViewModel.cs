using System.ComponentModel.DataAnnotations;

namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Models.AccountViewModels
{
    public record LoginViewModel
    {
        [Required]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
