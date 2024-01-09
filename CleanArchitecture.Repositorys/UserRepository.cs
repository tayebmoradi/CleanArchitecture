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
            var record = await _databaseContext.Users
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync(cancellationToken);
           record.Name = Name;
            
            try
            {
                await _databaseContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
