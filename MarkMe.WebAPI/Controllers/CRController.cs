using MarkMe.Core.DTOs;
using MarkMe.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarkMe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CRController(ICRService _crService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CRDTO>>> GetAllCRs()
        {
            var crs = await _crService.GetAllAsync();
            return Ok(crs);
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<CRDTO>> GetCRById(int studentId)
        {
            var cr = await _crService.GetAsync(studentId);
            if (cr == null)
            {
                return NotFound();
            }
            return Ok(cr);
        }


        [HttpPost] 
        public async Task<ActionResult> NominateCR(AddUpdateCRDTO cr)
        {
            var createdCR = await _crService.AddAsync(cr);
            return CreatedAtAction(nameof(GetCRById), new { studentId = cr.StudentId }, createdCR);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCR(AddUpdateCRDTO cr)
        {
            await _crService.UpdateAsync(cr);
            return NoContent();
        }
    }
}
