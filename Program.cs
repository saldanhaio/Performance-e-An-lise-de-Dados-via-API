using CodeconChallenge.Helpers;
using CodeconChallenge.Models;
using CodeconChallenge.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o serviço UserService à DI
builder.Services.AddSingleton<UserService>();

// Adicionando o MVC (API Controllers)
builder.Services.AddControllers();

// Configurando o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração de endpoints da API
app.MapControllers();

// Habilitando o Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera a documentação Swagger
    app.UseSwaggerUI(); // Exibe a interface Swagger UI para interação com a API
}

// Rodando a aplicação
app.Run();
