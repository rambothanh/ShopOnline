using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:6888/api/") });
            //await builder.Build().RunAsync();
            //Get value from appsettings.json
            var url = builder.Configuration.GetValue<string>("BaseAPI");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });
            await builder.Build().RunAsync();

        }


    }
}
