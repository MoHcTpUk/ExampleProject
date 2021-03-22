﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.App.DI
{
    public static partial class Configurator
    {
        public static IMediator Mediator { get; set; }
        public static ServiceProvider ServiceProvider { get; }
        private static ServiceCollection ServiceCollection { get; }

        static Configurator()
        {
            ServiceCollection = new ServiceCollection();

            ConfigureRepositories(ServiceCollection);
            ConfigureServices(ServiceCollection);
            ConfigureDepencies(ServiceCollection);

            ServiceProvider = ServiceCollection.BuildServiceProvider();

            Mediator = ServiceProvider.GetService<IMediator>();
            //InitDb(ServiceProvider.GetService<ApplicationDbContext>());
        }
    }
}