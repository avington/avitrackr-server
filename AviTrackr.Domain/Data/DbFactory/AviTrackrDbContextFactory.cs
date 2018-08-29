using System.Reflection;
using AviTrackr.Domain.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AviTrackr.Domain.Data.DbFactory
{
    public class AviTrackrDbContextFactory: IDesignTimeDbContextFactory<AviTrackrDbContext>
    {
        public AviTrackrDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AviTrackrDbContext>();
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=avitrackr;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AviTrackrDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new AviTrackrDbContext(builder.Options);
        }
    }
}