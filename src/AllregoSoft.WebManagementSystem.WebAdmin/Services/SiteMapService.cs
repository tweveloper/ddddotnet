using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public class SiteMapService : ISiteMapService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        private ILogger<SiteMapService> _logger;

        private readonly string _apiBaseUrl;

        public SiteMapService(IOptions<AppSettings> settings, HttpClient httpClient, ILogger<SiteMapService> logger)
        {
            _settings = settings;
            _httpClient = httpClient;
            _logger = logger;

            _apiBaseUrl = $"{_settings.Value.ApiUrl}/api/v1/SiteMap";
        }
        public async Task<List<tbl_SiteMap>> GetSiteMap(long id)
        {
            var uri = API.SiteMap.GetSiteMap(_apiBaseUrl, id);
            _logger.LogDebug("[GetSiteMap] -> Calling {Uri} to get the SiteMap", uri);
            
            var response = await _httpClient.GetAsync(uri);
            _logger.LogDebug("[GetSiteMap] -> response code {StatusCode}", response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            
            return string.IsNullOrEmpty(responseString) ?
                new List<tbl_SiteMap>() : JsonConvert.DeserializeObject<List<tbl_SiteMap>>(responseString);
        }

        //public async Task<tbl_SiteMap> GetSiteMapByIdentity(string id)
        //{
        //    var uri = API.SiteMap.GetMemberByIdentity(_apiBaseUrl, id);
        //    _logger.LogDebug("[GetSiteMapByIdentity] -> Calling {Uri} to get the member", uri);

        //    var response = await _httpClient.GetAsync($"{_apiBaseUrl}/GetMemberById?identityId={id}");
        //    _logger.LogDebug("[GetSiteMapByIdentity] -> response code {StatusCode}", response.StatusCode);

        //    var responseString = await response.Content.ReadAsStringAsync();

        //    return string.IsNullOrEmpty(responseString) ?
        //        new tbl_SiteMap() { Id = 0 } :
        //        JsonConvert.DeserializeObject<tbl_SiteMap>(responseString);
        //}

        //public async Task CreateSiteMap(CreateSiteMapCommand command)
        //{
        //    var uri = API.SiteMap.CreateSiteMap(_apiBaseUrl);
        //    _logger.LogDebug("[CreateSiteMap] -> Calling {Uri} to get the member", uri);

        //    var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync(uri, data);

        //}
    }
}
