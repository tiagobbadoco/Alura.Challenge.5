using Alura.Challenge.Application.Models.InputModel;
using Alura.Challenge.Application.Services;
using Alura.Challenge.Application.Services.Interfaces;
using Alura.Challenge.Infrastructure.Data.Repositories;
using Alura.Challenge.Infrastructure.Data.Repositories.Interfaces;
using FluentValidation;

namespace Alura.Challenge.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(VideoInputModel).Assembly);
            services.AddValidatorsFromAssembly(typeof(CategoriaInputModel).Assembly);

            return services;
        }
    }
}