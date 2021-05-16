using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hfind.Repositories;
using hfind.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace hfind
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
            
            var JwtSettings = new JwtSettings();
            Configuration.Bind(key: nameof(JwtSettings), JwtSettings);
            services.AddSingleton(JwtSettings);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>{
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            
            services.AddAuthentication(configureOptions: x =>{
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes(JwtSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
            //     services.Configure<UsersDatabaseSettings>(
            //    Configuration.GetSection(nameof(UsersDatabaseSettings)));

            // services.AddSingleton<HUsersDatabaseSettings>(sp =>
            //   sp.GetRequiredService<IOptions<UsersDatabaseSettings>>().Value);

                services.AddControllers();
            // services.AddAuthentication(options =>
            //  {
            //      options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //      options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //      options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            // })
            // .AddCookie()
            // .AddOpenIdConnect("Auth", options =>
            // {
            //     options.Authority = $"https://{Configuration["Auth0:Domain"]}";
            //     options.ClientId = Configuration["Auth0:ClientId"];
            //     options.ClientSecret = Configuration["Auth0:ClientSecret"];
            //     options.ResponseType = OpenIdConnectResponseType.Code;
            //     options.Scope.Clear();
            //     options.Scope.Add("openid");
            //     options.CallbackPath = new PathString("/callback");
            //     options.ClaimsIssuer = "Auth0";

            // });
             BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddSingleton<IMongoClient>(servicesProvider =>
            
           {
             var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                return new MongoClient(settings.ConnectionString);

           });
           services.AddSingleton<UUsersRepository, MongoDbUsersRepository>();
            services.AddSingleton<HHousesRepository, MongoDbHousesRepository>();
            services.AddControllers(options =>{
                options.SuppressAsyncSuffixInActionNames = false;

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hfind", Version = "v1" });
                var security = new Dictionary<string,IEnumerable<string>>
                {
                    {"Bearer", new string[0]}
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description ="JWT Authorization header using the bearer scheme",
                    Name = "Aurhorization",
                    In = ParameterLocation.Header,
                    Type =SecuritySchemeType.ApiKey,
                     Scheme = "Bearer"
                });
               c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                         {
                          new OpenApiSecurityScheme
                             {
                              Reference = new OpenApiReference
                                {
                                  Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                                 },
                             Scheme = "oauth2",
                             Name = "Bearer",
                            In = ParameterLocation.Header,

                         },
                         new List<string>()
                         }
                    });
           
              });
           
           
         
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hfind v1"));
            }
                if(env.IsDevelopment()){
            app.UseHttpsRedirection();
                }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("MyPolicy");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/heal");
            });
        }
    }
}
