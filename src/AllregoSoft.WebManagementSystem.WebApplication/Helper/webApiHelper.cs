using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Text;

namespace AllregoSoft.WebManagementSystem.WebApplication.Helpers
{
    public partial class webApiHelper
    {
        private readonly NetworkHelper _networkHelper;

        public webApiHelper()
        {
            _networkHelper = new NetworkHelper();
        }

        public bool GetSiteMap(string MemRoleId, ref string strRecv)
        {
            bool bRet = false;
            strRecv = string.Empty;

            string strUri = Startup.appSettings["ApiDomain"] + "/SiteMap/Get";

            StringBuilder strbSend = new StringBuilder();

            strbSend = new StringBuilder();
            strbSend.Append($"?MemRoleId={MemRoleId}");

            if (_networkHelper.RestSend("JArrayGet", $"{ strUri }{ strbSend.ToString() }", Method.GET, "", ref strRecv))
            {
                bRet = true;
            }
            else
            {
                bRet = false;
            }
            return bRet;
        }

        //public bool GetCRUD(string MemRoleId, string SiteMapId, ref string strRecv)
        public bool GetCRUD(string MemRoleId, ref string strRecv)
        {
            bool bRet = false;
            strRecv = string.Empty;

            string strUri = Startup.appSettings["ApiDomain"] + "/Role/GetCRUD";

            StringBuilder strbSend = new StringBuilder();

            strbSend = new StringBuilder();
            strbSend.Append($"?MemRoleId={MemRoleId}");
            //strbSend.Append($"&SiteMapId={SiteMapId}");

            if (_networkHelper.RestSend("JArrayGet", $"{ strUri }{ strbSend.ToString() }", Method.GET, "", ref strRecv))
            {
                bRet = true;
            }
            else
            {
                bRet = false;
            }
            return bRet;
        }

        public bool Login(string usrId, string usrPw, ref string strRecv)
        {
            bool bRet = false;

            var rst = new JObject();
            var jBody = new JObject();

            string strUri = Startup.appSettings["ApiDomain"] + "/Login/LogIn";

            try
            {
                strRecv = string.Empty;

                jBody.Add("Id", usrId);
                jBody.Add("Password", usrPw);

                if (_networkHelper.RestSend("JObjectPost", strUri, Method.POST, jBody, ref strRecv))
                    bRet = true;
            }
            catch (Exception ex)
            {
                strRecv = ex.Message;
                bRet = false;
            }

            return bRet;
        }
    }
}
