using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
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
        public void SetActive(string Id, ITempDataDictionary TempData)
        {
            string strParent1 = string.Empty;
            string strParent2 = string.Empty;

            foreach (var FirstMap in TempData["SiteMap"] as JArray)
            {
                foreach (var SecondMap in FirstMap["SecondMaps"])
                {
                    if (!SecondMap["ThirdMaps"].HasValues)
                    {
                        if (SecondMap["Id"].ToString() == Id)
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
                            if (ThirdMap["Id"].ToString() == Id)
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

                                if (SecondMap["Id"].ToString() != strParent2)
                                {
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
            TempData.Keep();
        }

        //전체 CRUD 권한을 TempData에 저장
        public void GetCRUD(string RoleId, ITempDataDictionary TempData)
        {
            string strRecv = "";

            if (_webApiHelper.GetCRUD(RoleId, ref strRecv))
            {
                TempData["AllCRUD"] = JArray.Parse(strRecv);
            }
            else
            {
                TempData["AllCRUD"] = null;
            }
            TempData.Keep();
        }

        //권한 체크
        public bool CheckAuth(string Path, ITempDataDictionary TempData)
        {
            JArray JArr = JArray.Parse(TempData["AllCRUD"].ToString());

            TempData["C"] = "";
            TempData["R"] = "";
            TempData["U"] = "";
            TempData["D"] = "";

            //CRUD 권한 체크
            int count = 0;
            foreach (var data in JArr)
            {
                if (data["Path"].ToString() == Path)
                {
                    TempData["C"] = data["C"] == null ? "" : data["C"].ToString();
                    TempData["R"] = data["R"] == null ? "" : data["R"].ToString();
                    TempData["U"] = data["U"] == null ? "" : data["U"].ToString();
                    TempData["D"] = data["D"] == null ? "" : data["D"].ToString();

                    SetActive(data["Id"].ToString(), TempData);
                    count++;
                    break;
                }
            }
            TempData.Keep();
            //페이지 접근 권한 체크
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}