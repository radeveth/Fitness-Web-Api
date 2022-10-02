namespace FitnessWebApi.Data.Common.Models
{
    public class BaseDeletableModel<T> : BaseModel<T>
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
