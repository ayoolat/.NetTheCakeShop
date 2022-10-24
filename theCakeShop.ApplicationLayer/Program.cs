using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using theCakeShop.ApplicationLayer.Middlewares;
using theCakeShop.DataLayer.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Get connection string
var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
if (connectionString != null)
    throw new Exception("Connection string not set");

builder.Services.AddDbContext<CakeShopDatabaseContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

//Get logger
var logger = builder.Logging.Services.BuildServiceProvider().GetRequiredService<ILogger<ErrorHandlerMiddleware>>();

ApplyMigrations(app, logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ApplyMigrations(WebApplication app, ILogger<ErrorHandlerMiddleware> logger)
{
    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CakeShopDatabaseContext>();
        db.Database.Migrate();
        logger.LogInformation("Migration complete!");
    }
    catch (Exception ex)
    {
        logger.LogTrace(ex.Message);
        logger.LogTrace(ex, ex.Message);
    }
}
