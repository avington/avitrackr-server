using System;
using System.Collections;
using System.Collections.Generic;

namespace AviTrackr.Domain.Features.MyTasks.Queries
{
    public class MyOpenedTasksRequest
    {
        public class Model
        {
            public Guid Identifier { get; set; }
            public string TaskName { get; set; }
            public string TaskDescription { get; set; }
            public DateTime? CreatedAt { get; set; }
            public DateTime? ExpiresAt { get; set; }
            public IList<NotificationLocationModel> NotificationLocations { get; set; }  

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
    }
}