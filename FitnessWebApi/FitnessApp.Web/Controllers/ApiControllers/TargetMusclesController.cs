namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.Services.Data.TargetMusclesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
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
    }
}
