using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(CancellationToken cancellationToken);
        Task<bool> AddUser(string name,CancellationToken cancellationToken);
        Task<bool> UpdateUser(int Id, string Name, CancellationToken cancellationToken);
    }
}
