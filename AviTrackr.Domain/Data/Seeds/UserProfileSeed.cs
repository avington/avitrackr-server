using System.Collections.Generic;
using System.Threading.Tasks;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Features.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Data.Seeds
{
    public class UserProfileSeed
    {
        public static async Task Seed(AviTrackrDbContext context)
        {
            bool exists = await context.UserProfiles.AnyAsync();
            if (exists == false)
            {
                context.UserProfiles.Add(new UserProfile()
                {
                    Email = "admin@globomantics.com", FirstName = "Steven", LastName = "Moseley",
                    UserPermissions = new List<UserPermission>() {new UserPermission() {Value = "admin"}}
                });
                await context.SaveChangesAsync();

            }

        }
    }
}