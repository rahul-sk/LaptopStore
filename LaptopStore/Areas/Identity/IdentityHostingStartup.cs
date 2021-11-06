using System;
using LaptopStore.Areas.Identity.Data;
using LaptopStore.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LaptopStore.Areas.Identity.IdentityHostingStartup))]
namespace LaptopStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LaptopStoreDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LaptopStoreDBContextConnection")));

                services.AddDefaultIdentity<LaptopStoreUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;


                    })
                    .AddEntityFrameworkStores<LaptopStoreDBContext>();
            });
        }
    }
}