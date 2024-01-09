using CleanArchitecture.Application.Events;
using CleanArchitecture.Application.Interfaces;
using MediatR;

namespace CleanArchitecture.Application
{
    public class CreateUserEventHandler : INotificationHandler<CreateUserEvent>
    {
        private readonly IUserService _userService;

        public CreateUserEventHandler(IUserService userService)
        {
           _userService = userService;
        }

        public async Task Handle(CreateUserEvent notification, CancellationToken cancellationToken)
        {
            ////Sync
            //await Task.Delay(5000);
           await  _userService.AddUser(notification.Name,cancellationToken);
        }
    }
}
