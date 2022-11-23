using MyHolidays.Repositories;
using MyHolidays.UseCases;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHolidaysCollectionsRepository, MemoryRepository>();
builder.Services.AddScoped<ICheckHolidaysUseCase, CheckHolidaysUseCase>();

builder.Services.AddControllers().AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
