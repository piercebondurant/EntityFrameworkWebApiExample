using EntityFrameworkWebApiExample.Repositories.Context;
using EntityFrameworkWebApiExample.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ExampleRepository>();

builder.Services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("LocalConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
