using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities.ValueObjects
{
    public class TokenResult : IValueObject
    {
        public bool IsSuccess { get; private set; }
        public tbl_Member tbl_Member { get; private set; }
        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }

        public TokenResult(bool isSuccess, tbl_Member tbl_Member, string accessToken, string refreshToken)
        {
            this.IsSuccess = isSuccess;
            this.tbl_Member = tbl_Member;
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
        }
    }
}
