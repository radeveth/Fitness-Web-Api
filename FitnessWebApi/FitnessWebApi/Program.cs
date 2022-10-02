using FitnessWebApi.Services.Mappings;

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

// builder.Services.AddTransient<IExerciseService, ExerciseService>();
// builder.Services.AddTransient<IBodyPartService, BodyPartService>();
// builder.Services.AddTransient<IEquipmentService, EquipmentService>();
// builder.Services.AddTransient<ITargetMuscleService, TargetMuscleService>();

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
