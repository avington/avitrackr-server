using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AviTrackr.Domain.Features.MyTasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AviTrackr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskStatusesController: ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public MyTaskStatusesController(IMediator mediator, ILogger<ProfileController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MyTaskStatusListRequest.Model>>> Get()
        {
            try
            {
                var result = await _mediator.Send(new MyTaskStatusListRequest.Query());
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}