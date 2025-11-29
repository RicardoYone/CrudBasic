using Back.Api.Application.Exceptions;
using System.Net;

namespace Back.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CommandValidationException ex)
            {
                var response = new BaseResponseModel<bool>();
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsJsonAsync(response);
            }
            catch (EntityNotExistException ex)
            {
                var response = new BaseResponseModel<bool>();
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                var response = new BaseResponseModel<bool>();
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "Por favor, contacte con el administrador.";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
