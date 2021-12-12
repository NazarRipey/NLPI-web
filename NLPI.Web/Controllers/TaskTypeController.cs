using Microsoft.AspNetCore.Mvc;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.Web.Controllers
{
    [ApiController]
    [Route("api/tasktypes")]
    public class TaskTypeController : ControllerBase
    {
        private ITaskTypeService _taskTaskService;
        private ITaskService _taskService;

        public TaskTypeController(ITaskTypeService taskTypeService, ITaskService taskService)
        {
            _taskTaskService = taskTypeService;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskType>>> Get()
        {

            var result = await _taskTaskService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskType>> getById(int id)
        {
            var result = await _taskTaskService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}/tasks")]
        public async Task<ActionResult<List<TestTask>>> getTasksById(int id)
        {
            var result = await _taskService.GetTaskByTypeId(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskTaskService.DeleteAsync(id);
            return NoContent();
        }

    }
}
