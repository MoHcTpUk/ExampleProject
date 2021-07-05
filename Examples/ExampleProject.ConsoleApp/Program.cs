using MediatR;
using System;
using System.Threading.Tasks;
using ExampleProject.App;
using ExampleProject.App.Commands;

namespace ExampleProject.ConsoleApp
{
    class Program
    {
        public static IMediator Cmd = MediatorConfig.Mediator;

        static async Task Main(string[] args)
        {

            var resultCommand = await Cmd.Send(new AuthenticateRequest());

            Console.WriteLine(resultCommand);
        }
    }
}