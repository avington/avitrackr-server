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
                ;
        }
    }
}