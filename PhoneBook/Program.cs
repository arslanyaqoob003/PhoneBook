using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PhoneBook
{
    /// <summary>
    /// ASP.Net Core run this class main method on start
    /// Used to register server configurations and envirnment configurations
    /// </summary>
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
    }
}
