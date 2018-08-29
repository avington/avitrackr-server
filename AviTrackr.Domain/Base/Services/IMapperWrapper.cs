using Remotion.Linq.Clauses;

namespace AviTrackr.Domain.Base.Services
{
    public interface IMapperWrapper
    {
        TDestination Map<TSource, TDestination>(TSource to);
    }
}