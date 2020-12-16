using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Persistence;
using dk.via.ftc.businesslayer.Data.Services;
using Microsoft.Extensions.Caching.Memory;
using dk.via.ftc.businesslayer.Data;
using dk.via.ftc.businesslayer.Data.FTCAPI;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace dk.via.businesslayer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IVendorService_v2, VendorService_v2>();
            services.AddSingleton<IStrainAPIService, StrainAPIService>();
            services.AddSingleton<StrainContext>();
            services.AddSingleton<DispensaryLicencesContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDispensaryService, DispensaryService>();
            services.AddScoped<IAPIStrainService, APIStrainService>();
            services.AddScoped<IAPIProductService, APIProductService>();
            services.AddDataProtection();
            services.AddSwaggerGen(c =>
            {
                c.DocumentFilter<RemoveFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStrainAPIService sa, StrainContext sc)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseHttpsRedirection();
            var wsOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024
            };
            app.UseWebSockets(wsOptions);
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FTCAPI v1");
                c.RoutePrefix = string.Empty;
            });

        }
        
    }
    public class RemoveFilter : IDocumentFilter
    {

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //swaggerDoc.Components.Schemas.Remove("Product");
            //swaggerDoc.Components.Schemas.Remove("Effect");
            //swaggerDoc.Components.Schemas.Remove("Country");
            //swaggerDoc.Components.Schemas.Remove("Vendor");
            //swaggerDoc.Components.Schemas.Remove("VendorAdmin");
            //swaggerDoc.Components.Schemas.Remove("Dispensary");
            //swaggerDoc.Components.Schemas.Remove("PurchaseOrder");
            //swaggerDoc.Components.Schemas.Remove("Orderline");
            //swaggerDoc.Components.Schemas.Remove("Strain");
        }
    }
}
