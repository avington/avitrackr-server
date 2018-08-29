using System.Collections.Generic;
using AviTrackr.Domain.Base.Entities;
using AviTrackr.Domain.Features.MyTasks.Entities;

namespace AviTrackr.Domain.Features.Users.Entities
{
    public class UserProfile: BaseEntity
    {
        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasLoggedIn { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }
        public ICollection<MyTasks.Entities.MyTask> MyTasks { get; set; }
    }
}