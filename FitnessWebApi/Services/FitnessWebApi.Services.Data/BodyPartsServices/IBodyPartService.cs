namespace FitnessWebApi.Services.Data.BodyPartsServices
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.ViewModels.Api;

    public interface IBodyPartService
    {
        Task CreateAsync(BodyPartInputModel bodyPartInputModel);

        Task<BodyPartViewModel> GetViewModelByIdAsync(int id);

        IEnumerable<BodyPartViewModel> GetAllBodyParts();

        Task DeleteAsync(int id);

        Task<BodyPartViewModel> GetBodyPartByGivenNameAsync(string name);
    }
}
