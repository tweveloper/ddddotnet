using AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    #region | 인터페이스 |
    public interface ILoginService
    {
        public string Login(LoginDTO data);
        //public tbl_Member Create(string account, string password);
    }
    #endregion

    #region | 클래스 |
    public class LoginService : ILoginService
    {
        private readonly ILogger<LoginService> _logger;
        private readonly IMemberRepository _memberRepository;
        private readonly IJWTAuthService _jWTAuthService;

        public LoginService(ILogger<LoginService> logger,
                            IMemberRepository memberRepository,
                            IJWTAuthService jWTAuthService)
        {
            _logger = logger;
            _memberRepository = memberRepository;
            _jWTAuthService = jWTAuthService;
        }

        /// <summary>
        /// 회원 목록
        /// </summary>
        /// <returns></returns>
        public string Login(LoginDTO data)
        {
            var user = _memberRepository.Entity.Where(x => x.Account.Equals(data.Account) && x.UseYN.Equals("Y")).FirstOrDefault();

            try
            {
                if (user == null)
                {
                    throw new Exception("회원정보가 없습니다.");
                }
                else
                {
                    SHA256Managed sha256Managed = new SHA256Managed();

                    if (!string.Equals(Convert.ToBase64String(sha256Managed.ComputeHash(Encoding.Default.GetBytes(data.Password))), user.Password))
                    {
                        throw new Exception("비밀번호가 잘못되었습니다.");
                    }

                    var tokenResult = _jWTAuthService.GetToken(user);

                    data.IsSuccess = tokenResult.IsSuccess;
                    data.Token = tokenResult.AccessToken;
                    data.MemId = user.Id;
                    data.RoleId = user.RoleId;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                data.IsSuccess = false;
                data.Message = ex.Message;
            }

            return data.Result();
        }
    }
    #endregion
}
