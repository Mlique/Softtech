using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Softtech.Data;
using Softtech.Models;
using Softtech.Repositories;
using Softtech.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech
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
            services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.Name = "UserLoginCookie";
                    config.LoginPath = "/Account/Login";
                });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<ResManagementDBContext>().AddDefaultTokenProviders();
            services.AddDbContext<ResManagementDBContext>(options => options.UseSqlServer(Configuration["Data:ConnectionString:ResConnection"]));
            services.AddControllersWithViews();

            services.AddAutoMapper();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IBookingRepository, BookingRepository>();
             services.AddTransient<IInspectionRepository, InspectionRepository>();
            services.AddTransient<IFaultRepository, FaultRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(20);
                opts.Cookie.HttpOnly = true;
            });
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
