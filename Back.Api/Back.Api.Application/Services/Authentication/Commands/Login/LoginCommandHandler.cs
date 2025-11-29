using Back.Api.Application.Common;
using Back.Api.Application.Exceptions;
using Back.Api.Application.Services.Authentication.Dto;
using Back.Api.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Application.Services.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, SessionDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;
        public LoginCommandHandler(IUserRepository userRepository,
             IConfiguration configuration,
             IJwtService jwtService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _jwtService = jwtService;
        }
        public async Task<SessionDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //await ValidateCommand(request);

            var response = new SessionDto();

            var user = await _userRepository.GetByEmail(request.Email);
            if (user == null)
                throw new CommandValidationException("Email o contraseña incorrectos");

            // Desencripta la contraseña almacenada y la recibida
            //var passwordInput = Util.DecryptString(request.Password);
            //var passwordDb = Util.DecryptString(user.Password);

            //if (passwordInput != passwordDb)
            if (request.Password != user.Password)
                throw new CommandValidationException("Email o contraseña incorrectos");

            var token = _jwtService.GetToken(user.Email);

            response = new SessionDto
            {
                Email = user.Email,
                Password = user.Password,
                Token = token
            };

            return response;
        }
        //private async Task ValidateCommand(LoginCommand request)
        //{
        //}
    }
}
