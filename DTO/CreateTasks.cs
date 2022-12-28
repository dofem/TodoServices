using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoServices.DTO
{
    public class CreateTasks
    {
        
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }
      
    }
}
