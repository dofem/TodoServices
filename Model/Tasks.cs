using System.ComponentModel.DataAnnotations.Schema;

namespace TodoServices.Model
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("AssignedToId")]
        public int AssignedToId { get; set; }
       
        public User AssignedTo { get; set; }
        
    }
}
