using Microsoft.EntityFrameworkCore;
using SmartCoffeeMachine.Core.CoffeeMachine.Class;
using SmartCoffeMachine.Core.CoffeeMachine.Class;
using SmartCoffeMachine.Core.CoffeeMachine.Interface;

var builder = WebApplication.CreateBuilder(args);

//Adding singleton to simulate current machine status (if it is turned on, it stay turned on until the project restart)
builder.Services.AddSingleton<ICoffeeMachine, CoffeeMachineStub>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //Enable Swagger annotations for documentation
    c.EnableAnnotations();
    //TODO Add XML comments that are writed over each route and over each property
});
builder.Services.AddDbContext<CoffeeMachineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();