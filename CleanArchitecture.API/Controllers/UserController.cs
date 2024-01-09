using CleanArchitecture.Application;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUserService _userService;

        public UserController(IMediator mediator, IUserService userService)
        {
            this.mediator = mediator;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _userService.GetUsers(cancellationToken);
            var record = await mediator.Send(new GetUsersRequest());
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string name)
        {
            await mediator.Send(new CreateUserRequest { Name = name });
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await mediator.Send(new UpdateUserRequest { Id = user.Id,UserName = user.Name});
            return Ok();
        }
    }
}