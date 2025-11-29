using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Application.Exceptions
{
    public class EntityNotExistException : Exception
    {
        public EntityNotExistException(string message) : base(message)
        {
        }
    }
}
