namespace FitnessWebApi.Services.Mappings
{
    using AutoMapper;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.ViewModels.Api;

    public class BodyPartsProfile : Profile
    {
        public BodyPartsProfile()
        {
            this.CreateMap<BodyPart, BodyPartViewModel>();
        }
    }
}
