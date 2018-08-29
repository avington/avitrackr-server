using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AviTrackr.Domain.Features.Users.Commands;
using AviTrackr.Domain.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AviTrackr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator, ILogger<ProfileController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserProfileRequest.Model>> Get()
        {
            var userId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");

            var response = await _mediator.Send(new UserProfileRequest.Query {UserName = userId});
            return response;
        }

        [HttpPut]
        public async Task<ActionResult< UpdateProfileCommand.Model>> Put([FromBody] UpdateProfileCommand.Command command)
        {
            var userId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");

            command.UserName = userId;

            try
            {
                UpdateProfileCommand.Model response = await _mediator.Send(command);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Put Error");
                return StatusCode(500, ex);
            }
        }
    }
}