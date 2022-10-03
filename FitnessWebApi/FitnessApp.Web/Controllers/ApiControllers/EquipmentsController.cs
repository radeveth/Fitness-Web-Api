namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.Services.Data.BodyPartsServices;
    using FitnessWebApi.Services.Data.EquipmentsServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentsController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet]
        [ActionName("All")]
        public IEnumerable<EquipmentViewModel> All()
        {
            return this.equipmentService.GetAllEqiupments();
        }

        [HttpGet]
        [ActionName("getEquipment")]
        public async Task<EquipmentViewModel> GetEquipment([FromQuery] int id)
        {
            return await this.equipmentService.GetViewModelByIdAsync(id);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create([FromBody] EquipmentInputModel equipmentInputModel)
        {
            await this.equipmentService.CreateAsync(equipmentInputModel);

            return this.Ok();
        }

        [HttpDelete]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await this.equipmentService.DeleteAsync(id);

                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
