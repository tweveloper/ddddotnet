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
        }

        public static class ScmMember
        {
            public static string GetScmMember(string baseUri, long memberId) => $"{baseUri}/{memberId}";
            public static string GetScmMemberByIdentity(string baseUri, string identityId) => $"{baseUri}/GetMemberByIdAsync/{identityId}";
            public static string CreateScmMember(string baseUri) => $"{baseUri}/Create";
        }

        public static class SiteMap
        {
            public static string GetRoleSiteMap(string baseUri, long RoleId) => $"{baseUri}/GetRoleSiteMap?roleId={RoleId}";
            public static string SiteMapList(string baseUri) => $"{baseUri}/SiteMapList";
            public static string SiteMapInfo(string baseUri, long Id) => $"{baseUri}/SiteMapInfo?Id={Id}";
            public static string UpdateSiteMapInfo(string baseUri) => $"{baseUri}/UpdateSiteMapInfo";
            public static string CreateRootNode(string baseUri) => $"{baseUri}/CreateRootNode";
            public static string CreateSiteMap(string baseUri) => $"{baseUri}/CreateSiteMap";
            public static string ChangePosition(string baseUri) => $"{baseUri}/ChangePosition";
            public static string DeleteSiteMap(string baseUri) => $"{baseUri}/DeleteSiteMap";
        }
    }
}
