using JwtExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly TaskListContext taskListContext;

        public TaskListController(TaskListContext taskListContext)
        {
            this.taskListContext = taskListContext;
        }

        [HttpGet]
        [Route("GetAllTasks")]
        public List<TaskLists> GetAllTasks() // tum tasklari listeler
        {
            return taskListContext.TaskLists.ToList(); 
        }

        [HttpGet]
        [Route("GetTaskById")]
        public TaskLists GetTaskById(int id)  // id ye gore 1 tane task dondurur
        {
            return taskListContext.TaskLists.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("AddTask")]
        public string AddTask([FromBody] TaskLists tasklist) // Yeni task olusturur
        {
            string response = string.Empty;
            taskListContext.TaskLists.Add(tasklist);
            taskListContext.SaveChanges(); 
            return "New task added";
        }

        [HttpPut]
        [Route("UpdateOneTask")]
        public IActionResult UpdateOneTask(TaskLists tasklist) // 1 tane taski gunceller
        {
            taskListContext.Entry(tasklist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            taskListContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteTaskById")]
        public IActionResult DeleteTaskById(int id) // id ye gore siler, eger o id ye ait obje bulamazsa notFount dondurur.
        {
            TaskLists tasklist = taskListContext.TaskLists.Where(x => x.Id == id).FirstOrDefault();
            if (tasklist != null)
            {
                taskListContext.TaskLists.Remove(tasklist);
                taskListContext.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
