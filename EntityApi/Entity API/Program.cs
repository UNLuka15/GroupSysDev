using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Still need to add the following models:
// - Account
// - Reports
// - Logins
// - Review Table
// - Email Reports

// Could try and make a more standard repository. Could it accept a DbSet<T> instead of calling properties directly?
// Need to add more interfaces in case we were to switch to another database integration at some point in the future.
// Get Enums to show as their values instead of indices

var builder = WebApplication.CreateBuilder(args);
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