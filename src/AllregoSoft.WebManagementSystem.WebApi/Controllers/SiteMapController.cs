using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class SiteMapController : Controller
    {
        private readonly ISiteMapService _sitemapservice;
        
        public SiteMapController(ISiteMapService sitemapservice)
        {
            _sitemapservice = sitemapservice;
        }

        /// <summary>
        /// 노드 리스트
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult SiteMapList()
        {
            var list = _sitemapservice.SiteMapList();
            return Ok(list);
        }

        /// <summary>
        /// 노드 정보
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult SiteMapInfo(long Id)
        {
            var Info = _sitemapservice.SiteMapInfo(Id);
            return Ok(Info);
        }

        /// <summary>
        /// 최상위 노드 추가
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddRootNode([FromBody] JObject data)
        {
            var result = _sitemapservice.AddRootNode(data);
            return Ok(result);
        }

        /// <summary>
        /// 노드 이동
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult ChangePosition([FromBody] JObject data)
        {
            var result = _sitemapservice.ChangePosition(data);
            return Ok(result);
        }

        /// <summary>
        /// 노드 정보 수정
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult SiteMapInfo([FromBody] tbl_SiteMap data)
        {
            var result = _sitemapservice.SiteMapInfoUpdate(data);
            return Ok(result);
        }

        /// <summary>
        /// 노드 등록, 이름 변경
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddOrUpdate([FromBody] JObject data)
        {
            var result = _sitemapservice.AddOrUpdate(data);
            return Ok(result);
        }

        /// <summary>
        /// 노드 삭제
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Delete([FromBody] JObject data)
        {
            var result = _sitemapservice.Delete(data);
            return Ok(result);
        }

        /// <summary>
        /// 역할별 메뉴 리스트
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult Get(int MemRoleId)
        {
            var List = _sitemapservice.RoleSiteMapGet(MemRoleId);         
            return Ok(List);
        }
    }
}