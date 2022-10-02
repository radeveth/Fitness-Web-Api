namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.Services.Data.BodyPartsServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BodyPartsController : ControllerBase
    {
        private readonly IBodyPartService bodyPartService;

        public BodyPartsController(IBodyPartService bodyPartService)
        {
            this.bodyPartService = bodyPartService;
        }

        [HttpGet]
        public IEnumerable<BodyPartViewModel> All()
        {
            return this.bodyPartService.GetAllBodyParts();
        }
    }
}
