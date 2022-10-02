namespace FitnessApp.Web.Controllers
{
    using System.Diagnostics;
    using FitnessApp.Web.Models;
    using FitnessWebApi.Services.Data.ExercisesServices;
    using FitnessWebApi.ViewModels.Api;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IExerciseService exerciseService;

        public HomeController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        public IEnumerable<ExerciseViewModel> Index()
        {
            return this.exerciseService.GetAllExercises();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}