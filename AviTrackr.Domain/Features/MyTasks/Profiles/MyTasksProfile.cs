using AutoMapper;
using AviTrackr.Domain.Features.MyTasks.Entities;
using AviTrackr.Domain.Features.MyTasks.Queries;

namespace AviTrackr.Domain.Features.MyTasks.Profiles
{
    public class MyTasksProfile: Profile
    {
        public MyTasksProfile()
        {
            CreateMap<NotificationType, NotificationTypesRequest.Model>()
                ;

            CreateMap<MyOpenedTasksRequest.NotificationLocationModel, NotificationLocation>()
                .ForMember(m => m.MyTask, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Identifier, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                ;

            CreateMap<NotificationLocation, MyOpenedTasksRequest.NotificationLocationModel>()
                ;

            CreateMap<MyTaskStatus, MyTaskStatusListRequest.Model>();




        }
    }
}