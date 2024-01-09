using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using MediatR;

namespace CleanArchitecture.Application
{
    public class GetUsersRequest : IRequest<List<GetUserDto>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersRequest, List<GetUserDto>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<GetUserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetUsers(cancellationToken);

            var record= await Task.FromResult(users.Select(x => new GetUserDto() { Id = x.Id, Name = x.Name }).ToList());
            return record;

        }
    }
}
