namespace FitnessWebApi.Services.Mappings
{
    using AutoMapper;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.ViewModels.Api;

    public class EquipmentsProfile : Profile
    {
        public EquipmentsProfile()
        {
            this.CreateMap<Equipment, EquipmentViewModel>();
        }
    }
}
