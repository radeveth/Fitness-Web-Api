namespace FitnessWebApi.Services.Data.TargetMusclesServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface ITargetMuscleService
    {
        Task CreateAsync(TargetMuscleInputModel targetMuscleInputModel);

        Task<TargetMuscleViewModel> GetViewModelByIdAsync(int id);

        IEnumerable<TargetMuscleViewModel> GetAllTargetMuscles();

        Task DeleteAsync(int id);

        Task<TargetMuscleViewModel> GetTargetMuscleByGivenNameAsync(string name);
    }
}
