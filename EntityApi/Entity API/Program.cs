using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// TODO: Insert Data  DONE
//       Read Data    DONE
//       Delete Data  DONE
//       Create API
//       Tests

//Console.WriteLine("Loading Context...");
//var exhibitRepository = new ExhibitRepository();


//// Adding 
//var newExhibit = new Exhibit()
//{
//    Id = 1,
//    Name = "Healthcare",
//    Description = "An exhibit showing our recent medical advances.",
//    Museum = new Museum(),
//    OpeningTime = DateTime.Now,
//    ClosingTime = DateTime.Now,
//};

//exhibitRepository.AddNew(newExhibit);
//// 

//// Removing
//var idToRemove = 1;
//exhibitRepository.RemoveById(idToRemove);
//// 

// Reading
//var exhibits = exhibitRepository.GetAll();

//foreach (var exhibit in exhibits)
//    exhibit.LogProperties();
// 
//Console.WriteLine("Program complete.");


//// API Configuration
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