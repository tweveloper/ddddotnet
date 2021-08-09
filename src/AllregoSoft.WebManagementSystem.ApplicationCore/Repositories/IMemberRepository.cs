using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IMemberRepository : IGenericRepository<tbl_Member>
    {
    }

    public interface IMemberTokenRepository : IGenericRepository<tbl_MemberToken>
    {
    }
}
