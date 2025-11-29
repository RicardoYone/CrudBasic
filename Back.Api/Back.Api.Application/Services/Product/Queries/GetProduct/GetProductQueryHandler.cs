using Back.Api.Domain.Interfaces;
using Back.Api.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Back.Api.Application.Services.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductEntity>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductEntity>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.Get();
            return products;
        }
    }
}
