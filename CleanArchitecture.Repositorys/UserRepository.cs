using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            
        }
        public async Task<bool> AddUser(string name, CancellationToken cancellationToken)
        {
            _databaseContext.Users.Add(new User { Name = name });
            try
            {
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public async Task<List<User>> GetUsers(CancellationToken cancellationToken)
        {
            var record = await _databaseContext.Users.AsNoTracking().ToListAsync(cancellationToken);
            return record;
        }

        public async Task<bool> UpdateUser(int Id, string Name, CancellationToken cancellationToken)
        {
            var record = _databaseContext.Users.Where(p => p.Id == Id).FirstOrDefault();

            var user = new User()
            {
                Id = record.Id,
                Name = Name,
            };
            _databaseContext.Update(user);
            await _databaseContext.SaveChangesAsync();
            return true;


        }
    }
}
