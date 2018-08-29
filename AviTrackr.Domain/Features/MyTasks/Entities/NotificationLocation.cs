using AviTrackr.Domain.Base.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Entities
{
    public class NotificationLocation: BaseEntity
    {
        public string Location { get; set; }
        public double? ListingBoundsNorthEastLatitude { get; set; }
        public double? ListingBoundsNorthEastLongitude { get; set; }
        public double? ListingBoundsSouthWestLatitude { get; set; }
        public double? ListingBoundsSouthWesttLongitude { get; set; }

        public virtual MyTask MyTask { get; set; }
    }
}