namespace FitnessApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using FitnessApp.Web.Models;
    using FitnessWebApi.ViewModels.Web;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<HttpMethod> exerciseMethods = new List<HttpMethod>()
            {
                new HttpMethod("GET", "/api/exercises/all"),
                new HttpMethod("GET", "/api/exercises/getExercise?id=?"),
                new HttpMethod("POST", "/api/exercises/create"),
                new HttpMethod("DELETE", "/api/exercises/delete?id=?"),
            };

            List<HttpMethod> bodtPartsMethods = new List<HttpMethod>()
            {
                new HttpMethod("GET", "/api/bodyParts/all"),
                new HttpMethod("GET", "/api/bodyParts/getBodyPart?id=?"),
                new HttpMethod("POST", "/api/bodyParts/create"),
                new HttpMethod("DELETE", "/api/bodyParts/delete?id=?"),
            };

            List<HttpMethod> equipmentsMethods = new List<HttpMethod>()
            {
                new HttpMethod("GET", "/api/equipment/all"),
                new HttpMethod("GET", "/api/equipment/getEquipment?id=?"),
                new HttpMethod("POST", "/api/equipment/create"),
                new HttpMethod("DELETE", "/api/equipment/delete?id=?"),
            };

            List<HttpMethod> targetMusclesMethods = new List<HttpMethod>()
            {
                new HttpMethod("GET", "/api/targetMuscles/all"),
                new HttpMethod("GET", "/api/targetMuscles/getTargetMuscle?id=?"),
                new HttpMethod("POST", "/api/targetMuscles/create"),
                new HttpMethod("DELETE", "/api/targetMuscles/delete?id=?"),
            };

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                ExercisesMethods = exerciseMethods,
                BodyPartsMethods = bodtPartsMethods,
                EquipmentsMethods = equipmentsMethods,
                TargetMusclesMethods = targetMusclesMethods,
            };

            return this.View(homeViewModel);
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