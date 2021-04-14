using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SeerBitDotNetAPILibrary.Exchange;
using SeerBitDotNetAPILibrary.Interface;
using SeerBitDotNetAPILibrary.Model;
using SeerBitDotNetAPILibrary.Service;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SeerBitDotNetLibrary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IAccount, AccountService>();
            services.AddScoped<IAuthentication, AuthenticationService>();
            services.AddScoped<IAuthorise, AuthoriseService>();
            services.AddScoped<ICard, CardService>();
            services.AddScoped<IMomo, MomoService>();
            services.AddScoped<INon3DS, Non3DSService>();
            services.AddScoped<IOrderCheckOut, OrderCheckOutService>();
            services.AddScoped<IPaymentMethod, PaymentMethodService>();
            services.AddScoped<IPreAuthorization, PreAuthorizationService>();
            services.AddScoped<IRecurrent, RecurrentService>();
            services.AddScoped<IStandardCheckOut, StandardCheckOutService>();
            services.AddScoped<ITokenize, TokenizeService>();
            services.AddHttpClient<Interchange>();


            services.Configure<SeerBitSettingsModel>(Configuration.GetSection("seerBitSettings"));

            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new Info { Title = "Mobile Cash", Version = "V1" });
                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = "header",
                //    Type = "apiKey"
                //});

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelRendering(ModelRendering.Example);
                c.SwaggerEndpoint("v1/swagger.json", "SeerBitDotNetLibrary");
                c.RoutePrefix = "swagger";
            });

            app.UseMvc();
        }
    }
}
