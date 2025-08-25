using MarkMe.Core.DTOs;
using MarkMe.Core.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarkMe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "tutor,admin")]
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
            if(User.IsInRole("tutor") || User.IsInRole("admin"))
            {
                var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var createdCR = await _crService.AddAsync(cr, email);
                return CreatedAtAction(nameof(GetCRById), new { studentId = cr.StudentId }, createdCR);
            }
            else
            {
                return Forbid("Unable to Authenticate.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCR(AddUpdateCRDTO cr)
        {
            if (User.IsInRole("tutor") || User.IsInRole("admin"))
            {
                var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                await _crService.UpdateAsync(cr, email);
                return NoContent();
            }
            else
            {
                return Forbid("Unable to Authenticate.");
            }
        }

        [HttpGet("{studentId}/{isDisabled}")]
        public async Task<ActionResult> ToggleActive(int studentId, bool isDisabled)
        {
            var all = await _crService.ToggleActive(studentId, isDisabled);
            return Ok(all);
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult> DeleteCR(int studentId)
        {
            var all = await _crService.DeleteAsync(studentId);
            return Ok(all);
        }
    }   
}
