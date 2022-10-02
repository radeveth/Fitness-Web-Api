namespace FitnessWebApi.Services.Data.TargetMusclesServices
{
    using AutoMapper;
    using FitnessWebApi.Data;
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TargetMuscleService : ITargetMuscleService
    {
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IMapper mapper;

        public TargetMuscleService(FitnessWebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(TargetMuscleInputModel exerciseInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public TargetMuscleViewModel GetViewModelById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TargetMuscleViewModel> GetAllExercises()
        {
            throw new NotImplementedException();
        }
    }
}
