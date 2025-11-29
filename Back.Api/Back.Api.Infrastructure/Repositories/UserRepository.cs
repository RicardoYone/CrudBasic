using Back.Api.Domain.Entities;
using Back.Api.Domain.Interfaces;
using Back.Api.Persistence.DataBase;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(UserEntity entity)
        {
            await _context.User.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Delete(UserEntity entity)
        {
            _context.User.Remove(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<UserEntity>> Get()
        {
            return await _context.User.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<UserEntity> GetById(int id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> Update(UserEntity entity)
        {
            _context.User.Update(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
