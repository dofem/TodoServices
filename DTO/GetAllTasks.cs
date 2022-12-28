using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoServices.DTO
{
    public class GetAllTasks
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
       
       
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
