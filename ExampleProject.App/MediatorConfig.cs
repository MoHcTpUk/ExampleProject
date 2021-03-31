using MediatR;

namespace ExampleProject.App
{
    public static class MediatorConfig
    {
        public static IMediator Mediator { get; private set; }

        public static IMediator Configure(IMediator mediator)
        {
            Mediator = mediator;

            return Mediator;
        }
    }
}