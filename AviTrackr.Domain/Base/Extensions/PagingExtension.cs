using System.Linq;
using AviTrackr.Domain.Base.Models;

namespace AviTrackr.Domain.Base.Extensions
{
    public static class PagingExtension
    {
        public static IQueryable<TResponse> Paging<TQuery, TResponse>(this IQueryable<TResponse> query, TQuery paging)
            where TQuery : PagingRequestBase
        {
            if (paging.Take.HasValue)
                query = query.Take(paging.Take.Value);

            if (paging.Skip.HasValue)
                query = query.Skip(paging.Skip.Value);

            return query;
        }
    }
}