using AutoMapper;
using AviTrackr.Domain.Features.Users.Commands;
using AviTrackr.Domain.Features.Users.Entities;
using AviTrackr.Domain.Features.Users.Queries;

namespace AviTrackr.Domain.Features.Users.Profiles
{
    public class UserProfileMappingProfile: Profile
    {
        public UserProfileMappingProfile()
        {
            CreateMap<UpdateProfileCommand.Command, UserProfile>()
                .ForMember(m => m.Email, opt => opt.MapFrom(f => f.UserName))
                .ForMember(m => m.HasLoggedIn, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedAt, opt => opt.Ignore())
                .ForMember(m => m.ModifiedAt, opt => opt.Ignore())
                .ForMember(m => m.RowVersion, opt => opt.Ignore())
                .ForMember(m => m.Identifier, opt => opt.Ignore())
                .ForMember(m => m.UserPermissions, opt => opt.Ignore())
                .ForMember(m => m.MyTasks, opt => opt.Ignore())
                ;

            CreateMap<UserProfile, UserProfileRequest.Model>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(f => f.Email))
                ;

            CreateMap<UserProfile, UpdateProfileCommand.Model>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(f => f.Email))
                ;
        }
    }
}