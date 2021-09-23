using System.Security.Claims;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IIdentityService
    {
        string GetUserIdentity();
        string GetUserName();
        long GetUserId();
        ClaimsPrincipal GetClaimsPrincipal();
    }
}
