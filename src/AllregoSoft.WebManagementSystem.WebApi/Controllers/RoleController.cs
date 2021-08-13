using AllregoSoft.WebManagementSystem.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : Controller
    {
        private readonly IRoleService _roleservice;

        public RoleController(IRoleService roleservice)
        {
            _roleservice = roleservice;
        }

        /// <summary>
        /// 역할 리스트
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult RoleList()
        {
            var list = _roleservice.RoleList();
            return Ok(list);
        }

        /// <summary>
        /// 역할 등록/수정
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Role([FromBody] JObject data)
        {
            var List = _roleservice.AddOrUpdate(data);

            return Ok(List);
        }

        /// <summary>
        /// 역할별 메뉴 리스트
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult Role_SiteMapList(long Id)
        {
            var result = _roleservice.Role_SiteMapList(Id);

            return Ok(result);
        }

        /// <summary>
        /// 역할별 메뉴 리스트 등록/수정
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Role_SiteMap([FromBody] JObject data)
        {
            var result = _roleservice.RoleMappingSave(data);

            return Ok(result);
        }

        /// <summary>
        /// 역할 CRUD 등록/수정
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Role_SiteMap_CRUD([FromBody] JObject data)
        {
            var List = _roleservice.Role_SiteMap_CRUD(data);

            return Ok(List);
        }

        /// <summary>
        /// CRUD 가져오기
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetCRUD(long MemRoleId)
        {
            var List = _roleservice.GetCRUD(MemRoleId);
            return Ok(List);
        }
    }
}
