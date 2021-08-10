using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    public interface IMemberService
    {
        tbl_Member Create(tbl_Member data);
        tbl_Member Create(string account, string password);
        dynamic MemberList();
        tbl_Member MemberInfo(long Id);
        JObject AddOrUpdate(JObject data);
        dynamic RoleList();
        JObject Delete(string[] list);
    }
    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;
        private readonly IMemberRepository _memberRepository;
        private readonly IRoleRepository _roleRepository;
        public MemberService(ILogger<MemberService> logger,
                             IMemberRepository memberRepository,
                             IRoleRepository roleRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
            _roleRepository = roleRepository;
        }
        public tbl_Member Create(tbl_Member data)
        {
            _memberRepository.Add(data);
            _memberRepository.SaveChanges();

            return data;
        }

        public tbl_Member Create(string account, string password)
        {
            var member = new tbl_Member()
            {
                Account = account,
                Password = password,
                Name = account,
                UseYN = "Y"
            };
            _memberRepository.Add(member);
            _memberRepository.SaveChanges();

            return member;
        }

        /// <summary>
        /// 회원 목록
        /// </summary>
        /// <returns></returns>
        public dynamic MemberList()
        {
            var list = (from x in _memberRepository.GetAll()
                        join a in _roleRepository.GetAll() on x.RoleId equals a.Id into _a
                        from _b in _a.DefaultIfEmpty()
                        orderby x.Id
                        select new
                        {
                            x.Id,
                            x.Account,
                            x.Name,
                            x.HP,
                            x.Email,
                            x.UseYN,
                            RoleName = _b == null ? "" : _b.Name,
                            RegDate = x.RegDate.ToString("yyyy-MM-dd HH:mm:ss")
                        }).ToList();

            return list;
        }

        /// <summary>
        /// 회원정보
        /// </summary>
        /// <param Id="UserId"></param>
        /// <returns></returns>
        public tbl_Member MemberInfo(long Id)
        {
            var data = _memberRepository.GetAll().Where(x => x.Id == Id).FirstOrDefault();

            return data;
        }

        /// <summary>
        /// 회원정보 등록/수정
        /// </summary>
        /// <param tbl_Member="data"></param>
        /// <returns></returns>
        public JObject AddOrUpdate(JObject data)
        {
            var result = new JObject();

            try
            {
                var persist = _memberRepository.GetAll().Where(x => x.Id == Convert.ToInt32(data["Id"])).FirstOrDefault();

                using (var transaction = new TransactionScope())
                {
                    var valid = _memberRepository.GetAll().Where(x => x.Account == data["Account"].ToString()).Count();

                    if (persist == null)
                    {
                        if (valid > 0)
                            throw new Exception("동일한 ID가 존재합니다.");

                        persist = new tbl_Member();
                        persist.Account = data["Account"].ToString();

                        if (!string.IsNullOrEmpty(data["Password"].ToString()))
                        {
                            SHA256Managed sha256Managed = new SHA256Managed();
                            persist.Password = Convert.ToBase64String(sha256Managed.ComputeHash(Encoding.Default.GetBytes(data["Password"].ToString())));
                        }
                        persist.Name = data["Name"].ToString();
                        persist.HP = data["HP"].ToString();
                        persist.smsFl = data["smsFl"].ToString();
                        persist.Email = data["Email"].ToString();
                        persist.maillingFl = data["maillingFl"].ToString();
                        persist.UseYN = "Y";
                        persist.RoleId = Convert.ToInt32(data["RoleId"]);
                        persist.RegMemId = 1;
                        persist.RegDate = DateTime.Now;
                        _memberRepository.Add(persist);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(data["Password"].ToString()))
                        {
                            SHA256Managed sha256Managed = new SHA256Managed();
                            persist.Password = Convert.ToBase64String(sha256Managed.ComputeHash(Encoding.Default.GetBytes(data["Password"].ToString())));
                        }
                        persist.Name = data["Name"].ToString();
                        persist.HP = data["HP"].ToString();
                        persist.smsFl = data["smsFl"].ToString();
                        persist.Email = data["Email"].ToString();
                        persist.maillingFl = data["maillingFl"].ToString();
                        persist.UseYN = data["UseYN"].ToString();
                        persist.RoleId = Convert.ToInt32(data["RoleId"]);
                        persist.ModMemId = 1;
                        persist.ModDate = DateTime.Now;

                        //변경 될 Data 작업 목록에 추가
                        _memberRepository.Update(persist);
                    }
                    _memberRepository.SaveChanges();
                    transaction.Complete();
                }
                result.Add("result", "true");
                result.Add("message", "");
            }
            catch (Exception ex)
            {
                result.Add("result", "false");
                result.Add("message", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 회원정보에 나오는 역할목록
        /// </summary>
        /// <returns></returns>
        public dynamic RoleList()
        {
            var RoleList = (from x in _roleRepository.GetAll()
                            where x.State == "0"
                            select new
                            {
                                x.Id,
                                x.Name,
                            }).OrderBy(x => x.Id).ToList();

            return RoleList;
        }

        /// <summary>
        /// 회원 삭제
        /// </summary>
        /// <returns></returns>
        public JObject Delete(string[] list)
        {
            var result = new JObject();

            try
            {
                using (var transaction = new TransactionScope())
                {
                    foreach (string id in list)
                    {
                        tbl_Member mem = _memberRepository.GetAll().Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
                        mem.UseYN = "N";
                        _memberRepository.Update(mem);
                    }
                    result.Add("result", "true");
                    result.Add("message", "");

                    _memberRepository.SaveChanges();
                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                result.Add("result", "false");
                result.Add("message", ex.Message);
            }

            return result;
        }
    }
}
