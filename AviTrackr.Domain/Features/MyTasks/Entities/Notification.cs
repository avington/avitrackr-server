using AviTrackr.Domain.Base.Entities;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace AviTrackr.Domain.Features.MyTasks.Entities
{
    public class Notification: BaseEntity
    {
        public virtual NotificationType NotificationType { get; set; }
        public long NotificationTypeId { get; set; }
        public virtual NotificationTiming NotificationTiming { get; set; }
        public long NotificationTimingId { get; set; }
    
        public virtual MyTask MyTask { get; set; }

    }
}