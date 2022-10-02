namespace FitnessWebApi.Data.Models
{
    using FitnessWebApi.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    using static FitnessWebApi.Data.Common.DataValidation.TargetMuscleValidation;

    public class TargetMuscle : BaseDeletableModel<int>
    {
        public TargetMuscle()
        {
            this.Exercises = new HashSet<Exercise>();
        }


        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
