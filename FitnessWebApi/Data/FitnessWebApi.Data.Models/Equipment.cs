namespace FitnessWebApi.Data.Models
{
    using FitnessWebApi.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    using static FitnessWebApi.Data.Common.DataValidation.EquipmentValidation;

    public class Equipment : BaseDeletableModel<int>
    {
        public Equipment()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        [MaxLength(TypeMaxLength)]
        public string Type { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
