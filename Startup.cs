using System;
using System.Collections.Generic;
using System.Linq;
using FAQApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace FAQApi
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
            services.AddDbContext<FAQContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FAQDatabase")));
            services.AddControllers();
            services.AddCors();

            //services.AddMvc();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddReact()

            //// Make sure a JS engine is registered, or you will get an error!
            //services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
            //  .AddChakraCore();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(
                options => options.WithOrigins("https://localhost:44382").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var dataText = System.IO.File.ReadAllText(@"JSUtility/catagory1.json");
            Seeder.Seedit(dataText, app.ApplicationServices);
            app.UseStaticFiles();

        }
    }
}
