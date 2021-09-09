namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Services
{
    public interface IRedirectService
    {
        string ExtractRedirectUriFromReturnUrl(string url);
    }
}
