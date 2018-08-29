using System;
using System.Linq;
using AviTrackr.Domain.Base.Services;
using AviTrackr.Domain.Data.Contexts;
using AviTrackr.Domain.Features.Users.Entities;
using MediatR;

namespace AviTrackr.Domain.Features.Users.Commands
{
    //TODO command
    public class UpdateProfileCommand
    {
        public class Model
        {
            public string UserName { get; set; }
            public Guid Identifier { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Command : IRequest<Model>
        {
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }


        public class Handler : RequestHandler<Command, Model>
        {
            private readonly AviTrackrDbContext _context;
            private readonly IMapperWrapper _mapperWrapper;

            public Handler(AviTrackrDbContext context, IMapperWrapper mapperWrapper)
            {
                _context = context;
                _mapperWrapper = mapperWrapper;
            }

            protected override Model Handle(Command request)
            {
                var entity = _context.UserProfiles.FirstOrDefault(x => x.Email == request.UserName);
                if (entity != null)
                {
                    entity.FirstName = request.FirstName;
                    entity.LastName = request.LastName;
                }
                else
                {
                    entity = _mapperWrapper.Map<Command, UserProfile>(request);
                    _context.UserProfiles.Add(entity);
                }
                _context.SaveChanges();
                return _mapperWrapper.Map<UserProfile, Model>(entity);
            }
        }
    }
}