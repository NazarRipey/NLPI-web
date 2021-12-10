using Microsoft.AspNetCore.Mvc;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.DTO.MainDTOs;
using NLPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.Web.Controllers
{
    [ApiController]
    [Route("api/levels")]
    public class LevelController : ControllerBase
    {
        private ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Level>>> Get()
        {

            var result = await _levelService.GetAll();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LevelDTO>> getById(int id)
        {
            var result = await _levelService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<LevelDTO>> checkLevel(LevelAnswerDTO answer)
        {
            var result = await _levelService.CheckLevel(answer);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Level>> Pull(Level order)
        {
            await _levelService.CreateAsync(order);
            return Ok(order);
        }


        [HttpPut]
        public async Task<ActionResult<LevelDTO>> Update(Level order)
        {
            var result = await _levelService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _levelService.DeleteAsync(id);
            return NoContent();
        }
    }
}
