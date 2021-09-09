using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure
{
    public static class API
    {
        public static class Member
        {
            public static string GetMember(string baseUri, long memberId) => $"{baseUri}{memberId}";
            public static string GetMember(string baseUri, Guid identityId) => $"{baseUri}{identityId}";
            public static string CreateMember(string baseUri) => $"{baseUri}/Create";
            public static string CreateAuthentication(string identityUri) => $"{identityUri}/api/auth/create";
        }
    }
}
