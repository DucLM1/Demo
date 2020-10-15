using Demo.Filters;
using Demo.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo
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
            services.AddControllersWithViews();
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(typeof(TimeElapsedFilter),
            //                        int.MinValue);
            //});
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Use First delegate  request");
            //    await next.Invoke();
            //});

            //app.Map("/Home/Testing2", a => a.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Use 2nd delegate.");
            //}));

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Use 3rd delegate.");
            //});

            //app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/robots.txt"), b =>
            //    b.UseMiddleware<RobotsTxtMiddleware>(env.EnvironmentName, env.WebRootPath));

            //app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/Home/testing2"), b =>
            //    b.UseMiddleware<CachePageMiddleware>());

            //app.UseCachePageMiddleware();
            //app.UseReturnMiddleware();
            //app.UseRedirect301Middleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}