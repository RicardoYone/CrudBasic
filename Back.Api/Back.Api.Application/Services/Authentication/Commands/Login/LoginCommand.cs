using Back.Api.Application.Services.Authentication.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Application.Services.Authentication.Commands.Login
{
    public class LoginCommand : IRequest<SessionDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
