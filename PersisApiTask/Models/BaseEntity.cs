using System.ComponentModel.DataAnnotations;

namespace PersisApiTask.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsActivated { get; set; }
        [Required]
        public DateTime InsertDateTime { get; set; }
    }
}
