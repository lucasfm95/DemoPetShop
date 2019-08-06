using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPetShop.Repository.AnimalRepository;
using DemoPetShop.Repository.Repository.Interface;
using DemoPetShop.Services.Services;
using DemoPetShop.Services.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDBRepository.Repository.Context;
using Serilog;
using Serilog.Events;

namespace DemoPetShop
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.Configure<CookiePolicyOptions>( options =>
             {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                 options.MinimumSameSitePolicy = SameSiteMode.None;
             } );

            IConnectionFactory connectionFactory = new ConnectionFactory( "mongodb://localhost:27017" );

            services.AddSingleton<IConnectionFactory>( connectionFactory );
            services.AddSingleton<IAnimalRepository, AnimalRepository>( );
            services.AddTransient<IAnimalService, AnimalService>( );

            services.AddMvc( ).SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            Log.Logger = new LoggerConfiguration( )
                .MinimumLevel.Debug( )
                .MinimumLevel.Override( "Microsoft", LogEventLevel.Information )
                .Enrich.FromLogContext( )
                .WriteTo.Console( )
                .WriteTo.File( @".\log\log.txt" )
                .WriteTo.MongoDB( "mongodb://localhost:27017/logs", collectionName: "applog" )
                .CreateLogger( );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment( ) )
            {
                app.UseDeveloperExceptionPage( );
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
            }

            app.UseStaticFiles( );
            app.UseCookiePolicy( );

            app.UseMvc( routes =>
             {
                 routes.MapRoute(
                     name: "default",
                     template: "{controller=Home}/{action=Index}/{id?}" );
             } );
        }
    }
}
