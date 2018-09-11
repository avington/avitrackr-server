using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AviTrackr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        
        /*
        [HttpGet("Users")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var admins = _context.UserPermissions.Where(up => up.Value == "Admin").Select(up => up.UserProfileId).ToList();
            var users = _context.UserProfiles.Where(u => !admins.Contains(u.Id));
            return Ok(users);
        }


        [HttpGet("AuthContext")]
        [Authorize()]
        public IActionResult GetAuthContext()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profile = _context.UserProfiles.Include("UserPermissions").FirstOrDefault(u => u.Id == userId);
            if (profile == null) return NotFound();
            var context = new AuthContext { UserProfile = profile, Claims = User.Claims.Select(c => new SimpleClaim { Type = c.Type, Value = c.Value }).ToList() };
            return Ok(context);
        }
        */
    }
}