namespace FitnessWebApi.Services.Mappings
{
    using AutoMapper;
    using FitnessWebApi.Data.Models;
    using FitnessWebApi.ViewModels.Api;

    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            this.CreateMap<Exercise, ExerciseViewModel>();
        }
    }
}
