using Fiap.Project.Recipes.Api.Helpers;
using Fiap.Project.Recipes.Application.Interfaces;
using Fiap.Project.Recipes.Application.Middleware;
using Fiap.Project.Recipes.Application.Services;
using Fiap.Project.Recipes.Persistence.Contexts;
using Fiap.Project.Recipes.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Fiap.Project.Recipes.Api
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
            services.AddCors(x =>
            {
                x.AddPolicy("Default",
                builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod(); ;
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fiap.Project.Recipes.Api", Version = "v1" });
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Coloque SOMENTE O TOKEN no campo abaixo.",

                    Reference = new OpenApiReference
                    {
                        Id = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, System.Array.Empty<string>() }
                });

                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            var conSqlServer = Configuration["ConnectionStringSql"];
            services.AddDbContext<SqlDataContext>(options => options.UseSqlServer(conSqlServer));
            //services.AddDbContext<SqlDataContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=fiapMasterChef;Integrated Security=True;Connect Timeout=30;"));

            services.Configure<GzipCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(o =>
            {
                o.Providers.Add<GzipCompressionProvider>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiap.Project.Recipes.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("Default");
            app.UseRouting();
            app.UseResponseCompression();
            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
