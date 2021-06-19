#region Using
using LiquorStore.Api.Core;
using LiquorStore.Application;
using LiquorStore.Application.Commands;
using LiquorStore.Application.Commands.ILiquorBrandCommands;
using LiquorStore.Application.Commands.ILiquorCommands;
using LiquorStore.Application.Commands.ILiquorSizeCommands;
using LiquorStore.Application.Commands.IUserCommands;
using LiquorStore.Application.Email;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Queries.ILiquorBrandQueries;
using LiquorStore.Application.Queries.ILiquorQueries;
using LiquorStore.Application.Queries.ILiquorSizeQueries;
using LiquorStore.Application.Queries.IUserQueries;
using LiquorStore.DataAccess;
using LiquorStore.Implementation.Commands;
using LiquorStore.Implementation.Commands.LiquorBrandCommands;
using LiquorStore.Implementation.Commands.LiquorCommands;
using LiquorStore.Implementation.Commands.LiquorSizeCommands;
using LiquorStore.Implementation.Commands.UserCommands;
using LiquorStore.Implementation.Email;
using LiquorStore.Implementation.Logging;
using LiquorStore.Implementation.Queries;
using LiquorStore.Implementation.Queries.LiquorBrandQueries;
using LiquorStore.Implementation.Queries.LiquorQueries;
using LiquorStore.Implementation.Queries.LiquorSizeQueries;
using LiquorStore.Implementation.Queries.UserQueries;
using LiquorStore.Implementation.Validators;
using LiquorStore.Implementation.Validators.LilquorValidators;
using LiquorStore.Implementation.Validators.LiquorBrandValidators;
using LiquorStore.Implementation.Validators.LiquorSizeValidators;
using LiquorStore.Implementation.Validators.OrderValidators;
using LiquorStore.Implementation.Validators.UserValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace LiquorStore.Api
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
            services.AddTransient<LiquorStoreContext>();
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x => 
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if(user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });
            services.AddTransient<IUseCaseLogger, DbUseCaseLogger>();
            services.AddTransient<UseCaseExecutor>();

            services.AddTransient<JwtManager>();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Service for orders
            services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();

            // Service for email
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<EmailSender>();

            // Services for user actions
            services.AddTransient<IGetUsersQuery, GetUsersQuery>();
            services.AddTransient<IGetSingleUserQuery, GetSingleUserQuery>();
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();

            // Services for liquor actions
            services.AddTransient<IGetLiquorsQuery, GetLiquorsQuery>();
            services.AddTransient<IGetSingleLiquorQuery, GetSingleLiquorQuery>();
            services.AddTransient<ICreateLiquorCommand, CreateLiquorCommand>();
            services.AddTransient<IUpdateLiquorCommand, UpdateLiquorCommand>();
            services.AddTransient<IDeleteLiquorCommand, DeleteLiquorCommand>();

            // Services for liquor size actions
            services.AddTransient<IGetLiquorSizesQuery, GetLiquorSizesQuery>();
            services.AddTransient<IGetSingleLiquorSizeQuery, GetSingleLiquorSizeQuery>();
            services.AddTransient<ICreateLiquorSizeCommand, CreateLiquorSizeCommand>();
            services.AddTransient<IUpdateLiquorSizeCommand, UpdateLiquorSizeCommand>();
            services.AddTransient<IDeleteLiquorSizeCommand, DeleteLiquorSizeCommand>();

            // Services for liquor brand actions
            services.AddTransient<IGetLiquorBrandsQuery, GetLiquorBrandsQuery>();
            services.AddTransient<IGetSingleLiquorBrandQuery, GetSingleLiquorBrand>();
            services.AddTransient<ICreateLiquorBrandCommand, CreateLiquorBrandCommand>();
            services.AddTransient<IUpdateLiquorBrandCommand, UpdateLiquorBrandCommand>();
            services.AddTransient<IDeleteLiquorBrandCommand, DeleteLiquorBrandCommand>();

            // Services for liquor group actions
            services.AddTransient<IGetLiquorTypesQuery, GetLiquorTypesQuery>();
            services.AddTransient<IGetSingleLiquorType, GetSingleLiquorType>();
            services.AddTransient<ICreateLiquorTypeCommand, CreateLiquorTypeCommand>();
            services.AddTransient<IUpdateLiquorTypeCommand, UpdateLiquorTypeCommand>();
            services.AddTransient<IDeleteLiquorTypeCommand, DeleteLiquorTypeCommand>();

            // Validators 
            // Order validators 
            services.AddTransient<OrderValidator>();
            // User validators
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            // Liquor validators
            services.AddTransient<CreateLiquorValidator>();
            services.AddTransient<UpdateLiquorValidator>();
            // Liquor type validators
            services.AddTransient<CreateLiquorTypeValidator>();
            services.AddTransient<UpdateLiquorTypeValidator>();
            // Liquor brand validators
            services.AddTransient<CreateLiquorBrandValidator>();
            services.AddTransient<UpdateLiquorBrandValidator>();
            // Liquor size validators
            services.AddTransient<CreateLiquorSizeValidator>();
            services.AddTransient<UpdateLiquorSizeValidator>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiquorStore.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiquorStore.Api v1"));
            }

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
