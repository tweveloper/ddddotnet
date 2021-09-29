using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
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
        public async Task<List<tbl_SiteMap>> GetRoleSiteMap(long id)
        {
            var uri = API.SiteMap.GetRoleSiteMap(_apiBaseUrl, id);
            _logger.LogDebug("[GetRoleSiteMap] -> Calling {Uri} to get the RoleSiteMap", uri);

            var response = await _httpClient.GetAsync(uri);
            _logger.LogDebug("[GetRoleSiteMap] -> response code {StatusCode}", response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ?
                new List<tbl_SiteMap>() : JsonConvert.DeserializeObject<List<tbl_SiteMap>>(responseString);
        }

        public async Task<List<tbl_SiteMap>> SiteMapList()
        {
            var uri = API.SiteMap.SiteMapList(_apiBaseUrl);
            _logger.LogDebug("[SiteMapList] -> Calling {Uri} to get the SiteMapList", uri);

            var response = await _httpClient.GetAsync(uri);
            _logger.LogDebug("[SiteMapList] -> response code {StatusCode}", response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ?
                new List<tbl_SiteMap>() : JsonConvert.DeserializeObject<List<tbl_SiteMap>>(responseString);
        }

        public async Task<tbl_SiteMap> SiteMapInfo(long id)
        {
            var uri = API.SiteMap.SiteMapInfo(_apiBaseUrl, id);
            _logger.LogDebug("[SiteMapInfo] -> Calling {Uri} to get the SiteMapInfo", uri);

            var response = await _httpClient.GetAsync(uri);
            _logger.LogDebug("[SiteMapInfo] -> response code {StatusCode}", response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(responseString) ?
                new tbl_SiteMap() : JsonConvert.DeserializeObject<tbl_SiteMap>(responseString);
        }

        public async Task<string> UpdateSiteMapInfo(UpdateSiteMapInfoCommand command)
        {
            var uri = API.SiteMap.UpdateSiteMapInfo(_apiBaseUrl);
            _logger.LogDebug("[UpdateSiteMapInfo] -> Calling {Uri} to get the SiteMapInfo", uri);

            var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, data);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<string> CreateRootNode(CreateRootNodeCommand command)
        {
            var uri = API.SiteMap.CreateRootNode(_apiBaseUrl);
            _logger.LogDebug("[CreateRootNode] -> Calling {Uri} to get the CreateRootNode", uri);

            var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, data);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<string> CreateSiteMap(CreateSiteMapCommand command)
        {
            var uri = API.SiteMap.CreateSiteMap(_apiBaseUrl);
            _logger.LogDebug("[CreateSiteMap] -> Calling {Uri} to get the CreateSiteMap", uri);

            var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, data);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<string> ChangePosition(ChangePositionCommand command)
        {
            var uri = API.SiteMap.ChangePosition(_apiBaseUrl);
            _logger.LogDebug("[ChangePosition] -> Calling {Uri} to get the ChangePosition", uri);

            var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, data);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<string> DeleteSiteMap(DeleteSiteMapCommand command)
        {
            var uri = API.SiteMap.DeleteSiteMap(_apiBaseUrl);
            _logger.LogDebug("[DeleteSiteMap] -> Calling {Uri} to get the DeleteSiteMap", uri);

            var data = new StringContent(JsonConvert.SerializeObject(command), System.Text.Encoding.UTF8, "application/json");

            //var response = await _httpClient.DeleteAsync(uri);
            var response = await _httpClient.PutAsync(uri, data);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
