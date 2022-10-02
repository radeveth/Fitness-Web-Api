namespace FitnessWebApi.Services.Data.BodyPartsServices
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FitnessWebApi.Data;
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BodyPartService : IBodyPartService
    {
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IMapper mapper;

        public BodyPartService(FitnessWebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(BodyPartInputModel exerciseInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public BodyPartViewModel GetViewModelById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BodyPartViewModel> GetAllBodyParts()
        {
            return this.dbContext
                .BodyParts
                .ProjectTo<BodyPartViewModel>(this.mapper.ConfigurationProvider);
        }
    }
}
