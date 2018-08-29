using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AviTrackr.Domain.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Features.MyTasks.Queries
{
    public class NotificationTypesRequest
    {
        public class Model
        {
            public long Id { get; set; }
            public string NotificationTypeName { get; set; }
        }

        public class Query : IRequest<List<Model>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Model>>
        {
            private readonly AviTrackrDbContext _context;

            public Handler(AviTrackrDbContext context)
            {
                _context = context;
            }

            public async Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                List<Model> result = await _context.NotificationTypes.ProjectTo<Model>().ToListAsync();
                return result;
            }
        }
    }
}