using AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject.Base;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject
{
    public class LoginDTO : BaseDTO
    {
        public LoginDTO(string account, string password)
        {
            this.Account = account;
            this.Password = password;
        }

        public string Account { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public long? RoleId { get; set; }
        public long MemId{ get; set; }

        public override string Result()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                IsSuccess,
                Message,
                Token,
                RoleId,
                MemId
            });
        }
    }
}
