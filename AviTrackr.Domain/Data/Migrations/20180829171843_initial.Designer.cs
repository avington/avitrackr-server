﻿// <auto-generated />
using System;
using AviTrackr.Domain.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AviTrackr.Domain.Data.Migrations
{
    [DbContext(typeof(AviTrackrDbContext))]
    [Migration("20180829171843_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.MyTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("ExpiresAt");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsVisible");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<bool>("ShowBusy");

                    b.Property<long>("StatusId");

                    b.Property<string>("TaskDescription");

                    b.Property<string>("TaskName");

                    b.Property<long>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.MyTaskStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("StatusDescription");

                    b.Property<string>("StatusName");

                    b.HasKey("Id");

                    b.ToTable("MyTaskStatuses");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<long?>("MyTaskId");

                    b.Property<long>("NofificationTimingId");

                    b.Property<long>("NotificationTypeId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MyTaskId");

                    b.HasIndex("NofificationTimingId");

                    b.HasIndex("NotificationTypeId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.NotificationLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<double?>("ListingBoundsNorthEastLatitude");

                    b.Property<double?>("ListingBoundsNorthEastLongitude");

                    b.Property<double?>("ListingBoundsSouthWestLatitude");

                    b.Property<double?>("ListingBoundsSouthWesttLongitude");

                    b.Property<string>("Location");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<long?>("MyTaskId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MyTaskId");

                    b.ToTable("NotifcationLocations");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.NotificationTiming", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("TimingAmount");

                    b.Property<string>("TimingAmountType");

                    b.HasKey("Id");

                    b.ToTable("NotificationTimings");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.NotificationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("NotificationTypeName");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("NotificationTypes");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.Users.Entities.UserPermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<int?>("ProjectId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long>("UserProfileId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.Users.Entities.UserProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("HasLoggedIn");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.MyTask", b =>
                {
                    b.HasOne("AviTrackr.Domain.Features.MyTasks.Entities.MyTaskStatus", "Status")
                        .WithMany("MyTasks")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AviTrackr.Domain.Features.Users.Entities.UserProfile", "UserProfile")
                        .WithMany("MyTasks")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.Notification", b =>
                {
                    b.HasOne("AviTrackr.Domain.Features.MyTasks.Entities.MyTask", "MyTask")
                        .WithMany("Notifications")
                        .HasForeignKey("MyTaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AviTrackr.Domain.Features.MyTasks.Entities.NotificationTiming", "NofificationTiming")
                        .WithMany("Notifications")
                        .HasForeignKey("NofificationTimingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AviTrackr.Domain.Features.MyTasks.Entities.NotificationType", "NotificationType")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.MyTasks.Entities.NotificationLocation", b =>
                {
                    b.HasOne("AviTrackr.Domain.Features.MyTasks.Entities.MyTask", "MyTask")
                        .WithMany("NotificationLocations")
                        .HasForeignKey("MyTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AviTrackr.Domain.Features.Users.Entities.UserPermission", b =>
                {
                    b.HasOne("AviTrackr.Domain.Features.Users.Entities.UserProfile", "UserProfile")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
