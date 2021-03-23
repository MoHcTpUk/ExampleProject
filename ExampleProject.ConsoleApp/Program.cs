using System;
using System.Threading.Tasks;
using ExampleProject.App.Commands;
using MediatR;
using Configurator = ExampleProject.BLL.DI.Configurator;

namespace ExampleProject.ConsoleApp
{
    class Program
    {
        public static IMediator Mediator = Configurator.Mediator;

        static async Task Main(string[] args)
        {
            var resultCommand = await Mediator.Send(new ExsampleRequest());

            Console.WriteLine(resultCommand.Field);
        }
    }
}