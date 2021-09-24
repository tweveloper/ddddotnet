using System.Security.Claims;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IIdentityService
    {
        string GetIdentityId();
        string GetUserName();
        long GetMemberId();
        long GetRoleId();
        ClaimsPrincipal GetClaimsPrincipal();
    }
}
