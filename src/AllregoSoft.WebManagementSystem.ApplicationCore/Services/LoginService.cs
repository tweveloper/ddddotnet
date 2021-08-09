using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    #region | 인터페이스 |
    public interface ILoginService
    {
        public tbl_Member Login(string account, string password);
    }
    #endregion

    #region | 클래스 |
    public class LoginService : ILoginService
    {
        private readonly IMemberRepository _memberRepository;
        public LoginService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// 회원 목록
        /// </summary>
        /// <returns></returns>
        public tbl_Member Login(string account, string password)
        {
            var user = _memberRepository.Entity.ToList().Where(x => x.Account.Equals(account) && x.UseYN.Equals("Y")).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("회원정보가 없습니다.");
            }
            else
            {
                SHA256Managed sha256Managed = new SHA256Managed();

                if (!string.Equals(Convert.ToBase64String(sha256Managed.ComputeHash(Encoding.Default.GetBytes(password))), user.Password))
                    throw new Exception("비밀번호가 잘못되었습니다.");
            }

            return user;
        }
    }
    #endregion
}
