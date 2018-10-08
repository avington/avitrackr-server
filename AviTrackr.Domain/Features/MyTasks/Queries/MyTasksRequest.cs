using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AviTrackr.Domain.Base.Extensions;
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
        public class Model
        {
            public Guid Identifier { get; set; }
            public string TaskName { get; set; }
            public bool ShowBusy { get; set; }
            public bool IsVisible { get; set; }
            public string TaskDescription { get; set; }
            public DateTime? CreatedAt { get; set; }
            public DateTime? StartsAt { get; set; }
            public DateTime? ExpiresAt { get; set; }
            public List<NotificationLocationModel> NotificationLocations { get; set; }
            public List<Notification> Notifications { get; set; }
            public StatusModel Status { get; set; }

            public string UserName { get; set; }
            public PagingResponseModel PagingInfo { get; set; }
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

        public class Query : PagingRequestBase, IRequest<SummaryResponseModel<List<Model>>>
        {
            public string UserId { get; set; }
            public bool? OpenOnly { get; set; }
            public Guid? MyTaskIdentifier { get; set; }
        }

        public class Handler : IRequestHandler<Query, SummaryResponseModel<List<Model>>>
        {
            private readonly AviTrackrDbContext _context;
            private readonly IPagingResponseService _pagingResponseService;

            public Handler(AviTrackrDbContext context, IPagingResponseService pagingResponseService)
            {
                _context = context;
                _pagingResponseService = pagingResponseService;
            }

            public async Task<SummaryResponseModel<List<Model>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var query = _context.Tasks.ProjectTo<Model>().Where(x => x.UserName == request.UserId);

                if (request.MyTaskIdentifier.HasValue && request.MyTaskIdentifier.Value != Guid.Empty)
                {
                    var item = await query
                        .Where(x => x.Identifier == request.MyTaskIdentifier.Value)
                        .ToListAsync(cancellationToken);

                    return new SummaryResponseModel<List<Model>>
                    {
                        Summary = item,
                        PagingInfo = _pagingResponseService.SetPaging(0, 10)
                    };
                }

                if (request.OpenOnly.HasValue && request.OpenOnly.Value)
                {
                    query = query.Where(x => x.Status != null && x.Status.StatusName == "Not Started");
                    query = query.Where(x => x.Status != null && x.Status.StatusName == "In Progress");
                    query = query.Where(x => x.Status != null && x.Status.StatusName == "Pending");
                }

                query = query.Paging(request);

                var result = await query.ToListAsync(cancellationToken);
                return new SummaryResponseModel<List<Model>>
                {
                    Summary = result,
                    PagingInfo = _pagingResponseService.SetPaging(request.Skip, request.Take)
                };
            }
        }
    }
}