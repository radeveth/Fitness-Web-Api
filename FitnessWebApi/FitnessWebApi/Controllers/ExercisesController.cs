namespace FitnessWebApi.Controllers
{
    using FitnessWebApi.Services.Data.ExercisesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private IExerciseService exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public IEnumerable<ExerciseViewModel> GetExercises()
        {
            return this.exerciseService.GetAllExercises();
        }
    }
}
