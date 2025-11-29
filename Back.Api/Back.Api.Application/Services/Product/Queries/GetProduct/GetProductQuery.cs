using Back.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Application.Services.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<List<ProductEntity>>
    {
    }
}
