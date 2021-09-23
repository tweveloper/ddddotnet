using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.WebAdmin.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure.Helper
{
    public static class SessionHelper
    {
        public static tbl_ScmMember ScmMember
        {
            get
            {
                return SiteHelper.CurrentSession.Get<tbl_ScmMember>("ScmMember");
            }
            set
            {
                SiteHelper.CurrentSession.Set("ScmMember", value);
            }
        }

        public static List<tbl_SiteMap> SiteMaps
        {
            get
            {
                return SiteHelper.CurrentSession.GetList<tbl_SiteMap>("SiteMaps");
            }
            set
            {
                SiteHelper.CurrentSession.Set("SiteMaps", value);
            }
        }
    }
}
