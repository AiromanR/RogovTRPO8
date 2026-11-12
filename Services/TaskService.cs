using RogovTRPO8.Models;
using static RogovTRPO8.Models.DTOs;

namespace RogovTRPO8.Services
{
    static public class TaskService
    {
        static private RogovDbContext _db = DBService.Instance.Context;

        static public List<Models.Task> GetTasks ()
        {
            return _db.Tasks.ToList( );
        }
        static public List<Models.Task> GetTasks (string? userName)
        {
            return _db.Tasks.Where(t => t.OwnerLogin == userName).ToList( );
        }

        static public Models.Task? GetTasks (int id)
        {
            return _db.Tasks.FirstOrDefault(item => item.Id == id);
        }
        static public Models.Task? CreateTask (TaskDTO taskDTO, string userName)
        {
            Models.Task task = new Models.Task( );
            task.Title = taskDTO.title;
            task.Description = taskDTO.description;
            task.OwnerLogin = userName;
            task.IsCompleted = false;
            _db.Tasks.Add(task);
            _db.SaveChanges( );
            return task;
        }
        static public Models.Task? EditTask (TaskDTOIsCompleted taskDTO, Models.Task task)
        {
            task.Title = taskDTO.title;
            task.Description = taskDTO.description;
            task.IsCompleted = taskDTO.isCompleted;
            _db.SaveChanges( );
            return task;
        }
        static public bool DeleteTask (Models.Task task)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges( );
            return true;
        }
    }
}
