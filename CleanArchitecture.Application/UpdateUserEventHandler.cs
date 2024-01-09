using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Events;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application
{
    public class UpdateUserEventHandler : INotificationHandler<UpdateUserEvent>
    {
        private readonly IUserService _userService;

        public UpdateUserEventHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task Handle(UpdateUserEvent notification, CancellationToken cancellationToken)
        {
            await _userService.UpdateUser(notification.Id,notification.UserName, cancellationToken);
        }
    }
}
