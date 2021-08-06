using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.ApplicationCore.Module;
using Microsoft.Extensions.Logging;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    #region | 인터페이스 |
    public interface IGitService
    {
        /// <summary>
        ///  Git Clone
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="gitRepository"></param>
        /// <param name="physicalPath"></param>
        public void Clone(string domain, string gitRepository, string physicalPath);
    }
    #endregion

    #region | 클래스 |
    public class GitService : IGitService, IWindowsServer
    {
        private readonly ILogger<GitService> _logger;

        public GitService(ILogger<GitService> logger)
        {
            _logger = logger;
        }

        public void Clone(string domain, string gitRepository, string physicalPath)
        {
            string command = $@"git clone {gitRepository} {physicalPath}\{domain}";

            var result = PowerShellRunner.Command(command);

            if (_logger != null)
            {
                _logger.LogInformation($"command : {command}");
                _logger.LogInformation($"result : {result}");
            }
        }
    }
    #endregion

}
