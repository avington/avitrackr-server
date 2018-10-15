using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AviTrackr.Domain.Base.Models;
using AviTrackr.Domain.Features.MyTasks.Commands;
using AviTrackr.Domain.Features.MyTasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<SummaryResponseModel<List<MyTasksRequest.Model>>>> Get(
            [FromQuery] MyTasksRequest.Query query)
        {
            var userId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            query.UserId = userId;
            try
            {
                var result = await _mediator.Send(query);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("My Task List Exception", ex);
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AddMyTask.Command>> Post(AddMyTask.Command command)
        {
            var userId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            command.UserName = userId;
            try
            {
                var result = await _mediator.Send(command);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("My Task List Exception", ex);
                return StatusCode(500, ex);
            }
            
        }
    }
}