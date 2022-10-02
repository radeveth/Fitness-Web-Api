namespace FitnessApp.Web.Controllers.ApiControllers
{
    using FitnessWebApi.InputModels.Api;
    using FitnessWebApi.Services.Data.ExercisesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public IEnumerable<ExerciseViewModel> All()
        {
            return this.exerciseService.GetAllExercises();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(ExerciseInputModel exerciseInputModel)
        {
            await this.exerciseService.CreateAsync(exerciseInputModel);

            return this.Ok();
        }

        [HttpDelete]
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
