using System.Net;
using System.Text.Json;
using static Api.HealthMed.Helpers.Exceptions.CustomExceptions;

namespace Api.HealthMed.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro no processamento da requisição.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            // Define status code baseado no tipo da exceção
            context.Response.StatusCode = ex switch
            {
                CPFVazioException
                or EmailVazioException 
                or SenhaVaziaException
                or CRMVazioException 
                or CPFInvalidoException
                or EmailInvalidoException 
                or MedicoInvalidoException => (int)HttpStatusCode.BadRequest, // 400

                _ => (int)HttpStatusCode.InternalServerError // 500 para outras exceções
            };

            var response = new { erro = ex.Message };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}