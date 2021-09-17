using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AllregoSoft.WebManagementSystem.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        //public long UserId => long.Parse(_httpContextAccessor.HttpContext.User.FindFirst("mem").Value);
        // TODO : 로그인 Id 불러와야됨
        public long UserId => 0;// _httpContextAccessor.HttpContext == null ? 0 : long.Parse(_httpContextAccessor.HttpContext.User.FindFirst("mem").Value);
    }
}
