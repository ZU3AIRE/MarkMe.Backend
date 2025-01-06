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
    }
}
