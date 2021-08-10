using AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject;
using AllregoSoft.WebManagementSystem.ApplicationCore.Services;
using AllregoSoft.WebManagementSystem.Infrastructure.Module;
using AllregoSoft.WebManagementSystem.WebApi.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [SwaggerTag(description: "이 API는 IIS 기능 API 입니다.")]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IIisService _iisServerService;
        private readonly IGitService _gitService;
        private readonly IDotnetService _dotnetService;
        private readonly IJWTAuthService _jWTAuthService;
        private readonly ILoginService _loginService;
        private readonly SignInManager _signInManager;
        private readonly AppSettings _appSettings;

        public AdminController(ILogger<AdminController> logger,
                                IIisService iisServerService,
                                IGitService gitService,
                                IDotnetService dotnetService,
                                IJWTAuthService jWTAuthService,
                                SignInManager signInManager,
                                AppSettings appSettings,
                                ILoginService loginService)
        {
            _logger = logger;
            _iisServerService = iisServerService;
            _gitService = gitService;
            _dotnetService = dotnetService;
            _jWTAuthService = jWTAuthService;
            _signInManager = signInManager;
            _appSettings = appSettings;
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult Login(string account, string password)
        {
            var loginDTO = new LoginDTO(account, password);
            var result = _loginService.Login(loginDTO);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetToken(string account, string password)
        {
            var result = _signInManager.SignIn(account, password);

            return Ok(result.Result);
        }

        [HttpGet("[action]")]
        public IActionResult GetSiteList()
        {
            var result = _iisServerService.GetIISSiteList();

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetApplicationPoolList()
        {
            var result = _iisServerService.GetApplicationPoolList();

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult AddSite(string domain)
        {
            string repositoryName = _appSettings.TemplateGitName;
            string publishPath = $@"{_appSettings.TemplateGitPublishPath}\{domain}";
            string physicalPath = _appSettings.TemplateGitClonePath;
            string gitRepository = _appSettings.TemplateGitPath;
            string csprojPath = $@"{physicalPath}\{domain}\src\{repositoryName}\{repositoryName}.csproj";

            _iisServerService.AddApplicationPool(domain);
            _iisServerService.AddSite(domain, publishPath, domain);
            _gitService.Clone(domain, gitRepository, physicalPath);
            _dotnetService.Restore(csprojPath);
            _dotnetService.Build(csprojPath);
            _iisServerService.Recycle(domain);
            _dotnetService.Publish(csprojPath, publishPath);
            _iisServerService.AddHosts(domain);

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult AddApplicationPool(string domain)
        {
            _iisServerService.AddApplicationPool(domain);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult StartSite(string domain)
        {
            _iisServerService.StartSite(domain);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult StopSite(string domain)
        {
            _iisServerService.StopSite(domain);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult RemoveSite(string domain)
        {
            _iisServerService.RemoveSite(domain);
            return Ok();
        }
    }
}
