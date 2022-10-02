namespace FitnessWebApi.Services.Data.EquipmentsServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface IEquipmentService
    {
        Task CreateAsync(EquipmentInputModel equipmentInputModel);

        Task<EquipmentViewModel> GetViewModelByIdAsync(int id);

        IEnumerable<EquipmentViewModel> GetAllEqiupments();

        Task DeleteAsync(int id);

        Task<EquipmentViewModel> GetEquipmentByGivenTypeAsync(string type);
    }
}
