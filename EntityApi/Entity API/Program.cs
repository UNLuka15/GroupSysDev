using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Still need to add the following models:
// - Account
// - Reports
// - Logins
// - Possibly Review and Rating tables? (May not need to due to the flexible feedback table.)

// Could try and make a more standard repository. Could it accept a DbSet<T> instead of calling properties directly?
// Need to add more interfaces in case we were to switch to another database integration at some point in the future.
// Need to look into the [Key] attribute and .Include method for entity framework. This may help solve the null objects on returned experiences issue.

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