using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoServices.Data;
using TodoServices.DTO;
using TodoServices.Model;

namespace TodoServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TasksController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Add-a-new-TASK")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTasks tasks)
        {
            try
            {
                if (tasks == null)
                {
                    return BadRequest("you cannot create an Invalid Task");
                }
                var task = _mapper.Map<Tasks>(tasks);
                


                _context.Taskss.Add(task);
                await _context.SaveChangesAsync();

                return Ok("Task Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("Update-Task")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTask tasks)
        {
            try
            {
                var task = _context.Taskss.Where(t => t.Title == tasks.Title && t.UserId == tasks.UserId).FirstOrDefault();
                if (task == null)
                {
                    return BadRequest("Task does not exist");
                }

                _context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Task Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-All-tasks")]
        public async Task<IActionResult> GetAllUserTasks(int UserId)
        {
            try
            {
                var tasks = _context.Taskss.Where(u => u.UserId == UserId).ToList();
                if (tasks.Count == 0)
                    return NotFound("User has no assigned task");
                return Ok(tasks);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
