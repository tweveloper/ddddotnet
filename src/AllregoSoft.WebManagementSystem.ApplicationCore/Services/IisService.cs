using AllregoSoft.WebManagementSystem.ApplicationCore.ValueObjects;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.IO;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    #region | 인터페이스 |
    public interface IIisService
    {
        /// <summary>
        /// IIS Site List 가져오기
        /// </summary>
        /// <returns></returns>
        public List<IisSite> GetIISSiteList();
        /// <summary>
        /// Application Pool List 가져오기
        /// </summary>
        /// <returns></returns>
        public List<IisApplicationPool> GetApplicationPoolList();
        /// <summary>
        /// IIS Site 추가
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="physicalPath"></param>
        /// <param name="applicationPool"></param>
        /// <param name="port"></param>
        public void AddSite(string domain, string physicalPath, string applicationPool = null, int port = 80);
        /// <summary>
        /// IIS Application Pool 추가
        /// </summary>
        /// <param name="domain"></param>
        public void AddApplicationPool(string domain);
        /// <summary>
        /// IIS Site 제거
        /// </summary>
        /// <param name="domain"></param>
        public void RemoveSite(string domain);
        /// <summary>
        /// IIS Site 시작
        /// </summary>
        /// <param name="domain"></param>
        public void StartSite(string domain);
        /// <summary>
        /// IIS Site 중지
        /// </summary>
        /// <param name="domain"></param>
        public void StopSite(string domain);
        /// <summary>
        /// IIS Application Pool 다시시작
        /// </summary>
        /// <param name="applicationPoolName"></param>
        public void Recycle(string applicationPoolName);
        public void AddHosts(string domain);
    }
    #endregion

    #region | 클래스 |
    public class IisService : IIisService, IWindowsServer
    {
        private readonly ILogger<IisService> _logger;

        public IisService(ILogger<IisService> logger)
        {
            _logger = logger;
        }

        public void AddApplicationPool(string domain)
        {
            _logger.LogInformation("Start AddApplicationPool");
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    serverManager.ApplicationPools.Add(domain);

                    ApplicationPool apppool = serverManager.ApplicationPools[domain];
                    apppool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
                    apppool.ManagedRuntimeVersion = "";

                    serverManager.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void AddSite(string domain, string physicalPath, string applicationPool = null, int port = 80)
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    Site newSite = serverManager.Sites.Add(domain, "http", $"*:{port}:{domain}", physicalPath);
                    newSite.ServerAutoStart = true;

                    if (!string.IsNullOrEmpty(applicationPool))
                    {
                        serverManager.Sites[domain].Applications[0].ApplicationPoolName = applicationPool;
                    }

                    serverManager.CommitChanges();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public List<IisApplicationPool> GetApplicationPoolList()
        {
            List<IisApplicationPool> result = new List<IisApplicationPool>();
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    var poolList = serverManager.ApplicationPools;
                    foreach (var pool in poolList)
                    {
                        result.Add(new IisApplicationPool(pool.Name, pool.ManagedRuntimeVersion));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public List<IisSite> GetIISSiteList()
        {
            _logger.LogInformation("GetIISSiteList");
            List<IisSite> result = new List<IisSite>();
            try
            {
                using (var serverManager = new ServerManager())
                {
                    SiteCollection siteList = serverManager.Sites;
                    foreach (var site in siteList)
                    {
                        result.Add(new
                                    IisSite(site.Id,
                                            site.Name,
                                            site.Applications[0].ApplicationPoolName,
                                            "",
                                            site.Bindings[0].Host,
                                            site.Bindings[0].EndPoint.Port));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public void RemoveSite(string domain)
        {
            try
            {
                using (var serverManager = new ServerManager())
                {
                    var site = serverManager.Sites[domain];
                    serverManager.Sites.Remove(site);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void StartSite(string domain)
        {
            try
            {
                using (var serverManager = new ServerManager())
                {
                    serverManager.Sites[domain].Start();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void StopSite(string domain)
        {
            try
            {
                using (var serverManager = new ServerManager())
                {
                    serverManager.Sites[domain].Stop();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void Recycle(string applicationPoolName)
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    var pool = serverManager.ApplicationPools[applicationPoolName];
                    pool.Recycle();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void AddHosts(string domain)
        {
            try
            {
                using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts")))
                {
                    w.WriteLine($"127.0.0.1 {domain} #Add AllregoRentalMall");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
    #endregion
}
