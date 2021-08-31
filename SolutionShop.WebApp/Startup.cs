using ApiIntegration;
using ApiIntegration.Services;
using FluentValidation.AspNetCore;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolutionShop.ApiIntegration;
using SolutionShop.ViewModel.System.Users;
using SolutionShop.WebApp.LocalizationResources;
using System;
using System.Globalization;

namespace SolutionShop.WebApp
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
            services.AddRazorPages()
       .AddRazorRuntimeCompilation();
            services.AddHttpClient();
            var cultures = new[]
              {
                new CultureInfo("en-US"),
                new CultureInfo("vi-VN"),
            };

            services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>()).
                AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
            {
                ops.UseAllCultureProviders = false;
                ops.ResourcesPath = "LocalizationResources";
                ops.RequestLocalizationOptions = o =>
                {
                    o.SupportedCultures = cultures;
                    o.SupportedUICultures = cultures;
                    o.DefaultRequestCulture = new RequestCulture("vi-VN");
                };
            }); services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login/";
                    options.AccessDeniedPath = "/User/Forbidden/";
                });
            services.AddSession(op =>
            {
                op.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ISlideApiClient, SlideApiClient>();
            services.AddTransient<IProductApiClient, ProductApiClient>();
            services.AddTransient<ICatergoryApiClient, CatergoryApiClient>();
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IOrderApiClient, OrderApiClient>();
            services.AddTransient<IContactApiClient, ContactApiClient>();
            services.AddTransient<ICommentApiClient, CommentApiClient>();
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
                app.UseExceptionHandler("/HomeW/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Product Category En",
                   pattern: "{culture}/categories/{id}", new
                   {
                       controller = "Product",
                       action = "Category"
                   });

                endpoints.MapControllerRoute(
                  name: "Product Category Vn",
                  pattern: "{culture}/danh-muc/{id}", new
                  {
                      controller = "Product",
                      action = "Category"
                  });

                endpoints.MapControllerRoute(
                    name: "Product Detail En",
                    pattern: "{culture}/{products}/{id}", new
                    {
                        controller = "Product",
                        action = "Detail"
                    });

                endpoints.MapControllerRoute(
                  name: "Product Detail Vn",
                  pattern: "{culture}/san-pham/{id}", new
                  {
                      controller = "Product",
                      action = "Detail"
                  });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{culture=vi}/{controller=HomeW}/{action=Index}/{id?}");
            });
        }
    }
}