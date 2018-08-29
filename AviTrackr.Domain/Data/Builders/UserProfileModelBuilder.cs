using AviTrackr.Domain.Features.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Data.Builders
{
    public class UserProfileModelBuilder
    {
        public static void Build(ModelBuilder builder)
        {
            builder.Entity<UserProfile>(entity =>
            {
                entity.HasMany(hm => hm.UserPermissions)
                    .WithOne(wo => wo.UserProfile)
                    .HasForeignKey(k => k.UserProfileId);

                entity.HasMany(hm => hm.MyTasks)
                    .WithOne(wo => wo.UserProfile)
                    .HasForeignKey(k => k.UserProfileId);
            });
        }
    }
}