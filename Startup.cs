using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace martyhope.com
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = new FileServerOptions
            {
                EnableDefaultFiles = true
            };
            options.StaticFileOptions.ServeUnknownFileTypes = true;

            app.UseFileServer(options)
                .UseDefaultFiles()
                .UseStaticFiles(new StaticFileOptions
                    {
                        OnPrepareResponse = ctx =>
                        {
                            // Requires the following import:
                            // using Microsoft.AspNetCore.Http;
                            ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
                        }
                    }
                )
                .UseMvc();
        }
    }
}
