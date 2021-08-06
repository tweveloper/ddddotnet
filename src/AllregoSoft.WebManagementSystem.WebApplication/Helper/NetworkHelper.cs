using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace AllregoSoft.WebManagementSystem.WebApplication.Helpers
{
    public partial class NetworkHelper
    {
        public bool RestSend(string kind, string uri, Method Methd, object SendStr, ref string RecvStr, string token = "")
        {
            bool bRet = false;

            try
            {
                RestClient client;
                var request = new RestRequest(Methd);
                client = new RestClient($"{uri}");
                client.Timeout = -1;
                
                switch (kind)
                {
                    case "JObjectPost":
                        request.AddHeader("Content-Type", "application/json");
                        request.AddParameter("application/json", SendStr, ParameterType.RequestBody);
                        break;
                    case "AuthINICancel":
                        request.AddHeader("Content-Type", "application/json;charset=euc-kr");
                        request.AddParameter("application/json", SendStr, ParameterType.RequestBody);
                        break;
                    case "Post":
                        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                        foreach (var item in (JObject)SendStr)
                        {
                            request.AddParameter(item.Key, item.Value);
                        }
                        break;
                    case "JArrayGet":
                    case "JObjectGet":
                    default:
                        client = new RestClient($"{uri}{SendStr.ToString()}");
                        client.Timeout = -1;
                        break;
                }

                IRestResponse response = client.Execute(request);

                bRet = (response.StatusCode.ToString() == "OK") ? true : false;

                RecvStr = response.Content;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(string.Format("Web API Err - {0}", ex.Message));
                bRet = false;
            }
            return bRet;
        }
    }
}
