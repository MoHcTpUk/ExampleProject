using MediatR;
using System;
using System.Threading.Tasks;
using Core.App;
using Core.App.Commands;

namespace ExampleProject.ConsoleApp
{
    class Program
    {
        public static IMediator Cmd = MediatorConfig.Mediator;

        static async Task Main(string[] args)
        {
            var resultCommand = await Cmd.Send(new ExsampleRequest());

            Console.WriteLine(resultCommand.Field);
        }
    }
}