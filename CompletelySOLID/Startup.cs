//using ClassLibrary.EFAutoGen;
using ClassLibrary;// using custom dbcontext
using ClassLibrary.Interfaces;
//using custom db context
using ClassLibrary.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CompletelySOLID
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        

        //This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //need to instantiate the iconfig for appsettings to be able to read values to use in controllers
            services.AddSingleton(Configuration);
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            //dependency injection using .net core  service descriptor
            services.Add(new ServiceDescriptor(typeof(IHospitalContext), new HospitalContext()));
            services.Add(new ServiceDescriptor(typeof(IGuard), new Guard()));
            //configure DB context with connection string from appsettings.json (also have the app configuration class on model configuring to see both methods)
            //services.AddDbContext<HospitalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Context")));
            //edit later to make it safe against click jacking
            services.AddCors(options =>
            {
                options.AddPolicy(Configuration.GetValue<string>("PolicyName"),
                    builder =>
                    {

                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                    });
            });
            //create swagger values
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "HospitalCarl", Version = "v1" }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            //single page application react enabled cors to edit in vs code as well
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});
            //enable swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalCarl v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
