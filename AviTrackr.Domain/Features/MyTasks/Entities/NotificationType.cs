using System.Collections.Generic;
using AviTrackr.Domain.Base.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Entities
{
    public class NotificationType : BaseEntity
    {
        public string NotificationTypeName { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}