using Microsoft.AspNetCore.Mvc;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.DTO.MainDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.Web.Controllers
{
    [ApiController]
    [Route("api/taskresults")]
    public class TaskResultController : ControllerBase
    {
        private IUserTaskResultService _userTaskResultService;

        public TaskResultController(IUserTaskResultService taskResultService)
        {
            _userTaskResultService = taskResultService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskResultDTO>>> Get()
        {

            var result = await _userTaskResultService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResultDTO>> getById(int id)
        {
            var result = await _userTaskResultService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TaskScoreDTO>> PassTask(TaskPassingDTO order)
        {
            var scoreDTO = await _userTaskResultService.PassTask(order);
            return Ok(scoreDTO);
        }

        [HttpPost("new")]
        public async Task<ActionResult<TaskResultDTO>> Pull(TaskResultCreateDTO order)
        {
            var created = await _userTaskResultService.CreateNewAsync(order);
            return Ok(created);
        }

        [HttpPut]
        public async Task<ActionResult<TaskResultDTO>> Update(TaskResultDTO order)
        {
            var result = await _userTaskResultService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userTaskResultService.DeleteAsync(id);
            return NoContent();
        }
    }
}
