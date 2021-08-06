using Microsoft.AspNetCore.Mvc;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : Controller
    {
        //private readonly RoleService _service;

        //public RoleController(RoleService service)
        //{
        //    _service = service;
        //}

        /////// <summary>
        /////// 역할 리스트
        /////// </summary>
        /////// <returns></returns>
        //[HttpGet("[action]")]
        //public ActionResult RoleList()
        //{
        //    var list = _service.RoleList();
        //    return Ok(list);
        //}

        /////// <summary>
        /////// 역할 등록/수정
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult Role([FromBody] JObject data)
        //{
        //    var List = _service.AddOrUpdate(data);

        //    return Ok(List);
        //}

        /////// <summary>
        /////// 역할별 메뉴 리스트
        /////// </summary>
        /////// <returns></returns>
        //[HttpGet("[action]")]
        //public IActionResult Role_SiteMapList(int Id)
        //{
        //    var result = _service.Role_SiteMapList(Id);

        //    return Ok(result);
        //}

        /////// <summary>
        /////// 역할별 메뉴 리스트 등록/수정
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult Role_SiteMap([FromBody] JObject data)
        //{
        //    var result = _service.RoleMappingSave(data);

        //    return Ok(result);
        //}

        /////// <summary>
        /////// 역할 CRUD 등록/수정
        /////// </summary>
        /////// <returns></returns>
        //[HttpPost("[action]")]
        //public IActionResult Role_SiteMap_CRUD([FromBody] JObject data)
        //{
        //    var List = _service.Role_SiteMap_CRUD(data);

        //    return Ok(List);
        //}

        /////// <summary>
        /////// CRUD 가져오기
        /////// </summary>
        /////// <returns></returns>
        //[HttpGet("[action]")]
        ////public IActionResult GetCRUD(int MemRoleId, int SiteMapId)
        //public IActionResult GetCRUD(int MemRoleId)
        //{
        //    //var List = _service.GetCRUD(MemRoleId, SiteMapId);
        //    var List = _service.GetCRUD(MemRoleId);
        //    return Ok(List);
        //}
    }
}
