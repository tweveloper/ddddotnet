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
            public static string GetMember(string baseUri, long memberId) => $"{baseUri}/{memberId}";
            public static string GetMemberByIdentity(string baseUri, string identityId) => $"{baseUri}/GetMemberByIdAsync/{identityId}";
            public static string CreateMember(string baseUri) => $"{baseUri}/Create";
            public static string CreateAuthentication(string identityUri) => $"{identityUri}/api/auth/create";
            public static string GetSiteMap(string baseUri) => $"{baseUri}/GetSiteMapAsync";
        }

        public static class ScmMember
        {
            public static string GetScmMember(string baseUri, long memberId) => $"{baseUri}/{memberId}";
            public static string GetScmMemberByIdentity(string baseUri, string identityId) => $"{baseUri}/GetMemberByIdAsync/{identityId}";
            public static string CreateScmMember(string baseUri) => $"{baseUri}/Create";
        }
    }
}
