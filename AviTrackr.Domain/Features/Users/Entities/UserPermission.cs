using AviTrackr.Domain.Base.Entities;

namespace AviTrackr.Domain.Features.Users.Entities
{
    public class UserPermission: BaseEntity
    {
        
        public long UserProfileId { get; set; }
        public int? ProjectId { get; set; }
        public string Value { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}