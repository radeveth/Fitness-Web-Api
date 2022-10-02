namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.Services.Data.EquipmentsServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentsController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet]
        public IEnumerable<EquipmentViewModel> All()
        {
            return this.equipmentService.GetAllEqiupments();
        }
    }
}
