using CalculadoraSimple.Application.Dtos;
using System.Net;
using System.Text.Json;

namespace CalculadoraSimple.Api.Middleware
{
    public class ExceptionHandlerMiddleware(RequestDelegate _next)
    {
        private readonly RequestDelegate next = _next;
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (DivideByZeroException ex)
            {
                await WriteErrorResponseAsync(
                    context,
                    HttpStatusCode.BadRequest,
                    ex.Message
                );
            }
            catch (Exception)
            {
                await WriteErrorResponseAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "Ocurrió un error interno en el servidor."
                );
            }
        }

        private static async Task WriteErrorResponseAsync(
            HttpContext context,
            HttpStatusCode statusCode,
            string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var response = new CalculatorResponseDto
            {
                Success = false,
                Message = message,
                Result = null
            };
            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await context.Response.WriteAsync(json);
        }
    }
}
