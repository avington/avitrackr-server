﻿using System;
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
        public async Task<ActionResult<List<MyTasksRequest.Model>>> Get([FromQuery] MyTasksRequest.Query query)
        {
            var userId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            query.UserId = userId;
            try
            {
                var result = await _mediator.Send(new MyTasksRequest.Query());
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