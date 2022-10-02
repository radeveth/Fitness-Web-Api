namespace FitnessWebApi.Services.Data.TargetMusclesServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FitnessWebApi.Data;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.EntityFrameworkCore;

    public class TargetMuscleService : ITargetMuscleService
    {
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IMapper mapper;

        public TargetMuscleService(FitnessWebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(TargetMuscleInputModel targetMuscleInputModel)
        {
            TargetMuscle targetMuscle = new TargetMuscle()
            {
                Name = targetMuscleInputModel.Name,
                CreatedOn = DateTime.UtcNow,
            };

            await this.dbContext.AddAsync(targetMuscle);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TargetMuscle targetMuscle = await this.dbContext.TargetMuscles.FirstOrDefaultAsync(t => t.Id == id);

            if (targetMuscle == null)
            {
                throw new ArgumentNullException();
            }

            targetMuscle.IsDeleted = true;
            targetMuscle.DeletedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<TargetMuscleViewModel> GetAllTargetMuscles()
            => this.dbContext
                .TargetMuscles
                .ProjectTo<TargetMuscleViewModel>(this.mapper.ConfigurationProvider);

        public async Task<TargetMuscleViewModel> GetTargetMuscleByGivenNameAsync(string name)
            => await this.dbContext
                .TargetMuscles
                .ProjectTo<TargetMuscleViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());

        public async Task<TargetMuscleViewModel> GetViewModelByIdAsync(int id)
            => await this.dbContext
                .TargetMuscles
                .ProjectTo<TargetMuscleViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(t => t.Id == id);
    }
}
