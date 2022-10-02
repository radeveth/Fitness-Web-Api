namespace FitnessWebApi.Services.Mappings
{
    using AutoMapper;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.ViewModels.Api;

    public class TargetMusclesProfile : Profile
    {
        public TargetMusclesProfile()
        {
            this.CreateMap<TargetMuscle, TargetMuscleViewModel>();
        }
    }
}
