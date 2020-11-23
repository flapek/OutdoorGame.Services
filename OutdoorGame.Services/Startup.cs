using System;
using Joint;
using Joint.DB.Mongo;
using Joint.Docs.Swagger;
using Joint.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OutdoorGame.Services.Core.Repositories;
using OutdoorGame.Services.Infrastructure.Exceptions;
using OutdoorGame.Services.Infrastructure.Mongo;
using OutdoorGame.Services.Infrastructure.Repositories;

namespace OutdoorGame.Services
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
            services.AddCors();

            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IGameRepository, GameRepository>();

            services.AddControllers();
            services.AddJoint()
                .AddSwaggerDocs()
                .AddMongo()
                .AddMongoRepository<QuestionDocument, Guid>("Question")
                .AddMongoRepository<GameDocument, Guid>("Game")
                .AddErrorHandler<ExceptionToResponseMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocs()
                .UseErrorHandler();
            //.UseMongo();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
