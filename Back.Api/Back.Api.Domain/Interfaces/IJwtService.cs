using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Domain.Interfaces
{
    public interface IJwtService
    {
        string GetToken(string email);
    }
}
