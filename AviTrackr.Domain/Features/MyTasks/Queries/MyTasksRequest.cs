using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AviTrackr.Domain.Base.Models;
using AviTrackr.Domain.Base.Services;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Features.MyTasks.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Features.MyTasks.Queries
{
    public class MyTasksRequest
    {
        public class Model: PagingModelBase
        {
            public Guid Identifier { get; set; }
            public string TaskName { get; set; }
            public bool ShowBusy { get; set; }
            public bool IsVisible { get; set; }
            public string TaskDescription { get; set; }
            public DateTime? CreatedAt { get; set; }
            public DateTime? ExpiresAt { get; set; }
            public List<NotificationLocationModel> NotificationLocations { get; set; }
            public List<Notification> Notifications { get; set; }
            public StatusModel StatusModel { get; set; }

            public string UserName { get; set; }
        }

        public class NotificationLocationModel
        {
            public Guid Identifier { get; set; }
            public string Location { get; set; }
            public double? ListingBoundsNorthEastLatitude { get; set; }
            public double? ListingBoundsNorthEastLongitude { get; set; }
            public double? ListingBoundsSouthWestLatitude { get; set; }
            public double? ListingBoundsSouthWesttLongitude { get; set; }
        }

        public class StatusModel
        {
            public long Id { get; set; }
            public string StatusName { get; set; }
        }

        public class Query : PagingModelBase, IRequest<List<Model>>
        {
            public string UserId { get; set; }
            public bool? OpenOnly { get; set; }
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
                IQueryable<Model> query = _context.Tasks.ProjectTo<Model>().Where(x => x.UserName == request.UserId);

                if (request.OpenOnly.HasValue && request.OpenOnly.Value)
                {
                    query = query.Where(x => x.StatusModel != null && x.StatusModel.StatusName == "Not Started");
                    query = query.Where(x => x.StatusModel != null && x.StatusModel.StatusName == "In Progress");
                    query = query.Where(x => x.StatusModel != null && x.StatusModel.StatusName == "Pending");
                }

                query = query.Paging(request);

                var result = await query.ToListAsync(cancellationToken);
                return result;
            }
        }
    }
}