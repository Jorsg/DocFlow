using DocFlow.AuthService.Data;
using DocFlow.AuthService.Interfaces;
using DocFlow.AuthService.Repositories;
using DocFlow.AuthService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddTransient<MongoDbContext>();
builder.Services.AddTransient<IAuthServiceRepository, UserRepository>();
builder.Services.AddTransient<IAuthService, AuthService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();

}

app.UseHttpsRedirection();
app.MapControllers();



app.Run();

