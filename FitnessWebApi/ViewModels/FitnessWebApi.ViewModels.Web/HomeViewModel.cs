namespace FitnessWebApi.ViewModels.Web
{
    public class HomeViewModel
    {
        public IEnumerable<HttpMethod> ExercisesMethods { get; set; }

        public IEnumerable<HttpMethod> BodyPartsMethods { get; set; }

        public IEnumerable<HttpMethod> EquipmentsMethods { get; set; }

        public IEnumerable<HttpMethod> TargetMusclesMethods { get; set; }
    }
}
