using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationsAboutToken.Interfaces;
using AuthorizationsAboutToken.Models;
using AuthorizationsAboutToken.Services;
using AutoMapper;
using BLL.ManageInterfaces;
using BLL.Managers;
using BLL.Services;
using DAL;
using DAL.Authorize;
using DAL.DBModels;
using DAL.Reposetories;
using DAL.UserModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OtherLogic.IRepo;

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

            services.AddScoped<IAuthenticateService, AuthenticateService>();
            #endregion 

            #region SQL connection
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ComDbContext>(options => options.UseSqlServer(connection));

           services.AddDbContext<ComDbContext>(options => options.UseSqlServer(connection));

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
            services.AddScoped<IBaseRepository<Artist>, BaseRepository<Artist>>();
            services.AddScoped<IBaseRepository<Author>, BaseRepository<Author>>();
            services.AddScoped<IBaseRepository<Corrector>, BaseRepository<Corrector>>();
            services.AddScoped<IBaseRepository<Illustrator>, BaseRepository<Illustrator>>();
            services.AddScoped<IBaseRepository<Publisher>, BaseRepository<Publisher>>();
            services.AddScoped<IBaseRepository<Tag>, BaseRepository<Tag>>();



            services.AddScoped<IBaseRepository<TokenManagemant>, BaseRepository<TokenManagemant>>();
            #endregion
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            //services.AddScoped<IComicsManager, ComicsManager>();
            //services.AddScoped<IUserManagementService, UserManagementService>();
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
                app.UseHsts();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
