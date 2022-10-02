namespace FitnessWebApi.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BaseModel<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
