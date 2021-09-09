namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Models.AccountViewModels
{
    public class LoggedOutViewModel
    {
        public string PostLogoutRedirectUri { get; init; }
        public string ClientName { get; init; }
        public string SignOutIframeUrl { get; init; }
    }
}
