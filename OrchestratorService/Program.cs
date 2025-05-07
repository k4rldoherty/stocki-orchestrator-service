using OrchestratorService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddConsole();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<StockDataService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(
        "OpenPolicy",
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin(); // Change this when other services created. .WithOrigins("x", "y")
        }
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseCors("OpenPolicy");

// app.UseAuthorization();

app.MapControllers();

app.Run();
