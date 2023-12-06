using System.ComponentModel.DataAnnotations;

namespace api.Domain.Models
{
    public abstract class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
