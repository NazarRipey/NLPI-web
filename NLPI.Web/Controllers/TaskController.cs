using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLPI.Web.Controllers
{
    [ApiController]
    [Route("api/csstasks")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CSSTaskDTO>>> Get()
        {

            var result = await _taskService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CSSTaskDTO>> getById(int id)
        {
            var result = await _taskService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteAsync(id);
            return NoContent();
        }
    }
}
