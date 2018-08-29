using System;
using System.Collections.Generic;
using AviTrackr.Domain.Base.Entities;
using AviTrackr.Domain.Features.Users.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Entities
{
    
    public class MyTask: BaseEntity
    {

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool ShowBusy { get; set; }
        public bool IsVisible { get; set; }
        public ICollection<NotificationLocation> NotificationLocations { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public long UserProfileId { get; set; }

        public virtual MyTaskStatus Status { get; set; }
        public long StatusId { get; set; }

    }
}