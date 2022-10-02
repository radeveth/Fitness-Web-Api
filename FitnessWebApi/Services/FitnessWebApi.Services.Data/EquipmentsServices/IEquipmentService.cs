namespace FitnessWebApi.Services.Data.EquipmentsServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface IEquipmentService
    {
        Task CreateAsync(EquipmentInputModel exerciseInputModel);

        EquipmentViewModel GetViewModelById(int id);

        IEnumerable<EquipmentViewModel> GetAllExercises();

        Task DeleteAsync(int id);
    }
}
