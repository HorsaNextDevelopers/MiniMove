using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniMove.Areas.Identity.Data;
using MiniMove.Data;

[assembly: HostingStartup(typeof(MiniMove.Areas.Identity.IdentityHostingStartup))]
namespace MiniMove.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MiniMoveContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MiniMoveContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MiniMoveContext>();
            });
        }
    }
}