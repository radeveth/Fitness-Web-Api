using FitnessWebApi.Services.Data.BodyPartsServices;
using FitnessWebApi.Services.Data.EquipmentsServices;
using FitnessWebApi.Services.Data.ExercisesServices;
using FitnessWebApi.Services.Data.TargetMusclesServices;
using FitnessWebApi.Services.Mappings;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => 
{
    config.AddProfile<ExercisesProfile>();
    config.AddProfile<BodyPartsProfile>();
});

builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<IBodyPartService, BodyPartService>();
builder.Services.AddTransient<IEquipmentService, EquipmentService>();
builder.Services.AddTransient<ITargetMuscleService, TargetMuscleService>();

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
