namespace FitnessWebApi.Services.Data.EquipmentsServices
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

    public class EquipmentService : IEquipmentService
    {
        private readonly FitnessWebApiDbContext dbContext;
        private readonly IMapper mapper;

        public EquipmentService(FitnessWebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(EquipmentInputModel equipmentInputModel)
        {
            Equipment equipment = new Equipment()
            {
                Type = equipmentInputModel.Type,
                CreatedOn = DateTime.UtcNow,
            };

            await this.dbContext.AddRangeAsync(equipment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Equipment equipment = await this.dbContext.Equipments.FirstOrDefaultAsync(e => e.Id == id);

            if (equipment == null)
            {
                throw new ArgumentNullException();
            }

            equipment.IsDeleted = true;
            equipment.DeletedOn = DateTime.UtcNow;

            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<EquipmentViewModel> GetAllEqiupments()
            => this.dbContext
                .Equipments
                .ProjectTo<EquipmentViewModel>(this.mapper.ConfigurationProvider);

        public async Task<EquipmentViewModel> GetEquipmentByGivenTypeAsync(string type)
            => await this.dbContext
                .Equipments
                .ProjectTo<EquipmentViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Type.ToLower() == type.ToLower());

        public async Task<EquipmentViewModel> GetViewModelByIdAsync(int id)
            => await this.dbContext
                .Equipments
                .ProjectTo<EquipmentViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == id);
    }
}
