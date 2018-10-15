using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AviTrackr.Domain.Base.Services;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Features.MyTasks.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Features.MyTasks.Commands
{
    public class AddMyTask
    {

        public class Command: IRequest<Command>
        {
            public string TaskName { get; set; }
            public string TaskDescription { get; set; }
            public Guid? Identifier { get; set; }
            public bool ShowBusy { get; set; }
            public bool IsVisible { get; set; }
            public DateTime? StartsAt { get; set; }
            public DateTime? ExpiresAt { get; set; }

            public virtual IList<NotificationModel> Notifications { get; set; }

            public string UserName { get; set; }
            public long UserProfileId { get; set; }

            public virtual StatusModel Status { get; set; }

        }

        public class StatusModel
        {
            public long Id { get; set; }
        }

        public class NotificationModel
        {
            public Guid? Identifier { get; set; }
            public NotificationTimingModel NotificationTiming { get; set; }
            public NotificationTypeModel NotificationType { get; set; }
        }

        public class NotificationTimingModel
        {
            public Guid? Identifier { get; set; }
            public int TimingAmount { get; set; }
            public string TimingAmountType { get; set; } // minutes, hours, days, weeks, months

        }

        public class NotificationTypeModel
        {
            public long Id { get; set; }
            public Guid? Identifier { get; set; }
            public string NotificationTypeName { get; set; }
        }

        public class Handler : IRequestHandler<Command, Command>
        {
            private readonly AviTrackrDbContext _context;
            private readonly IMapperWrapper _mapperWrapper;
            public Handler(AviTrackrDbContext context, IMapperWrapper mapperWrapper)
            {
                this._context = context;
                _mapperWrapper = mapperWrapper;
            }

            public async Task<Command> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Email == request.UserName, cancellationToken);
                var status = await _context.MyTaskStatuses.FirstOrDefaultAsync(s => s.Id == request.Status.Id, cancellationToken);

                if (user == null)
                {
                    return null;
                }

                var myTask = _mapperWrapper.Map<Command, MyTask>(request);

                myTask.UserProfile = user;
                myTask.UserProfileId = user.Id;
                myTask.Status = status;

                _context.Tasks.Add(myTask);

                await _context.SaveChangesAsync(cancellationToken);

                var result = _mapperWrapper.Map<MyTask, AddMyTask.Command>(myTask);
                myTask.UserProfileId = 0;

                return result;

            }
        }
        
    }
}