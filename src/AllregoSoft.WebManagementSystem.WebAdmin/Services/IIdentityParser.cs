using System.Security.Principal;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
