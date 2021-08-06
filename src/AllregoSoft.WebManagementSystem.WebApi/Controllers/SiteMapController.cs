using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SiteMapController : Controller
    {
        //private readonly SiteMapService _service;
        
        //public SiteMapController(SiteMapService service)
        //{
        //    _service = service;
        //}

        /////// <summary>
        /////// 노드 리스트
        /////// </summary>
        /////// <returns></returns>
        //[HttpGet("[action]")]
        //public ActionResult SiteMapList()
        //{
        //    var list = _service.SiteMapList();
        //    return Ok(list);
        //}

        /////// <summary>
        /////// 노드 정보
        /////// </summary>
        /////// <returns></returns>
        //[HttpGet("[action]")]
        //public IActionResult SiteMapInfo(int Id)
        //{
        //    var Info = _service.SiteMapInfo(Id);
        //    return Ok(Info);
        //}

        /////// <summary>
        /////// 최상위 노드 추가
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult AddRootNode([FromBody] JObject data)
        //{
        //    var result = _service.AddRootNode(data);
        //    return Ok(result);
        //}

        /////// <summary>
        /////// 노드 이동
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult ChangePosition([FromBody] JObject data)
        //{
        //    var result = _service.ChangePosition(data);
        //    return Ok(result);
        //}

        /////// <summary>
        /////// 노드 정보 수정
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult SiteMapInfo([FromBody] tbl_SiteMap data)
        //{
        //    var result = _service.SiteMapInfoUpdate(data);
        //    return Ok(result);
        //}

        /////// <summary>
        /////// 노드 등록, 이름 변경
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult AddOrUpdate([FromBody] JObject data)
        //{
        //    var result = _service.AddOrUpdate(data);
        //    return Ok(result);
        //}

        /////// <summary>
        /////// 노드 삭제
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult Delete([FromBody] JObject data)
        //{
        //    var result = _service.Delete(data);
        //    return Ok(result);
        //}

        /////// <summary>
        /////// 역할별 메뉴 리스트
        /////// </summary>
        /////// <returns></returns>
        //[HttpGet("[action]")]
        //public IActionResult Get(int MemRoleId)
        //{
        //    var List = _service.RoleSiteMapGet(MemRoleId);
        //    //var List = _service.CategoryGet(MemRoleId);            
        //    return Ok(List);
        //}
    }
}