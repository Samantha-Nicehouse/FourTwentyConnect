using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dk.via.ftc.web.Data;
using System.Linq;
using System.Security.Claims;
using dk.via.ftc.web.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Cryptography;

namespace dk.via.ftc.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<IAdminService, CloudAdminService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDispensaryService, DispensaryService>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddAuthorization(options =>
            {

                options.AddPolicy("GuestAndMember", a => a.RequireAuthenticatedUser().RequireClaim("Level", "0", "1", "2", "3"));

                options.AddPolicy("SecurityLevel4", a => a.RequireAuthenticatedUser().RequireClaim("Level", "4", "5"));

                options.AddPolicy("DispensaryAdmin", a => a.RequireAuthenticatedUser().RequireClaim("Role", "DispensaryAdmin"));

                options.AddPolicy("SecurityLevel2", a => a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim levelClaim = context.User.FindFirst(claim => claim.Type.Equals("Level"));
                    if (levelClaim == null) return false;
                    return int.Parse(levelClaim.Value) >= 2;
                }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}