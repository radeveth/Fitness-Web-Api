namespace FitnessWebApi.Services.Data.TargetMusclesServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface ITargetMuscleService
    {
        Task CreateAsync(TargetMuscleInputModel exerciseInputModel);

        TargetMuscleViewModel GetViewModelById(int id);

        IEnumerable<TargetMuscleViewModel> GetAllExercises();

        Task DeleteAsync(int id);
    }
}
