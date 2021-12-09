using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.Enums;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLPI.Core.Models;
using NLPI.Core.DTO.MainDTOs;

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
        public async Task<ActionResult<List<LevelDTO>>> Get()
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

        //[HttpPost]
        //public async Task<ActionResult<LevelDTO>> Pull(LevelDTO order)
        //{
        //    await _levelService.CreateAsync(order);
        //    return Ok(order);
        //}


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
