﻿using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLPI.Web.Controllers
{
    [ApiController]
    [Route("api/achievdatas")]
    public class AchievementDataController : ControllerBase
    {
        private IAchievementDataService _achievementDataService;

        public AchievementDataController(IAchievementDataService achievementDataService)
        {
            _achievementDataService = achievementDataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AchievementDataDTO>>> Get()
        {

            var result = await _achievementDataService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AchievementDataDTO>> getById(int id)
        {
            var result = await _achievementDataService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<AchievementDataDTO>> Pull(AchievementDataDTO order)
        {
            await _achievementDataService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<AchievementDataDTO>> Update(AchievementDataDTO order)
        {
            var result = await _achievementDataService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _achievementDataService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("compare/{oemail}/{aemail}")]
        public async Task<ActionResult<List<CompareAchievDataDTO>>> Compare(string oemail, string aemail)
        {
            var result = await _achievementDataService.GetCompareAchievs(oemail, aemail);
            return Ok(result);
        }

        [HttpGet("simple/{email}")]
        public async Task<ActionResult<List<SimpleAchievDataDTO>>> GetSimpleAchievs(string email)
        {
            var result = await _achievementDataService.GetAchievsByEmail(email);
            return Ok(result);
        }

        [HttpGet("detail/{email}")]
        public async Task<ActionResult<List<DetailAchievDataDTO>>> GetDetailAchievs(string email)
        {
            var result = await _achievementDataService.GetDetailAchievsByEmail(email);
            return Ok(result);
        }

        [HttpPost("save")]
        public async Task<ActionResult<bool>> SaveUserAchievements(UpdateUserAchievement achiev)
        {
            var result = await _achievementDataService.SaveAchievement(achiev);
            return Ok(result);
        }
    }
}
