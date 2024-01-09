using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;  
        }

        public async Task<bool> AddUser(string name, CancellationToken cancellationToken)
        => await _userRepository.AddUser(name, cancellationToken);

        public async Task<List<User>> GetUsers(CancellationToken cancellationToken)
        => await _userRepository.GetUsers(cancellationToken);
    }
}
