using System;
using AutoMapper;
using AviTrackr.Domain.Features.MyTasks.Commands;
using AviTrackr.Domain.Features.MyTasks.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Profiles
{
    public class AddMyTaskCommandProfile : Profile
    {
        public AddMyTaskCommandProfile()
        {
            CreateMap<AddMyTask.Command, MyTask>()
                .ForMember(m => m.NotificationLocations, opt => opt.Ignore())
                .ForMember(m => m.UserProfile, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                ;

            CreateMap<AddMyTask.NotificationModel, Notification>()
                .ForMember(m => m.NotificationTimingId, opt => opt.Ignore())
                .ForMember(m => m.MyTask, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                ;

            CreateMap<AddMyTask.NotificationTimingModel, NotificationTiming>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.Notifications, opt => opt.Ignore())
                ;

            CreateMap<AddMyTask.NotificationTypeModel, NotificationType>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.Notifications, opt => opt.Ignore())
                ;

            CreateMap<AddMyTask.StatusModel, MyTaskStatus>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.StatusName, opt => opt.Ignore())
                .ForMember(m => m.StatusDescription, opt => opt.Ignore())
                .ForMember(m => m.MyTasks, opt => opt.Ignore())
                .ForMember(m => m.Identifier, opt => opt.Ignore())
                ;

            CreateMap<MyTask, AddMyTask.Command>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(f => f.UserProfile.Email))
                ;

            CreateMap<Notification, AddMyTask.NotificationModel>()
                ;

            CreateMap<NotificationTiming, AddMyTask.NotificationTimingModel>()
                ;


        }
    }
}