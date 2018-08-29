using System.Threading.Tasks;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Features.MyTasks.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Data.Seeds
{
    public class NotificationTypeSeed
    {
        public static async Task Seed(AviTrackrDbContext context)
        {
            var exists = await context.NotificationTypes.AnyAsync();
            if (exists) return;
            context.NotificationTypes.Add(new NotificationType {NotificationTypeName = "Email"});
            context.NotificationTypes.Add(new NotificationType {NotificationTypeName = "SMS"});
            context.NotificationTypes.Add(new NotificationType {NotificationTypeName = "Alexa"});
            await context.SaveChangesAsync();
        }
    }
}