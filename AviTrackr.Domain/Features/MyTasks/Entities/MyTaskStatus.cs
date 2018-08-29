using System.Collections.Generic;
using AviTrackr.Domain.Base.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Entities
{
    public class MyTaskStatus : BaseEntity
    {
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public ICollection<MyTask> MyTasks { get; set; }
    }
}