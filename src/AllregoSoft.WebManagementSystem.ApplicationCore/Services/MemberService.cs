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
            _memberRepository.Entity.Add(data);

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
            _memberRepository.Entity.Add(member);
            _memberRepository.UnitOfWork.SaveChanges();

            return member;
        }
    }
}
