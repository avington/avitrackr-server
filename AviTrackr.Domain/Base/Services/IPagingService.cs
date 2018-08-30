using System.Linq;
using AviTrackr.Domain.Base.Models;
using Remotion.Linq.Clauses;

namespace AviTrackr.Domain.Base.Services
{
    public static class PagingExtension
    {

        public static IQueryable<TResponse> Paging<TQuery, TResponse>(this IQueryable<TResponse> query, TQuery paging)
            where TQuery : PagingModelBase
        {
            if (paging.Take.HasValue)
            {
                query = query.Take(paging.Take.Value);
            }

            if (paging.Skip.HasValue)
            {
                query = query.Skip(paging.Skip.Value);
            }

            return query;

        }
    }
}