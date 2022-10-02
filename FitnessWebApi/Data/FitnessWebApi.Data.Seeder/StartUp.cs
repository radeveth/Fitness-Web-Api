using System.Runtime.CompilerServices;
using FitnessWebApi.Data;
using FitnessWebApi.Data.Models;
using FitnessWebApi.Data.Seeder;
using FitnessWebApi.Data.Seeder.BodyPartsDataSeeding;
using FitnessWebApi.Data.Seeder.EquipmentsDataSeeding;
using FitnessWebApi.Data.Seeder.ExercisesDataSeeding;
using FitnessWebApi.Data.Seeder.MuscleGroupsDataSeeding;
using Newtonsoft.Json;

public class StartUp
{
    private static async Task Main(string[] args)
    {
        FitnessWebApiDbContext dbContext = new FitnessWebApiDbContext();

        // Uncomment for seeding data
        // await SeedingBodyParts(dbContext);
        // await SeedingTargetMuscles(dbContext);
        // await SeedingEquipments(dbContext);
        // await SeedingExercises(dbContext);
    }

    private static async Task SeedingBodyParts(FitnessWebApiDbContext dbContext)
    {
        var jsonData = File.ReadAllText(@"BodyParts.json");
        var jsonDataResult = JsonConvert.DeserializeObject<List<BodyPartSeederModel>>(jsonData);

        List<BodyPart> bodyParts = new List<BodyPart>();

        Console.WriteLine("Start...");
        foreach (var bodyPart in jsonDataResult)
        {
            BodyPart part = new BodyPart()
            {
                Name = bodyPart.Name,
            };

            bodyParts.Add(part);

            Console.WriteLine("Processing...");
        }
        ;
        await dbContext.BodyParts.AddRangeAsync(bodyParts);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("Done");
    }

    private static async Task SeedingTargetMuscles(FitnessWebApiDbContext dbContext)
    {
        var jsonData = File.ReadAllText(@"MuscleGroups.json");
        var jsonDataResult = JsonConvert.DeserializeObject<List<MuscleGroupSeederModel>>(jsonData);

        List<TargetMuscle> targetMuscles = new List<TargetMuscle>();

        Console.WriteLine("Start...");
        foreach (var muscle in jsonDataResult)
        {
            TargetMuscle part = new TargetMuscle()
            {
                Name = muscle.Name,
            };

            targetMuscles.Add(part);

            Console.WriteLine("Processing...");
        }

        await dbContext.TargetMuscles.AddRangeAsync(targetMuscles);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("Done");
    }

    private static async Task SeedingEquipments(FitnessWebApiDbContext dbContext)
    {
        var jsonData = File.ReadAllText(@"Equipments.json");
        var jsonDataResult = JsonConvert.DeserializeObject<List<EquipmentSeederModel>>(jsonData);

        List<Equipment> equipments = new List<Equipment>();

        Console.WriteLine("Start...");
        foreach (var equipmentData in jsonDataResult)
        {
            Equipment equipment = new Equipment()
            {
                Type = equipmentData.Type,
            };

            equipments.Add(equipment);

            Console.WriteLine("Processing...");
        }

        await dbContext.Equipments.AddRangeAsync(equipments);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("Done");
    }

    private static async Task SeedingExercises(FitnessWebApiDbContext dbContext)
    {
        var jsonData = File.ReadAllText(@"Exercises.json");
        var jsonDataResult = JsonConvert.DeserializeObject<List<ExerciseSeederModel>>(jsonData);

        List<Exercise> exercises = new List<Exercise>();

        Console.WriteLine("Start...");

        foreach (var property in jsonDataResult)
        {
            Exercise exercise = new Exercise()
            {
                Name = property.Name,
                GifUrl = property.GifUrl,
                BodyPartId = Service.GetBodyPartId(dbContext, property.BodyPart),
                TargetMuscleId = Service.GetMuscleGroupId(dbContext, property.Target),
                EquipmentId = Service.GetEquipmentId(dbContext, property.Equipment),
            };

            exercises.Add(exercise);

            Console.WriteLine("Pricessing...");
        }

        await dbContext.Exercises.AddRangeAsync(exercises);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("Done");
    }
}