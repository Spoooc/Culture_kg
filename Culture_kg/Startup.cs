using Culture_kg.Domain;
using Culture_kg.Domain.Repositiries.Abstract;
using Culture_kg.Domain.Repositiries.EntityFramework;
using Culture_kg.Service;
using Culture_kg.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Culture_kg
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            //Конфиг appsetting.json
            Configuration.Bind("Project", new Config());
            //string connection = Configuration.GetConnectionString("DefaultConnection");

            //Подключение БД
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Config.ConnectionString));
            //Добавление нужных функционалов сервиса
            services.AddTransient<IServicesItemsRepository, EFServicesItemRepository>();
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<DataManager>();

            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //настраиваем политику авторизации для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });
            //добавляем сервисы для контроллеров и представлений (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //выставляем совместимость с asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Latest).AddSessionStateTempDataProvider();


            //добавляем сервисы для контроллеров и представлений (MVC)
            services.AddControllersWithViews().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest).AddSessionStateTempDataProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ошибки
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //подключаем поддержку статичных файлов в приложении (css, js и т.д.)
            app.UseStaticFiles();

            //система маршрутизации
            app.UseRouting();

            //подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //регистриуруем нужные нам маршруты (ендпоинты)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
