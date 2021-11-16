using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SS.StudentStore.Services.Core.Features.Product;
using SS.StudentStore.Services.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using SS.StudentStore.Services.API.Extensions;

namespace SS.StudentStore.Services.API
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
            var connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddMvcCore(option => option.EnableEndpointRouting = false);
            services.AddControllers();
            services.AddMediatR(typeof(GetAllProductQueryHandler).Assembly);
            services.AddDbContext<CoreDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<CommonDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<StoreDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AppIdentityDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<OrderDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<StagingDBContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity(Configuration);
            services.AddSwaggerDoc();
            //services.AddAuthentication();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers["Expires"] = "0";
                context.Response.Headers["cache-control"] = "no-cache; no-store";
                context.Response.Headers["X-Frame-Options"] = "SAMEORIGIN";
                context.Response.Headers["X-XSS-Protection"] = "1";
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                context.Response.Headers["Referrer-Policy"] = "strict-origin";
                context.Response.Headers["server"] = "None";
                //context.Response.Headers["Public-Key-Pins"] = "pin-sha256";
                context.Response.Headers.Remove("X-powered-by");
                await next();
            });
            string allowedOrigins = Configuration.GetValue("CORS:Origins", "*"); // later add domain here: "*.abc.com"

            app.UseCors(builder =>
            {
                if (allowedOrigins == "*")
                {
                    builder.AllowAnyOrigin();

                }
                else
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains().WithOrigins(allowedOrigins.Split(',', StringSplitOptions.RemoveEmptyEntries));
                }
                builder.AllowAnyMethod().AllowAnyHeader()
                //.AllowCredentials()
                .WithExposedHeaders("Content-Disposition");
            }
            );

            //app.UseRouting();
            app.UseAuthentication();
            //app.UseAuthorization();
            app.UseSwaggerDoc();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder) => builder.RegisterModule(new AutofacModule());
    }
}
