using System.Reflection;
using AutoMapper;
using AviTrackr.Domain.Base.Entities;
using AviTrackr.Domain.Base.Services;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Data.Seeds;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace AviTrackr.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(BaseEntity).GetTypeInfo().Assembly);
            services.AddAutoMapper(typeof(BaseEntity).GetTypeInfo().Assembly);
            services.AddTransient<IMapperWrapper, MapperWrapper>();
            services.AddTransient<IPagingResponseService, PagingResponseService>();

            // configure database
            services.AddDbContext<AviTrackrDbContext>(options =>
            {
                options.UseLoggerFactory(MyLoggerFactory);
                options.UseSqlServer(Configuration.GetConnectionString("AviTrackrDbContext"));
            });
                

            // configure cors
            services.AddCors(options =>
                options.AddPolicy("dev", builder =>
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials()
                )
            );

            // configure authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    {
                        // base address of identity server
                        options.Authority = "http://localhost:4242"; // TODO: make configurable
                        options.RequireHttpsMetadata = false; // TODO: make configurable
                        options.Audience = "projects-api";
                    }
                );

            services
                .AddMvc()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AviTrackrDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("dev");
            }

            Mapper.Initialize(i => i.AddProfiles(typeof(BaseEntity).GetTypeInfo().Assembly));

            UserProfileSeed.Seed(context).Wait();
            NotificationTypeSeed.Seed(context).Wait();
            MyTaskStatusesSeed.Seed(context).Wait();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}