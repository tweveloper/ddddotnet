using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    public interface IMemberService
    {
        tbl_Member Create(tbl_Member data);
        tbl_Member Create(string account, string password);
        tbl_Member Get(long id);
    }
    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;
        private readonly IMemberRepository _memberRepository;
        public MemberService(ILogger<MemberService> logger,
                             IMemberRepository memberRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
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

        public tbl_Member Get(long id)
        {
            return _memberRepository.Entity.Find(id);
        }
    }
}
