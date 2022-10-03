namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.Services.Data.BodyPartsServices;
    using FitnessWebApi.Services.Data.TargetMusclesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class TargetMusclesController : ControllerBase
    {
        private readonly ITargetMuscleService targetMuscleService;

        public TargetMusclesController(ITargetMuscleService targetMuscleService)
        {
            this.targetMuscleService = targetMuscleService;
        }

        [HttpGet]
        public IEnumerable<TargetMuscleViewModel> All()
        {
            return this.targetMuscleService.GetAllTargetMuscles();
        }

        [HttpGet]
        [ActionName("getTargetMuscle")]
        public async Task<TargetMuscleViewModel> GetEquipment([FromQuery] int id)
        {
            return await this.targetMuscleService.GetViewModelByIdAsync(id);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create([FromBody] TargetMuscleInputModel targetMuscleInputModel)
        {
            await this.targetMuscleService.CreateAsync(targetMuscleInputModel);

            return this.Ok();
        }

        [HttpDelete]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await this.targetMuscleService.DeleteAsync(id);

                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
