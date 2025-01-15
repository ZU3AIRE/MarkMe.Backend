using MarkMe.Core.Services.Interface;
using MarkMe.Database.Entities;
using MarkMe.Database.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarkMe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "tutor,admin,member,cr")]
    [ApiController]
    public class UserPermissionController(IUserPermissionService _userPermissionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            var allmenus = await _userPermissionService.GetAllAsync();
            var menus = new List<Menu>();

            if (User.IsInRole(Role.Admin.ToString()))
            {
                menus.AddRange(allmenus.Where(x => x.Role == Role.Admin).AsEnumerable());
            }

            if (User.IsInRole(Role.Tutor.ToString()))
            {
                menus.AddRange(allmenus.Where(x => x.Role == Role.Tutor).AsEnumerable());
            }

            if (User.IsInRole(Role.CR.ToString()))
            {
                menus.AddRange(allmenus.Where(x => x.Role == Role.CR).AsEnumerable());
            }

            if (User.IsInRole(Role.Member.ToString()))
            {
                menus.AddRange(allmenus.Where(x => x.Role == Role.Member).AsEnumerable());
            }

            return Ok(menus);
        }
    }
}
