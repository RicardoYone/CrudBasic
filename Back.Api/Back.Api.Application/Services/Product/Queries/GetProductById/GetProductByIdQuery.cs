using Back.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Application.Services.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductEntity>
    {
        public int Id { get; set; }
    }
}
