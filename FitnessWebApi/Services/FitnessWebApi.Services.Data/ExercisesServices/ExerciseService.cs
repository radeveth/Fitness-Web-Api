namespace FitnessWebApi.Services.Data.ExercisesServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FitnessWebApi.Data;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.Services.Data.BodyPartsServices;
    using FitnessWebApi.Services.Data.EquipmentsServices;
    using FitnessWebApi.Services.Data.TargetMusclesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.EntityFrameworkCore;

    public class ExerciseService : IExerciseService
    {
        private readonly IMapper mapper;
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IBodyPartService bodyPartService;
        private readonly IEquipmentService equipmentService;
        private readonly ITargetMuscleService targetMuscleService;

        public ExerciseService(FitnessWebApiDbContext dbContext,
            IMapper mapper,
            IBodyPartService bodyPartService,
            IEquipmentService equipmentService,
            ITargetMuscleService targetMuscleService)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.bodyPartService = bodyPartService;
            this.equipmentService = equipmentService;
            this.targetMuscleService = targetMuscleService;
        }

        public async Task CreateAsync(ExerciseInputModel exerciseInputModel)
        {
            BodyPartViewModel bodyPart = await this.bodyPartService.GetBodyPartByGivenNameAsync(exerciseInputModel.BodyPartName);
            EquipmentViewModel equipment = await this.equipmentService.GetEquipmentByGivenTypeAsync(exerciseInputModel.EquipmentType);
            TargetMuscleViewModel targetMuscle = await this.targetMuscleService.GetTargetMuscleByGivenNameAsync(exerciseInputModel.TargetNuscleName);

            if (bodyPart == null)
            {
                await this.bodyPartService.CreateAsync(new BodyPartInputModel() { Name = exerciseInputModel.BodyPartName });
                bodyPart = await this.bodyPartService.GetBodyPartByGivenNameAsync(exerciseInputModel.BodyPartName);
            }

            if (equipment == null)
            {
                await this.equipmentService.CreateAsync(new EquipmentInputModel() { Type = exerciseInputModel.EquipmentType });
                equipment = await this.equipmentService.GetEquipmentByGivenTypeAsync(exerciseInputModel.EquipmentType);
            }

            if (targetMuscle == null)
            {
                await this.targetMuscleService.CreateAsync(new TargetMuscleInputModel() { Name = exerciseInputModel.TargetNuscleName });
                targetMuscle = await this.targetMuscleService.GetTargetMuscleByGivenNameAsync(exerciseInputModel.TargetNuscleName);
            }

            Exercise exercise = new Exercise()
            {
                Name = exerciseInputModel.Name,
                GifUrl = exerciseInputModel.GifUrl,
                BodyPartId = bodyPart.Id,
                EquipmentId = equipment.Id,
                TargetMuscleId = targetMuscle.Id,
                CreatedOn = DateTime.UtcNow,
            };

            await this.dbContext.Exercises.AddAsync(exercise);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Exercise exercise = await this.dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
            {
                throw new ArgumentNullException("Invalid parameter/s are given!!!");
            }

            exercise.IsDeleted = true;
            exercise.DeletedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ExerciseViewModel> GetViewModelByIdAsync(int id)
            => await this.dbContext
                .Exercises
                .ProjectTo<ExerciseViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<ExerciseViewModel>> GetAllExercisesAsync(string? targetMuscle = null, string? equipment = null)
        {
            List<ExerciseViewModel> exercises = await this.dbContext
                .Exercises
                .ProjectTo<ExerciseViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            if (targetMuscle != null)
            {
                exercises = exercises
                    .Where(e => e.TargetMuscleName.ToLower() == targetMuscle.ToLower())
                    .ToList();
            }

            if (equipment != null)
            {
                exercises = exercises
                    .Where(e => e.EquipmentType.ToLower() == equipment.ToLower())
                    .ToList();
            }

            return exercises;
        }
    }
}
