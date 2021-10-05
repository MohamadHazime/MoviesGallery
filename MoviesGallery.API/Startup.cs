using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoviesGallery.Core.Configurations;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Extensions;
using MoviesGallery.Core.Helpers;
using MoviesGallery.Core.Models;
using MoviesGallery.Core.PipelineBehaviours;
using MoviesGallery.Core.Services;
using MoviesGallery.Core.Validators;

namespace MoviesGallery.API
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
            services.Configure<MoviesDbConfig>(Configuration);

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddSingleton<IShowsService<Movie, MovieDetails>, MoviesService>();
            services.AddSingleton<IShowsService<TVShow, TVShowDetails>, TVShowsService>();
            services.AddSingleton<IMongoService, MongoService>();
            services.AddSingleton<IMongoShowsService<MovieDetailsDTO>, MongoMoviesService>();
            services.AddSingleton<IMongoShowsService<TVShowDetailsDTO>, MongoTVShowsService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviesGallery.API", Version = "v1" });
            });

            services.AddMediatR(
                Assembly.GetExecutingAssembly(),
                typeof(IShowsService<TVShow, TVShowDetails>).Assembly,
                typeof(IShowsService<Movie, MovieDetails>).Assembly,
                typeof(IMongoShowsService<MovieDetailsDTO>).Assembly,
                typeof(IMongoShowsService<TVShowDetailsDTO>).Assembly
            );

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            services.AddValidatorsFromAssembly(typeof(GetTopRatedMoviesQueryValidator).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesGallery.API v1"));
            }

            app.UseFluentValidationExceptionHandler();

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
