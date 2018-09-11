using AutoMapper;
using AviTrackr.Domain.Features.MyTasks.Entities;
using AviTrackr.Domain.Features.MyTasks.Queries;
using AviTrackr.Domain.Features.Users.Entities;

namespace AviTrackr.Domain.Features.MyTasks.Profiles
{
    public class MyTasksProfile : Profile
    {
        public MyTasksProfile()
        {
            CreateMap<NotificationType, NotificationTypesRequest.Model>()
                ;

            CreateMap<MyTasksRequest.NotificationLocationModel, NotificationLocation>()
                .ForMember(m => m.MyTask, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Identifier, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                ;

            CreateMap<NotificationLocation, MyTasksRequest.NotificationLocationModel>()
                ;

            CreateMap<MyTaskStatus, MyTaskStatusListRequest.Model>();

            CreateMap<MyTasksRequest.StatusModel, MyTaskStatus>()
                .ForMember(m => m.MyTasks, opt => opt.Ignore())
                .ForMember(m => m.StatusDescription, opt => opt.Ignore())
                .ForMember(m => m.Identifier, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                ;

            CreateMap<MyTask, MyTasksRequest.Model>()
                .ForMember(m => m.Status, opt => opt.MapFrom(f => f.Status))
                .ForMember(m => m.UserName, opt => opt.MapFrom(f => f.UserProfile.Email))   
                .ForMember(m => m.PagingInfo, opt => opt.Ignore())
                ;

            

            CreateMap<MyTasksRequest.Model, MyTask>()
                .ForMember(m => m.UserProfile, opt => opt.MapFrom(mf => new UserProfile {Email = mf.UserName}))
                .ForMember(m => m.Status, opt => opt.MapFrom(f => f.Status))
                .ForMember(m => m.StatusId, opt => opt.MapFrom(f => f.Status.Id))
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.UserProfileId, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                ;
        }
    }
}