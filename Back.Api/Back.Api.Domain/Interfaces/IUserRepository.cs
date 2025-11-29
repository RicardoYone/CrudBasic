using Back.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> Get();
        Task<UserEntity> GetById(int id);
        Task<UserEntity> GetByEmail(string email);
        Task<bool> Create(UserEntity user);
        Task<bool> Update(UserEntity user);
        Task<bool> Delete(UserEntity user);
    }
}
