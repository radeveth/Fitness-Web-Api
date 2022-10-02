namespace FitnessWebApi.Services.Data.ExercisesServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface IExerciseService
    {
        Task CreateAsync(ExerciseInputModel exerciseInputModel);

        ExerciseViewModel GetViewModelById(int id);

        IEnumerable<ExerciseViewModel> GetAllExercises();

        Task DeleteAsync(int id);
    }
}
