using AllregoSoft.WebManagementSystem.WebApi.Identity.Models;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Interfaces
{
    public interface IIdentityServerService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
