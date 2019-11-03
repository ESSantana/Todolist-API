using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToDo.Mappers;
using ToDo.Repository;
using ToDo.Services;

namespace ToDo
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
            services.AddControllers();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<TodoContext>(options => options.UseNpgsql($"Server=127.0.0.1;Port=5432;username=postgres;password=pass;database=todolist"))
                .BuildServiceProvider();

            services.AddAutoMapper( new Assembly[] {typeof(AutoMapperProfile).GetTypeInfo().Assembly});

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo{
                    Description = "ToDo List API",
                    Title = "ToDo List API",
                    Version = "V1"
                });
            });

            #region Dependency Injection

            services.AddHttpContextAccessor();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddTransient<TodoContext>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI( s => {
                s.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
            });
        }
    }
}
