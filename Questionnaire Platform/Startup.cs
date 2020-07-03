using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Api.Filters;
using Questionnaire.Core.Abstractions;
using Questionnaire.Core.Abstractions.Services;
using Questionnaire.Core.Automapper;
using Questionnaire.Dal;
using Questionnaire.Services;

namespace Questionnaire.Api
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
            services.AddDbContext<QuestionnaireDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("QuestionnaireDbConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers(options =>
            {
                options.Filters.Add<CatchAllExceptionAttribute>(int.MaxValue);
            });

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Questionnaire API");
                    c.RoutePrefix = string.Empty;
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
