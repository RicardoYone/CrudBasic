using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Back.Api.Application.Services.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public string? UserAudit { get; set; }
    }
}
