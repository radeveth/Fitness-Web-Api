namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.Services.Data.BodyPartsServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class BodyPartsController : ControllerBase
    {
        private readonly IBodyPartService bodyPartService;

        public BodyPartsController(IBodyPartService bodyPartService)
        {
            this.bodyPartService = bodyPartService;
        }

        [HttpGet]
        [ActionName("All")]
        public IEnumerable<BodyPartViewModel> All()
        {
            return this.bodyPartService.GetAllBodyParts();
        }

        [HttpGet]
        [ActionName("getBodyPart")]
        public async Task<BodyPartViewModel> GetBodyPart([FromQuery] int id)
        {
            return await this.bodyPartService.GetViewModelByIdAsync(id);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create([FromBody] BodyPartInputModel bodyPartInputModel)
        {
            await this.bodyPartService.CreateAsync(bodyPartInputModel);

            return this.Ok();
        }

        [HttpDelete]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await this.bodyPartService.DeleteAsync(id);

                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
