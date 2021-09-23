using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.Commands;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public class ScmMemberService : IScmMemberService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        private ILogger<ScmMemberService> _logger;

        private readonly string _apiBaseUrl;

        public ScmMemberService(IOptions<AppSettings> settings, HttpClient httpClient, ILogger<ScmMemberService> logger)
        {
            _settings = settings;
            _httpClient = httpClient;
            _logger = logger;

            _apiBaseUrl = $"{_settings.Value.ApiUrl}/api/v1/scmmember";
        }
        public async Task<tbl_ScmMember> GetScmMember(long id)
        {
            var uri = API.Member.GetMember(_apiBaseUrl, id);
            _logger.LogDebug("[GetScmMember] -> Calling {Uri} to get the member", uri);
            
            var response = await _httpClient.GetAsync(uri);
            _logger.LogDebug("[GetScmMember] -> response code {StatusCode}", response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            
            return string.IsNullOrEmpty(responseString) ?
                new tbl_ScmMember() { Id = id } :
                JsonConvert.DeserializeObject<tbl_ScmMember>(responseString);
        }

        public async Task<tbl_ScmMember> GetScmMemberByIdentity(string id)
        {
            var uri = API.Member.GetMemberByIdentity(_apiBaseUrl, id);
            _logger.LogDebug("[GetScmMemberByIdentity] -> Calling {Uri} to get the member", uri);
            
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/GetMemberById?identityId={id}");
            _logger.LogDebug("[GetScmMemberByIdentity] -> response code {StatusCode}", response.StatusCode);
            
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ?
                new tbl_ScmMember() { Id = 0 } :
                JsonConvert.DeserializeObject<tbl_ScmMember>(responseString);
        }

        public async Task CreateScmMember(CreateScmMemberCommand command)
        {
            var uri = API.ScmMember.CreateScmMember(_apiBaseUrl);
            _logger.LogDebug("[CreateScmMember] -> Calling {Uri} to get the member", uri);

            var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, data);

        }
    }
}
