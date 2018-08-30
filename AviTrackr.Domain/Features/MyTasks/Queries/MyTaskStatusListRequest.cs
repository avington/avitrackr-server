using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Features.MyTasks.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Features.MyTasks.Queries
{
    public class MyTaskStatusListRequest
    {

        public class Model
        {
            public long Id { get; set; }
            public string StatusName { get; set; }
            public string StatusDescription { get; set; }
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
                var result = await _context
                    .MyTaskStatuses
                    .ProjectTo<Model>()
                    .ToListAsync( cancellationToken);

                return result;
            }
        }
    }
}