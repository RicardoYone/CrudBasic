using Back.Api.Domain.Entities;
using Back.Api.Domain.Interfaces;
using Back.Api.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(ProductEntity entity)
        {
            await _context.Product.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Delete(ProductEntity entity)
        {
            _context.Product.Remove(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<ProductEntity>> Get()
        {
            return await _context.Product.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<ProductEntity> GetById(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(ProductEntity entity)
        {
            _context.Product.Update(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
