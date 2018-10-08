using System;
using AutoMapper;
using AviTrackr.Domain.Features.MyTasks.Commands;
using AviTrackr.Domain.Features.MyTasks.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Profiles
{
    public class MyTaskCommandProfile : Profile
    {
        public MyTaskCommandProfile()
        {
            CreateMap<AddUpdateMyTask.Command, MyTask>()
                .ForMember(m => m.NotificationLocations, opt => opt.Ignore())
                .ForMember(m => m.UserProfile, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                ;

            CreateMap<AddUpdateMyTask.NotificationModel, Notification>()
                .ForMember(m => m.NotificationTimingId, opt => opt.Ignore())
                .ForMember(m => m.MyTask, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                ;

            CreateMap<AddUpdateMyTask.NotificationTimingModel, NotificationTiming>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.Notifications, opt => opt.Ignore())
                ;

            CreateMap<AddUpdateMyTask.NotificationTypeModel, NotificationType>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.Notifications, opt => opt.Ignore())
                ;

            CreateMap<AddUpdateMyTask.StatusModel, MyTaskStatus>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.StatusName, opt => opt.Ignore())
                .ForMember(m => m.StatusDescription, opt => opt.Ignore())
                .ForMember(m => m.MyTasks, opt => opt.Ignore())
                .ForMember(m => m.Identifier, opt => opt.Ignore())
                ;
        }
    }
}