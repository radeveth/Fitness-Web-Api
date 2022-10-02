namespace FitnessWebApi.Data.Seeder
{
    using FitnessWebApi.Data.Models;

    public class Service
    {
        public static int GetBodyPartId(FitnessWebApiDbContext dbContext, string name)
        {
            BodyPart bodyPart = dbContext.BodyParts.FirstOrDefault(b => b.Name.ToLower() == name.ToLower());

            return bodyPart.Id;
        }
        public static int GetMuscleGroupId(FitnessWebApiDbContext dbContext, string name)
        {
            TargetMuscle muscle = dbContext.TargetMuscles.FirstOrDefault(b => b.Name.ToLower() == name.ToLower());

            return muscle.Id;
        }
        public static int GetEquipmentId(FitnessWebApiDbContext dbContext, string name)
        {
            Equipment equipment = dbContext.Equipments.FirstOrDefault(b => b.Type.ToLower() == name.ToLower());

            return equipment.Id;
        }
    }
}
