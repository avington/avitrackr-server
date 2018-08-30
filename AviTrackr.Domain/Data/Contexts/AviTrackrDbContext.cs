using AviTrackr.Domain.Data.Builders;
using AviTrackr.Domain.Features.MyTasks.Entities;
using AviTrackr.Domain.Features.Users.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Data.Contexts
{
    public class AviTrackrDbContext : DbContext
    {
        public AviTrackrDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<NotificationTiming> NotificationTimings { get; set; }
        public DbSet<NotificationLocation> NotifcationLocations { get; set; }
        public DbSet<MyTaskStatus> MyTaskStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base model building
            BaseModelBuilder.BuildCommon<UserProfile>(builder);
            BaseModelBuilder.BuildCommon<UserPermission>(builder);
            BaseModelBuilder.BuildCommon<MyTask>(builder);
            BaseModelBuilder.BuildCommon<Notification>(builder);
            BaseModelBuilder.BuildCommon<NotificationTiming>(builder);
            BaseModelBuilder.BuildCommon<NotificationType>(builder);
            BaseModelBuilder.BuildCommon<NotificationLocation>(builder);
            BaseModelBuilder.BuildCommon<MyTaskStatus>(builder);

            // custom model building
            UserProfileModelBuilder.Build(builder);
            TasksModelBuilder.Build(builder);
        }

        
    }
}