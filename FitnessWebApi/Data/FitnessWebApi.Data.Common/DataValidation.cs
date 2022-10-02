namespace FitnessWebApi.Data.Common
{
    public class DataValidation
    {
        public class ExerciseValidation
        {
            public const int NameMaxLength = 500;
            public const int GifUrlMaxLength = 2048;
        }

        public class BodyPartValidation
        {
            public const int NameMaxLength = 500;
        }

        public class TargetMuscleValidation
        {
            public const int NameMaxLength = 500;
        }

        public class EquipmentValidation
        {
            public const int TypeMaxLength = 500;
        }
    }
}
