namespace FitnessWebApi.Data.Models
{
    using FitnessWebApi.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static FitnessWebApi.Data.Common.DataValidation.ExerciseValidation;

    public class Exercise : BaseDeletableModel<int>
    {
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GifUrlMaxLength)]
        public string GifUrl { get; set; }

        [ForeignKey(nameof(BodyPart))]
        public int BodyPartId { get; set; }
        
        public BodyPart BodyPart { get; set; }

        [ForeignKey(nameof(Equipment))]
        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        [ForeignKey(nameof(TargetMuscle))]
        public int TargetMuscleId { get; set; }

        public TargetMuscle TargetMuscle { get; set; }
    }
}
