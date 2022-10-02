using FitnessWebApi.Data;
using FitnessWebApi.Data.Models;
using FitnessWebApi.Data.Seeder;
using Newtonsoft.Json;

public class StartUp
{
    private static async Task Main(string[] args)
    {
        var jsonData = File.ReadAllText(@"Exercises.json");
        var jsonDataResult = JsonConvert.DeserializeObject<List<ExerciseSeederModel>>(jsonData);

        FitnessWebApiDbContext dbContext = new FitnessWebApiDbContext();

        Console.WriteLine("Start...");

        foreach (var property in jsonDataResult)
        {
            Exercise exercise = new Exercise()
            {
                Name = property.Name,
                GifUrl = property.GifUrl,
                BodyPartId = Service.GetBodyPartId(dbContext, property.BodyPart),
                TargetMuscleId = Service.GetMuscleGroupId(dbContext, property.Target),
                EquipmentId = Service.GetEquipmentId(dbContext, property.Equipment)
            };
            await dbContext.Exercises.AddAsync(exercise);
            await dbContext.SaveChangesAsync();

            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine("Done");
    }
}