namespace FitnessWebApi.Services.Data.BodyPartsServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface IBodyPartService
    {
        Task CreateAsync(BodyPartInputModel exerciseInputModel);

        BodyPartViewModel GetViewModelById(int id);

        IEnumerable<BodyPartViewModel> GetAllBodyParts();

        Task DeleteAsync(int id);
    }
}
