using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Events;

namespace CleanArchitecture.Application
{
    public class UpdateUserRequest : IRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest>
    {
        private readonly IMediator mediator;

        public UpdateUserCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public  Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
             mediator.Publish(new UpdateUserEvent() { Id = request.Id ,UserName = request.UserName},cancellationToken); 
            return Task.CompletedTask;
        }
        
    }
}
