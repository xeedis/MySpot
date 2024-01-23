using MySpot.Application;
using MySpot.Application.Services;
using MySpot.Core;
using MySpot.Core.Repositories;
using MySpot.Infrastructure;
using MySpot.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure()
    .AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
