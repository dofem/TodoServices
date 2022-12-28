using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoServices.DTO
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateTask : ControllerBase
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
