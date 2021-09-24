using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AllregoSoft.WebManagementSystem.WebAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static readonly string _namespace = typeof(Startup).Namespace;
        public static readonly string AppName = _namespace.Substring(_namespace.LastIndexOf('.', _namespace.LastIndexOf('.') - 1) + 1);
    }
}
