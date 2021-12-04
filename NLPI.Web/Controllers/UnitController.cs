using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.Web.Controllers
{
    [ApiController]
    [Route("api/units")]
    public class UnitController : ControllerBase
    {
        private IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UnitDTO>>> Get()
        {

            var result = await _unitService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDTO>> getById(int id)
        {
            var result = await _unitService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UnitDTO>> Pull(UnitDTO order)
        {
            await _unitService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<UnitDTO>> Update(UnitDTO order)
        {
            var result = await _unitService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitService.DeleteAsync(id);
            return NoContent();
        }
    }
}
