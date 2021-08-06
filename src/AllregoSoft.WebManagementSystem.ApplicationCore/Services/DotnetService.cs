using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.ApplicationCore.Module;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    public interface IDotnetService
    {
        /// <summary>
        /// 게시
        /// </summary>
        /// <param name="csprojPath"></param>
        /// <param name="publishPath"></param>
        public void Publish(string csprojPath, string publishPath);
        /// <summary>
        /// 빌드
        /// </summary>
        /// <param name="csprojPath"></param>
        public void Build(string csprojPath);
        /// <summary>
        /// 복원
        /// </summary>
        /// <param name="csprojPath"></param>
        public void Restore(string csprojPath);
    }
    public class DotnetService : IDotnetService, IWindowsServer
    {
        private readonly ILogger<DotnetService> _logger;

        public DotnetService(ILogger<DotnetService> logger)
        {
            _logger = logger;
        }

        public void Build(string csprojPath)
        {
            var command = $"dotnet msbuild {csprojPath} /p:DeployOnBuild=true /p:Configuration=Release";

            var result = PowerShellRunner.Command(command);

            _logger.LogInformation($"command : {command}");
            _logger.LogInformation($"result : {result}");
        }

        public void Restore(string csprojPath)
        {
            var command = $"dotnet restore {csprojPath}";

            var result = PowerShellRunner.Command(command);

            _logger.LogInformation($"command : {command}");
            _logger.LogInformation($"result : {result}");
        }

        public void Publish(string csprojPath, string publishPath)
        {
            var command = $"dotnet publish {csprojPath} -c Release -p:UseAppHost=false -o:{publishPath}";

            var result = PowerShellRunner.Command(command);

            _logger.LogInformation($"command : {command}");
            _logger.LogInformation($"result : {result}");
        }
    }
}
