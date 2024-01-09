using CleanArchitecture.Application.Events;
using MediatR;

namespace CleanArchitecture.Application
{
    public class CreateUserRequest : IRequest
    {
        public string Name { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest>
    {
        private readonly IMediator mediator;

        public CreateUserCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            //Business logic locally to update the writing database

            //Publish an event to synchronise both read/write dbs
            mediator.Publish(new CreateUserEvent() { Name = request.Name });
            return Task.CompletedTask;
        }
    }
}
