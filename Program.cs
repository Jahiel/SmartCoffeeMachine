using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services nécessaires à l'application
builder.Services.AddControllers(); // Active les contrôleurs via attributs [ApiController], [Route], etc.
builder.Services.AddEndpointsApiExplorer(); // Pour Swagger
builder.Services.AddSwaggerGen(); // Génère la doc Swagger

var app = builder.Build();

// Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirige automatiquement le HTTP vers HTTPS
app.UseAuthorization(); // Même si pas utilisé, c’est standard dans le pipeline

app.MapControllers(); // Active les routes de tes contrôleurs

app.Run();
