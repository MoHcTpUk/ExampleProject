﻿using ExampleProject.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.BLL.DI
{
    public static partial class Configurator
    {
        private static void ConfigureRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<ExampleRepositoryAbstract, ExampleRepository>()
                ;
        }
    }
}