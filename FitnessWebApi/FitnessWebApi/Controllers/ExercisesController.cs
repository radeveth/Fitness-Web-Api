namespace FitnessWebApi.Controllers
{
    using FitnessWebApi.Services.Data.ExercisesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {

        [HttpGet]
        public ActionResult All()
        {
            return Ok("rado");
        }
    }
}
