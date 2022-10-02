namespace FitnessWebApi.Data.Models
{
    using FitnessWebApi.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    using static FitnessWebApi.Data.Common.DataValidation.BodyPartValidation;

    public class BodyPart : BaseDeletableModel<int>
    {
        public BodyPart()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
