using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Api.Domain.Entities;

namespace Back.Api.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> Get();
        Task<ProductEntity> GetById(int id);
        Task<bool> Create(ProductEntity product);
        Task<bool> Update(ProductEntity product);
        Task<bool> Delete(ProductEntity product);
    }
}
