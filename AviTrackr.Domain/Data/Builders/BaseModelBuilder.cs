using AviTrackr.Domain.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Data.Builders
{
    public class BaseModelBuilder
    {
        public static void BuildCommon<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>()
                .Property(c => c.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            builder.Entity<T>()
                .Property(c => c.Identifier)
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<T>()
                .Property(c => c.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<T>()
                .Property(c => c.ModifiedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}