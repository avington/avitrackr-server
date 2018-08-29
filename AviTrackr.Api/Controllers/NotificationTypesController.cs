using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AviTrackr.Domain.Features.MyTasks.Queries;
using AviTrackr.Domain.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AviTrackr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypesController: ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public NotificationTypesController(IMediator mediator, ILogger<ProfileController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<NotificationTypesRequest.Model>>> Get()
        {
            try
            {
                var result = await _mediator.Send(new NotificationTypesRequest.Query());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Nofication Types return exception", ex);
                return StatusCode(500, ex);
            }
            
            

        }
    }
}