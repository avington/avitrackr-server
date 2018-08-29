using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AviTrackr.Domain.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AviTrackr.Domain.Features.Users.Queries
{
    public class UserProfileRequest
    {
        public class Model
        {
            public string UserName { get; set; }
            public Guid Identifier { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Query : IRequest<Model>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Model>
        {
            private readonly AviTrackrDbContext _context;

            public Handler(AviTrackrDbContext context)
            {
                _context = context;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.UserProfiles
                    .Where(x => x.Email == request.UserName)
                    .ProjectTo<Model>()
                    .FirstOrDefaultAsync(cancellationToken);

                return result ?? new Model {UserName = request.UserName};
            }

        }
    }
}