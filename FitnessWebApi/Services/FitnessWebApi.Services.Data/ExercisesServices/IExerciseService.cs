namespace FitnessWebApi.Services.Data.ExercisesServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface IExerciseService
    {
        Task CreateAsync(ExerciseInputModel exerciseInputModel);

        Task<ExerciseViewModel> GetViewModelByIdAsync(int id);

        Task<IEnumerable<ExerciseViewModel>> GetAllExercisesAsync(string? targetMuscle = null, string? equipment = null);

        Task DeleteAsync(int id);
    }
}
