using Newtonsoft.Json;
using EntityAPI;
using EntityAPI.Repositories;
using EntityAPI.Factories;
using EntityAPI.Models;

// Need to add update endpoints.
// Need to add unit tests.

// Need to fix exhibit deletion conflict on experience when deleting a museum.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IModelFactory<Account, AccountRequestModel>, AccountFactory>();
builder.Services.AddScoped<IRepository<Account>, AccountRepository>();

builder.Services.AddScoped<IModelFactory<AccountRequest, AccountRequestRequestModel>, AccountRequestFactory>();
builder.Services.AddScoped<IRepository<AccountRequest>, AccountRequestRepository>();

builder.Services.AddScoped<IModelFactory<EmailReport, EmailReportRequestModel>, EmailReportFactory>();
builder.Services.AddScoped<IRepository<EmailReport>, EmailReportRepository>();

builder.Services.AddScoped<IModelFactory<Exhibit, ExhibitRequestModel>, ExhibitFactory>();
builder.Services.AddScoped<IRepository<Exhibit>, ExhibitRepository>();

builder.Services.AddScoped<IModelFactory<Experience, ExperienceRequestModel>, ExperienceFactory>();
builder.Services.AddScoped<IRepository<Experience>, ExperienceRepository>();

builder.Services.AddScoped<IReadRepository<Feedback>, FeedbackRepository>();

builder.Services.AddScoped<IModelFactory<Museum, MuseumRequestModel>, MuseumFactory>();
builder.Services.AddScoped<IRepository<Museum>, MuseumRepository>();

builder.Services.AddScoped<IModelFactory<Report, ReportRequestModel>, ReportFactory>();
builder.Services.AddScoped<IRepository<Report>, ReportRepository>();

builder.Services.AddScoped<IModelFactory<Review, ReviewRequestModel>, ReviewFactory>();
builder.Services.AddScoped<IRepository<Review>, ReviewRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseBasicAuthMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();