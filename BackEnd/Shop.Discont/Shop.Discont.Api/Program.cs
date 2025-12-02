using Shop.Discont.Api.EndPoints.Cupom.MapCupomExtesion;
using Shop.Discont.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDependencyInjection();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCupom();
app.UseHttpsRedirection();
app.Run();