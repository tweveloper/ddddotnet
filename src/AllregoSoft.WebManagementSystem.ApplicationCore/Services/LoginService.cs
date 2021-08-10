using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    #region | 인터페이스 |
    public interface ILoginService
    {
        public dynamic Login(string account, string password);
        public tbl_Member Create(string account, string password);
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

        public tbl_Member Create(string account, string password)
        {
            var newMember = new tbl_Member() { Account = account, Password = password, Name = account, UseYN = "Y", RegDate = DateTime.Now, RegMemId = 1 };
            _memberRepository.Add(newMember);
            _memberRepository.SaveChanges();

            return newMember;
        }

        /// <summary>
        /// 회원 목록
        /// </summary>
        /// <returns></returns>
        public dynamic Login(string account, string password)
        {
            var Job = new JObject();
            var user = _memberRepository.GetAll().Where(x => x.Account.Equals(account) && x.UseYN.Equals("Y")).FirstOrDefault();

            try
            {
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
            }
            catch (Exception ex)
            {
                Job.Add("error", ex.Message);
                return JObject.Parse(JsonConvert.SerializeObject(Job));
            }

            return user;
        }
    }
    #endregion
}
