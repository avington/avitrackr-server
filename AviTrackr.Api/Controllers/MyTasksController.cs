using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AviTrackr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public MyTasksController(IMediator mediator, ILogger<ProfileController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /*
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserProfileRequest.Model>> Get()
        {
            var userId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");

            
        }
        */
    }
}