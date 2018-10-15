using AviTrackr.Domain.Features.MyTasks.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Data.Builders
{
    public class TasksModelBuilder
    {
        public static void Build(ModelBuilder builder)
        {
            builder.Entity<MyTask>(entity =>
            {
                entity.HasMany(hm => hm.Notifications)
                    .WithOne(o => o.MyTask)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(hm => hm.NotificationLocations)
                    .WithOne(o => o.MyTask)
                    .OnDelete(DeleteBehavior.Cascade);

                

            });

            builder.Entity<NotificationTiming>(e =>
            {
                e.HasMany(m => m.Notifications)
                    .WithOne(o => o.NotificationTiming)
                    .HasForeignKey(f => f.NotificationTimingId);
            });

            builder.Entity<NotificationType>(e =>
            {
                e.HasMany(m => m.Notifications)
                    .WithOne(o => o.NotificationType)
                    .HasForeignKey(f => f.NotificationTypeId);
            });

            builder.Entity<MyTaskStatus>(e =>
            {
                e.HasMany(m => m.MyTasks)
                    .WithOne(o => o.Status)
                    .HasForeignKey(f => f.StatusId);
            });


        }
    }
}