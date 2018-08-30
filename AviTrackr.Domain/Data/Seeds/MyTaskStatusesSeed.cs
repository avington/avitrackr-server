using System.Threading.Tasks;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Features.MyTasks.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Data.Seeds
{
    public class MyTaskStatusesSeed
    {
        public static async Task Seed(AviTrackrDbContext context)
        {
            var exists = await context.MyTaskStatuses.AnyAsync();
            if (!exists)
            {
                context.MyTaskStatuses.Add(new MyTaskStatus
                {
                    StatusName = "Not Started",
                    StatusDescription = "Have not started the Task"
                });
                context.MyTaskStatuses.Add(new MyTaskStatus
                {
                    StatusName = "Pending",
                    StatusDescription = "Wait on something else"
                });
                context.MyTaskStatuses.Add(new MyTaskStatus
                {
                    StatusName = "In Progress",
                    StatusDescription = "The task has started but not yet finished"
                });
                context.MyTaskStatuses.Add(new MyTaskStatus
                {
                    StatusName = "Done",
                    StatusDescription = "The task is completed."
                });
                context.MyTaskStatuses.Add(new MyTaskStatus
                {
                    StatusName = "Removed",
                    StatusDescription = "The task is no longer necessary."
                });
               await  context.SaveChangesAsync();
            }
        }
    }
}