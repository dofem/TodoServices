using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoServices.Model
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool DateCompleted { get; set; } = false;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public User User { get; set; }
       
      
        
    }
}
