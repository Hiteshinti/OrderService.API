using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.MiddileWare
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _context;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate context, ILogger<ExceptionMiddleware> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _context(httpcontext);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                httpcontext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError("message: {Message}", ex.Message +"_"+ex.StackTrace);
                await httpcontext.Response.WriteAsync("An unexpected error occurred. Please try again later.");
            }
        }

    }
}
