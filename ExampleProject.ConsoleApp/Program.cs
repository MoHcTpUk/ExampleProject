using System;
using System.Threading.Tasks;
using ExampleProject.App.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Configurator = ExampleProject.BLL.DI.Configurator;

namespace ExampleProject.ConsoleApp
{
    class Program
    {
        public static IMediator Cmd;

        static async Task Main(string[] args)
        {
            Cmd = App.MediatorConfig.Configure(Configurator.ServiceProvider.GetService<IMediator>());

            var resultCommand = await Cmd.Send(new ExsampleRequest());

            Console.WriteLine(resultCommand.Field);
        }
    }
}