using Data.Contracts;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CED.Alpha.Data.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuizRepository, QuizRepository>();
            return services;
        }
    }
}