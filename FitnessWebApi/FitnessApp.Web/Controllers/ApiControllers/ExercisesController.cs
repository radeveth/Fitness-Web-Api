namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.Services.Data.ExercisesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        [ActionName("All")]
        public async Task<IEnumerable<ExerciseViewModel>> All(string? targetMuscle = null, string? equipment = null)
        {
            return await this.exerciseService.GetAllExercisesAsync(targetMuscle, equipment);
        }

        [HttpGet]
        [ActionName("getExercise")]
        public async Task<ExerciseViewModel> GetExerciseByIdAsync([FromQuery] int id)
        {
            return await this.exerciseService.GetViewModelByIdAsync(id);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync([FromBody] ExerciseInputModel exerciseInputModel)
        {
            await this.exerciseService.CreateAsync(exerciseInputModel);

            return this.Ok();
        }

        [HttpDelete]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await this.exerciseService.DeleteAsync(id);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
