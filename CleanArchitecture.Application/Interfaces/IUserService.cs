using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers(CancellationToken cancellationToken);
        Task<bool> AddUser(string name, CancellationToken cancellationToken);
    }
}
