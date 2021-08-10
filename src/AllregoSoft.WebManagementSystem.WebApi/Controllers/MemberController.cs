using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        ///// <summary>
        ///// 회원 등록
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("[action]")]
        //public ActionResult Create(string account, string password)
        //{
        //    var result = _memberService.Create(account, password);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// 회원 목록
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("[action]")]
        //public ActionResult MemberList()
        //{
        //    var list = _memberService.MemberList();
        //    return Ok(list);
        //}

        ///// <summary>
        ///// 회원 정보
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult MemberInfo([FromBody] JObject data)
        //{
        //    var MemberInfo = _memberService.MemberInfo(Convert.ToInt32(data["Id"]));
        //    return Ok(MemberInfo);
        //}

        ///// <summary>
        ///// 회원 등록/수정
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult Member([FromBody] JObject data)
        //{
        //    if (data["UseYN"] == null)
        //        data.Add("UseYN", data["UseYN"] == null ? "N" : "Y");
        //    else
        //        data["UseYN"] = data["UseYN"].ToString() == "true" ? "Y" : "N";

        //    if (data["smsFl"] == null)
        //        data.Add("smsFl", data["smsFl"] == null ? "N" : "Y");
        //    else
        //        data["smsFl"] = data["smsFl"].ToString() == "true" ? "Y" : "N";

        //    if (data["maillingFl"] == null)
        //        data.Add("maillingFl", data["maillingFl"] == null ? "N" : "Y");
        //    else
        //        data["maillingFl"] =  data["maillingFl"].ToString() == "true" ? "Y" : "N";

        //    var result = _memberService.AddOrUpdate(data);

        //    return Ok(result);
        //}

        ///// <summary>
        ///// 회원 삭제
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult Delete([FromBody] JObject data)
        //{
        //    string[] list = data["Id"].ToString().Split(',');
        //    var result = _memberService.Delete(list);
        //    return Ok(result);
        //}

        ///// <summary>
        ///// 역할 리스트
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("[action]")]
        //public IActionResult RoleList()
        //{
        //    var RoleList = _memberService.RoleList();
        //    return Ok(RoleList);
        //}
    }
}