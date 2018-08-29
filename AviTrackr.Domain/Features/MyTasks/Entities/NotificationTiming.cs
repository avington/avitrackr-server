using System.Collections.Generic;
using AviTrackr.Domain.Base.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Entities
{
    public class NotificationTiming : BaseEntity
    {
        public int TimingAmount { get; set; }
        public string TimingAmountType { get; set; } // minutes, hours, days, weeks, months
        public ICollection<Notification> Notifications { get; set; }
    }
}