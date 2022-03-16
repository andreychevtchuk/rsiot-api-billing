using BugTrackerApiBilling.Services;
using BugTrackerApiBilling.Services.Interfaces;
using BugTrackerApiBilling.Settings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();

builder.Services.Configure<GCloudIntegrationSettings>(configuration.GetSection(nameof(GCloudIntegrationSettings)));

builder.Services.AddSingleton<IBillingService, BillingService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
