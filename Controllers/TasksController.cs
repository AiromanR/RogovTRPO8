using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RogovTRPO8.Models;
using RogovTRPO8.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static RogovTRPO8.Models.DTOs;
//Jwt key = ReplaceThisWithARandomSecretOfAtLeast32BytesRogov
namespace RogovTRPO8.Controllers
{
    [Route("api/v1/tasks")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetTasksAll ()
        {
            return Ok(TaskService.GetTasks( ));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetTasksOwn ()
        {
            string? userName = User.Identity?.Name;

            List<Models.Task> Tasks = TaskService.GetTasks(userName);

            return Ok(Tasks);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetTasksId (int id)
        {
            string? userName = User.Identity?.Name;

            var task = TaskService.GetTasks(id);

            if (task == null) return NotFound( );

            if (User.IsInRole("Admin") || task.OwnerLogin == userName)
            {
                return Ok(task);
            }
            return Forbid( );
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult CreateTask (TaskDTO titleDesc)
        {
            if (titleDesc.title.IsNullOrEmpty( ) || titleDesc.description.IsNullOrEmpty( )) return BadRequest( );

            string? userName = User.Identity?.Name;
            var task = TaskService.CreateTask(titleDesc, userName);
            return Created($"api/v1/tasks/{task.Id}", task);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditTask (int id, TaskDTOIsCompleted titleDescComp)
        {
            string? userName = User.Identity?.Name;

            var task = TaskService.GetTasks(id);

            if (task == null) return NotFound( );

            if (User.IsInRole("Admin") || task.OwnerLogin == userName)
            {
                return Ok(TaskService.EditTask(titleDescComp, task));
            }
            return Forbid( );
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult DeleteTask (int id)
        {
            string? userName = User.Identity?.Name;

            var task = TaskService.GetTasks(id);

            if (task == null) return NotFound( );

            if (User.IsInRole("Admin") || task.OwnerLogin == userName)
            {
                if (TaskService.DeleteTask(task))
                {
                    return NoContent( );
                }
            }
            return Forbid( );
        }
    }
}