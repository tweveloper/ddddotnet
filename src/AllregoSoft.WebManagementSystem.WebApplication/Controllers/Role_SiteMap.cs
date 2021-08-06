using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json.Linq;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class Role_SiteMap : Controller
    {
        private readonly webApiHelper _webApiHelper;

        public Role_SiteMap(webApiHelper webApiHelper)
        {
            _webApiHelper = webApiHelper;
        }

        [HttpPost]
        //현재 클릭된 메뉴가 열려 있도록 active 저장
        public void SetActive([FromBody] JObject data)
        {
            if (data.Count > 0)
            {
                string strParent1 = string.Empty;
                string strParent2 = string.Empty;

                foreach (var FirstMap in TempData["SiteMap"] as JArray)
                {
                    foreach (var SecondMap in FirstMap["SecondMaps"])
                    {
                        if(!SecondMap["ThirdMaps"].HasValues)
                        {
                            if (SecondMap["Id"].ToString() == data["Id"].ToString())
                            {
                                strParent2 = SecondMap["Parent"].ToString();
                                SecondMap["Active"] = "true";
                                FirstMap["ParentMap"]["Active"] = "true";
                            }
                            else
                            {
                                SecondMap["Active"] = "";

                                if (SecondMap["Parent"].ToString() != strParent2 && string.IsNullOrEmpty(strParent1))
                                    FirstMap["ParentMap"]["Active"] = "";
                            }
                        }
                        else
                        {
                            foreach (var ThirdMap in SecondMap["ThirdMaps"])
                            {
                                if (ThirdMap["Id"].ToString() == data["Id"].ToString())
                                {
                                    strParent2 = ThirdMap["Parent"].ToString();
                                    strParent1 = SecondMap["Parent"].ToString();
                                    ThirdMap["Active"] = "true";
                                    SecondMap["Active"] = "true";
                                    FirstMap["ParentMap"]["Active"] = "true";
                                }
                                else
                                {
                                    ThirdMap["Active"] = "";

                                    if (SecondMap["Id"].ToString() != strParent2) {
                                        SecondMap["Active"] = "";

                                        if (FirstMap["Key"].ToString() != strParent1)
                                        {
                                            FirstMap["ParentMap"]["Active"] = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //TempData["SiteMap"] 데이터 유지
                //TempData.Keep("SiteMap");
                //클릭한 메뉴의 SiteMapId 저장
                TempData["SiteMapId"] = data["Id"].ToString();
                //HttpContext.Session.SetString("SiteMapId", data["Id"].ToString());
                //TempData["SiteMapId"] 데이터 유지
                //TempData.Keep("SiteMapId");
                //GetCRUD(HttpContext.Session.GetInt32("UsrRoleId").ToString(), TempData);
                //GetCRUD(HttpContext.Session.GetInt32("UsrRoleId").ToString(), data["Id"].ToString(), TempData);
            }
            TempData["C"] = "";
            TempData["R"] = "";
            TempData["U"] = "";
            TempData["D"] = "";
            TempData.Keep();
        }

        //CRUD 권한을 TempData에 각각 저장
        //public void GetCRUD(string RoleId, string SiteMapId, ITempDataDictionary TempData)
        public void GetCRUD(string RoleId, ITempDataDictionary TempData)
        {
            string strRecv = "";

            //if (_webApiHelper.GetCRUD(RoleId, SiteMapId, ref strRecv)) 
            if (_webApiHelper.GetCRUD(RoleId, ref strRecv))
            {
                TempData["AllCRUD"] = JArray.Parse(strRecv);
                //strRecv = strRecv.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace("\"\"", "\"");

                //if (strRecv.Length > 0)
                //{
                //    string[] temp = strRecv.Split(",");

                //    foreach (string data in temp)
                //    {
                //        string[] tempdata = data.Replace("\"", "").Split(":");

                //        if (tempdata[0] == "C")
                //            TempData["C"] = tempdata[1].ToString();
                //        else if (tempdata[0] == "R")
                //            TempData["R"] = tempdata[1].ToString();
                //        else if (tempdata[0] == "U")
                //            TempData["U"] = tempdata[1].ToString();
                //        else
                //            TempData["D"] = tempdata[1].ToString();
                //    }
                //    //TempData["CRUD"] = JArray.Parse(strRecv);
                //}
                //else
                //{
                //    TempData["C"] = "";
                //    TempData["R"] = "";
                //    TempData["U"] = "";
                //    TempData["D"] = "";
                //    //TempData["CRUD"] = null;
                //}
            }
            else
            {
                //TempData["C"] = "";
                //TempData["R"] = "";
                //TempData["U"] = "";
                //TempData["D"] = "";
                TempData["AllCRUD"] = null;
            }
            //TempData["UsrRoleId"] 데이터 유지
            //TempData.Keep("UsrRoleId");
            //TempData["SiteMapId"] 데이터 유지
            //TempData.Keep("SiteMapId");
            TempData.Keep();
        }

        public void CheckCRUD(string SiteMapId, ITempDataDictionary TempData)
        {
            JArray JArr = JArray.Parse(TempData["AllCRUD"].ToString());

            TempData["C"] = "";
            TempData["R"] = "";
            TempData["U"] = "";
            TempData["D"] = "";

            foreach (var data in JArr)
            {
                if(data["Key"].ToString() == SiteMapId)
                {
                    TempData["C"] = data["data"]["C"].ToString();
                    TempData["R"] = data["data"]["R"].ToString();
                    TempData["U"] = data["data"]["U"].ToString();
                    TempData["D"] = data["data"]["D"].ToString();
                    break;
                }
            }
            TempData.Keep();
        }
    }
}