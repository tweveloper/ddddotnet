using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Commands.CreateMember;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure;
using AllregoSoft.WebManagementSystem.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public class MemberService : IMemberService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        private ILogger<MemberService> _logger;

        private readonly string _apiBaseUrl;

        public MemberService(IOptions<AppSettings> settings, HttpClient httpClient, ILogger<MemberService> logger)
        {
            _settings = settings;
            _httpClient = httpClient;
            _logger = logger;

            _apiBaseUrl = $"{_settings.Value.ApiUrl}/api/v1/member/";
        }
        public async Task<tbl_Member> GetMember(long id)
        {
            var uri = API.Member.GetMember(_apiBaseUrl, id);
            _logger.LogDebug("[GetMember] -> Calling {Uri} to get the member", uri);
            var response = await _httpClient.GetAsync(uri);
            _logger.LogDebug("[GetMember] -> response code {StatusCode}", response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            
            return string.IsNullOrEmpty(responseString) ?
                new tbl_Member() { Id = id } :
                JsonConvert.DeserializeObject<tbl_Member>(responseString);
        }

        public async Task<tbl_Member> GetMember(Guid id)
        {
            var uri = API.Member.GetMember(_apiBaseUrl, id);
            _logger.LogDebug("[GetMember] -> Calling {Uri} to get the member", uri);
            var response = await _httpClient.GetAsync(uri);
            _logger.LogDebug("[GetMember] -> response code {StatusCode}", response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ?
                new tbl_Member() { Id = 0 } :
                JsonConvert.DeserializeObject<tbl_Member>(responseString);
        }

        public async Task<Guid> CreateAuthentication(RegisterViewModel model)
        {
            var uri = API.Member.CreateAuthentication(_settings.Value.IdentityUrl);
            _logger.LogDebug("[RegisterUser] -> Calling {Uri} to get the member", uri);

            var userContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, userContent);
            _logger.LogDebug("[RegisterUser] -> response code {StatusCode}", response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();

            var newUser = JsonConvert.DeserializeObject<ApplicationUser>(responseString);
            return newUser.Id;
        }

        public async Task CreateMember(CreateMemberCommand command)
        {
            var uri = API.Member.CreateMember(_apiBaseUrl);
            _logger.LogDebug("[CreateMember] -> Calling {Uri} to get the member", uri);

            var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, data);

        }
    }
}
