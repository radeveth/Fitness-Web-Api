namespace FitnessWebApi.Services.Data.BodyPartsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FitnessWebApi.Data;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.EntityFrameworkCore;

    public class BodyPartService : IBodyPartService
    {
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IMapper mapper;

        public BodyPartService(FitnessWebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(BodyPartInputModel bodyPartInputModel)
        {
            BodyPart bodyPart = new BodyPart()
            {
                Name = bodyPartInputModel.Name,
                CreatedOn = DateTime.UtcNow,
            };

            await this.dbContext.BodyParts.AddAsync(bodyPart);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            BodyPart bodyPart = await this.dbContext.BodyParts.FirstOrDefaultAsync(b => b.Id == id);

            if (bodyPart == null)
            {
                throw new ArgumentNullException();
            }

            bodyPart.IsDeleted = true;
            bodyPart.DeletedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<BodyPartViewModel> GetViewModelByIdAsync(int id)
            => await this.dbContext
                .BodyParts
                .ProjectTo<BodyPartViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(b => b.Id == id);

        public IEnumerable<BodyPartViewModel> GetAllBodyParts()
            => this.dbContext
                .BodyParts
                .ProjectTo<BodyPartViewModel>(this.mapper.ConfigurationProvider);

        public async Task<BodyPartViewModel> GetBodyPartByGivenNameAsync(string name)
            => await this.dbContext
                .BodyParts
                .ProjectTo<BodyPartViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
    }
}
