using Dieta_Ai.Api.Extensions;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");
// app.UseHttpsRedirection();
app.MapControllers();
app.Run();

