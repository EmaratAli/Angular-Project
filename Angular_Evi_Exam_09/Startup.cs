using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Angular_Evi_Exam_09.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Angular_Evi_Exam_09.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Angular_Evi_Exam_09
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("prodDbSecurity")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(opp => { });
            services.ConfigureApplicationCookie(op =>
            {
                op.Cookie.HttpOnly = true;
                op.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                op.LoginPath = "/Account/Login";
                //op.AccessDeniedPath = "/Account/AccessDenied";
                op.SlidingExpiration = true;
            });

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("prodDb")));
            services.AddMvc();
            services.AddScoped<IRepo, ProductRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(route =>
                {
                    route.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
