namespace FitnessWebApi.Services.Data.EquipmentsServices
{
    using AutoMapper;
    using FitnessWebApi.Data;
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EquipmentService : IEquipmentService
    {
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IMapper mapper;

        public EquipmentService(FitnessWebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        public async Task CreateAsync(EquipmentInputModel exerciseInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public EquipmentViewModel GetViewModelById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipmentViewModel> GetAllExercises()
        {
            throw new NotImplementedException();
        }
    }
}
