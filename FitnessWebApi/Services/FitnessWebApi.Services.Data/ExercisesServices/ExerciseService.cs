namespace FitnessWebApi.Services.Data.ExercisesServices
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FitnessWebApi.Data;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExerciseService : IExerciseService
    {
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IMapper mapper;

        public ExerciseService(FitnessWebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(ExerciseInputModel exerciseInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ExerciseViewModel GetViewModelById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseViewModel> GetAllExercises()
        {
            var a = this.dbContext.Exercises;

            var c = a.Select(a => a.Name);

            return this.dbContext
                .Exercises
                .ProjectTo<ExerciseViewModel>(this.mapper.ConfigurationProvider);
        }
    }
}
