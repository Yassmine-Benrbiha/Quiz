using Components.Components;
using Components.Contracts;
using CED.Alpha.Data.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using Microsoft.Extensions.Configuration;

namespace Components.DependencyInjection
{
    public static class ComponentsServiceCollectionExtensions
    {
        public static IServiceCollection RegisterComponents(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.RegisterRepositories();
            services.AddScoped<IQuizComponent, QuizComponent>();
            return services;
        }
    }
}