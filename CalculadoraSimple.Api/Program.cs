using CalculadoraSimple.Api.Middleware;
using CalculadoraSimple.Application;
using CalculadoraSimple.Application.Dtos;
using CalculadoraSimple.Domain;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .SelectMany(x => x.Value!.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            var message = errors.Any()
                ? string.Join(" | ", errors)
                : "La solicitud contiene datos inválidos.";

            var response = new CalculatorResponseDto
            {
                Success = false,
                Message = message,
                Result = null
            };

            return new BadRequestObjectResult(response);
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CalculatorService>();
builder.Services.AddTransient<CalculatorUseCase>();
builder.Services.AddTransient<Utils>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
