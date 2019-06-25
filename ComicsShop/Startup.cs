using System;
using System.Text;
using AuthorizationsAboutToken.Interfaces;
using AuthorizationsAboutToken.Models;
using AuthorizationsAboutToken.Services;
using AutoMapper;
using BLL.Managers;
using BLL.Services;
using DAL;
using DAL.DBModels;
using DAL.Reposetories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ComicsShop.BLL.Interfaces;
using OtherLogic.IRepo;
using Microsoft.AspNetCore;
using ComicsShop.DAL;

namespace ComicsShop
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
            #region Token

            services.Configure<TokenManagemant>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagemant>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            TokenValidationParameters ValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secret),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IAuthentificationService, AuthentificationService>();
            #endregion 

            #region NpgSQL connection
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ComicsDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                //.AddDefaultUI()
                .AddEntityFrameworkStores<ComicsDbContext>()
                .AddDefaultTokenProviders();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #region Repositories

            services.AddScoped<IBaseRepository<Comics>, BaseRepository<Comics>>();
            services.AddScoped<IBaseRepository<Tag>, BaseRepository<Tag>>();
            services.AddScoped<IBaseRepository<ApplicationUser>, BaseRepository<ApplicationUser>>();
            services.AddScoped<IBaseRepository<TokenManagemant>, BaseRepository<TokenManagemant>>();
            services.AddScoped<IBaseRepository<ComicsAuthor>,BaseRepository<ComicsAuthor>>();
            //services.AddScoped<IBaseRepository<ArtistDTO>, BaseRepository<ArtistDTO>>();
            services.AddScoped<IBaseRepository<TokenManagemant>, BaseRepository<TokenManagemant>>();
            #endregion

            services.AddScoped<IComicsManager, ComicsManager>();
            services.AddScoped<IComicsAuthorManager, ComicsAuthorManager>();
            //services.AddScoped<IComicsAuthorManager<ArtistDTO>, ComicsAuthorManager<ArtistDTO>>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings  
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings  
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings  
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddNLog();
            //loggerFactory.AddConsole();
            //loggerFactory.AddDebug();
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

        }
         
       public static IWebHost WebHostRun(IWebHost hosting,string[] args)
        {
            var host = hosting;
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    MyIdentityDataInitializer.SeedData(userManager, roleManager);
                }
                catch
                {

                }
            }
            //host.Run();
            return host;
        }
       
    }
    
}
